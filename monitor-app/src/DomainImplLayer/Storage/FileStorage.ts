import { IStorage } from "../../DomainLayer/IStorage";
import * as fs from "fs";

export class FileStorage implements IStorage {
	private filename: string;

	constructor(filename: string) {
		this.filename = filename;

		// Create the file if it doesn't exist
		try {
			fs.accessSync(this.filename, fs.constants.F_OK);
		} catch (err) {
			fs.writeFileSync(this.filename, '');
		}
	}

	public store(data: string) {
		// Open the file for writing
		try {
			const fd = fs.openSync(this.filename, "a");
			fs.writeSync(fd, data);
			fs.closeSync(fd);
		} catch (err) {
			throw new Error("Error opening file: " + err);
		}
	}

	public read(): string {
		return fs.readFileSync(this.filename, 'utf8');
	}
}
