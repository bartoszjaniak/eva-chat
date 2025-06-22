import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { map, Observable, tap } from "rxjs";
import { Session, SessionSummary } from "../models/session";
import { Message, Rating } from "../models/message";

const API_URL = 'http://localhost:5278/api/session'; // TODO: przenieś do environment
 type SessionMessagesResponse = {
    messages: {
        content:string;
        createdAt: Date;
        id: number;
        isFromBot: boolean;
        rating: Rating;
        sessionId: string;

    }[];
    startedAt: Date;
};

@Injectable({ providedIn: 'root' })
export class SessionService {
    constructor(private http: HttpClient) { }

    public getSessions(): Observable<SessionSummary[]> {
        return this.http.get<{ sessions: { sessionId: string; title: string; startedAt: Date }[] }>(`${API_URL}`).pipe(
            map(response =>
                response.sessions.map(response => ({
                    id: response.sessionId,
                    title: response.title || 'Nowa sesja',
                    startedAt: response.startedAt
                } as Session))
            ));
    }



    public getSessionMessages(sessionId: string): Observable<Message[]> {
        // Zwraca historię wiadomości w danej sesji
        return this.http.get<SessionMessagesResponse>(`${API_URL}/${sessionId}/messages`).pipe(
            map(response => response.messages.map(res => ({
                id: res.id.toString(),
                type: res.isFromBot ? 'bot' : 'user',
                text: res.content,
                createdAt: res.createdAt,
                sessionId: res.sessionId,
                rating: res.rating
            } as Message)) || []
            )
        );
    }
}
