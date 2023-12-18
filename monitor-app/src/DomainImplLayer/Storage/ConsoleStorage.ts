import { IStorage } from "../../DomainLayer/IStorage";

export class ConsoleStorage implements IStorage {
	public store(data: string) {
		console.log(data);
	}
}
