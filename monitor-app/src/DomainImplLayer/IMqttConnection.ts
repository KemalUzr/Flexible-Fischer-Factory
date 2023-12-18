export interface IMqttConnection {
	subscribe(topic: string): void;
	publish(topic: string, message: string): void;
}
