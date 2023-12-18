import { FileStorage } from "./FileStorage";
import fs from 'fs';

jest.unmock('./FileStorage');

describe('FileStorage', () => {
	beforeEach(() => {
		// Reset the mocked file system
		jest.clearAllMocks();
	});

	afterEach(() => {
		// Remove the file
		fs.rmSync('test.txt', { force: true });
	});

	test('should be defined', () => {
		const fileStorage = new FileStorage('test.txt');

		expect(fileStorage).toBeDefined();
	});

	test('should store data', () => {
		const fileStorage = new FileStorage('test.txt');
		fileStorage.store('test message');

		fs.readFileSync = jest.fn().mockReturnValue('test message');

		const readData = fileStorage.read();

		expect(fs.readFileSync).toBeCalledTimes(1);
		expect(readData).toBe('test message');
	});

	test('should create file if it does not exists', () => {
		// Check if file exists
		expect(fs.existsSync('test.txt')).toBe(false);

		const fileStorage = new FileStorage('test.txt');

		fs.readFileSync = jest.fn().mockReturnValue('');

		const readData = fileStorage.read();

		expect(fs.existsSync('test.txt')).toBe(true);
		expect(fs.readFileSync).toBeCalledTimes(1);
		expect(readData).toBe('');
	});
});
