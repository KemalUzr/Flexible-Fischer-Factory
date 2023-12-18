import { ErrorHandler } from "./ErrorHandler";

jest.unmock('./ErrorHandler');

describe('ErrorHandler', () => {
	test('Received error', () => {
		const handler = new ErrorHandler();
		const errorSpy = jest.spyOn(console, 'error');

		handler.handleEvent('test', 'test', new Error('test'));

		expect(handler).toBeDefined();
		expect(errorSpy).toBeCalledWith('Error: test');
	});
});
