import { Message } from "./message";

export interface Session {
    id: string; // Unique identifier for the session
    title: string; // Title of the session
    startedAt: Date; // Timestamp of when the session was created
    messages: Message[]; // Optional array of messages in the session
}

export type SessionSummary = Pick<Session, 'id' | 'title' | 'startedAt'>;
