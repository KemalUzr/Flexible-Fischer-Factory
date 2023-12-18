import { ITopicHandler } from "../../DomainLayer/ITopicHandler";
import { IHandler } from "../../DomainLayer/IHandler";

export class MessageHandler implements IHandler {
	private topicHandlers: ITopicHandler[];

	constructor(handlers: ITopicHandler[]) {
		this.topicHandlers = handlers;
	}

	public handleEvent(topic: string, message: string): void {
		this.topicHandlers.forEach(handler => {
			if(handler.topicToHandle() == topic) {
				handler.handleTopic(message);
			}
		});
	}
}
