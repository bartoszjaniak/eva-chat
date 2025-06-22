export interface Message {
    id: string; // Unique identifier for the message
    type: 'user' | 'bot' | 'generated';
    text: string;
    rating: Rating;
    timestamp?: Date; // Optional timestamp for when the message was sent
    sessionId?: string; // Optional session ID to associate messages with a specific chat session
}

export enum Rating {
    None = 0,
    Like = 1,
    Dislike = -1
}
