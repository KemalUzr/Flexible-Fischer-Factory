export interface ITopicHandler {
	handleTopic(data: string): void;
	topicToHandle(): string;
}
