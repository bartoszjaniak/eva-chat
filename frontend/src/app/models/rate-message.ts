import { Message } from "./message";

export type RateMessageAction = Pick<Message, 'rating'> & { messageId: Message['id']};
