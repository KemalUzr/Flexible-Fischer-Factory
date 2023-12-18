import { IHandler } from "../../DomainLayer/IHandler";

export class ConnectedHandler implements IHandler {
	public handleEvent(): void {
		console.log(`Connected`);
	}
}
