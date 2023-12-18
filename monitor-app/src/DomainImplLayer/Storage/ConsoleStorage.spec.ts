import { ConsoleStorage } from "./ConsoleStorage";

jest.unmock('./ConsoleStorage');

describe('ConsoleStorage', () => {
	test('should be defined', () => {
		const consoleStorage = new ConsoleStorage();

		expect(consoleStorage).toBeDefined();
	});

	test('should store data', () => {
		const consoleStorage = new ConsoleStorage();
		// Initialize spy on console.log
		const spy = jest.spyOn(console, 'log');

		consoleStorage.store('test message');

		expect(spy).toHaveBeenCalledWith('test message');
	});
});
