import { inject, Injectable, signal } from '@angular/core';
import { ResponseStatus } from '../models/response-status';
import { ChatStore } from '../stores/chat-session.store';

const API_URL = 'http://localhost:5278/api/chat/message'; // Zastąp rzeczywistym URL API

@Injectable({ providedIn: 'root' })
export class ChatStreamService {

  async *streamChatResponse(params: { sessionId: string | null, content: string }, abortSignal?: AbortSignal) {
        try {
            const res = await fetch(API_URL, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(params),
                signal: abortSignal
            });

            if (!res.body) throw new Error("Nie można odczytać strumienia odpowiedzi");

            const reader = res.body.getReader();
            const decoder = new TextDecoder();
            let done = false;

            while (!done) {
                const { value, done: doneReading } = await reader.read();
                done = doneReading;
                if (value) {
                    const chunk = decoder.decode(value, { stream: true });
                    const parsedChunk = JSON.parse(chunk) as { SessionId: string, Chunk: string; };
                    yield parsedChunk; // yield zamiast wrzucania do store!
                }
            }
        } catch (error) {
            if ((error as any).name === 'AbortError') {
                // Obsługa przerwania
                return;
            }
            console.error('Błąd podczas strumieniowania odpowiedzi:', error);
            throw error;
        }
    }
}
