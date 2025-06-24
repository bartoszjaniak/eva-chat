import { inject, Injectable, signal } from '@angular/core';
import { ResponseStatus } from '../models/response-status';
import { ChatStore } from '../stores/chat.store';
import { HttpClient } from '@angular/common/http';
import { RateMessageAction } from '../models/rate-message';
import { environment } from '../../environments/environment';

const API_URL = environment.apiUrl + '/api/chat/message';

@Injectable({ providedIn: 'root' })
export class ChatStreamService {
    private http = inject(HttpClient);

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
                    const parsedChunk = JSON.parse(chunk) as { SessionId: string; MessageId: string; Chunk: string; };
                    yield parsedChunk;
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

    rateMessage(action: RateMessageAction) {
        return this.http.post(API_URL + '/rate', action);
    }
}
