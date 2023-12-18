import { IHandler } from "../../DomainLayer/IHandler";

export class ErrorHandler implements IHandler {
	public handleEvent(topic: string, message: string, error: Error): void {
		// The topic and message are not used in this example but they are available.
		topic;
		message;

		console.error(`Error: ${error.message}`);
	}
}
