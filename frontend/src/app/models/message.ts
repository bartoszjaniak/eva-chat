export interface Message {
  type: 'user' | 'bot' | 'generated';
  text: string;
  timestamp?: Date; // Optional timestamp for when the message was sent
  sessionId?: string; // Optional session ID to associate messages with a specific chat session
}
