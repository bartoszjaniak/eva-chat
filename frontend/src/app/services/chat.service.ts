import { Injectable, signal } from '@angular/core';
import { ResponseStatus } from '../models/response-status';

const API_URL = 'http://localhost:5278/api/chat/message'; // Zastąp rzeczywistym URL API

@Injectable({ providedIn: 'root' })
export class ChatStreamService {
    private initialValue = {sessionId: null, message: ''};

    public responseSignal = signal<{sessionId?: string | null, message: string}>(this.initialValue);

    public statusSignal = signal<ResponseStatus>('idle');


    async streamChatResponse(params: {sessionId: string | null, content: string}): Promise<void> {
        try {
            this.responseSignal.set(this.initialValue);
               this.statusSignal.set('pending');
            const res = await fetch(API_URL, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(params)
            });

            if (!res.body) throw new Error("Nie można odczytać strumienia odpowiedzi");
            ;

            const reader = res.body.getReader();
            const decoder = new TextDecoder();
            let done = false;

            while (!done) {
                const { value, done: doneReading } = await reader.read();
                done = doneReading;
                if (value) {
                    const chunk = decoder.decode(value, { stream: true });
                    const parsedChunl = JSON.parse(chunk) as { SessionId: string, Chunk: string; };

                    if (parsedChunl.SessionId) {
                        // Jeśli jest SessionId, to aktualizujemy status
                        this.statusSignal.set('generating');
                    }

                    this.responseSignal.update(val => ({
                        ...val,
                        sessionId: parsedChunl.SessionId,
                        message: (val.message ?? '') + parsedChunl.Chunk}
                    ));
                }
            }
            this.statusSignal.set('idle'); // Ustaw status na idle po zakończeniu
        } catch (error) {
            console.error('Błąd podczas strumieniowania odpowiedzi:', error);
            this.statusSignal.set('error');
        }
    }
}
