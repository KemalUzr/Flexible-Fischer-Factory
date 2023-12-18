import { IMqttConnection } from "../IMqttConnection";
import { ITopicHandler } from "../../DomainLayer/ITopicHandler";
import { IStorage } from "../../DomainLayer/IStorage";

export abstract class BaseTopicHandler implements ITopicHandler {
	private topic: string;
	protected client: IMqttConnection;
	protected storagePlaces: IStorage[];

	constructor(topic: string, client: IMqttConnection, storagePlaces?: IStorage[]) {
		this.topic = topic;
		this.client = client;

		this.client.subscribe(this.topic);

		if (storagePlaces) {
			this.storagePlaces = storagePlaces;
		} else {
			this.storagePlaces = [];
		}
	}

	public topicToHandle(): string {
		return this.topic;
	}

	public abstract handleTopic(data: string): void;
}
