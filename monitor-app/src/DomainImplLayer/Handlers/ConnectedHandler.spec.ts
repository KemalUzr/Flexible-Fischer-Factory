import { ConnectedHandler } from './ConnectedHandler';

jest.unmock('./ConnectedHandler');

describe('ConnectedHandler', () => {
	test('Connect to server', () => {
		// Setup the handler and spy on the console.log method.
		const handler = new ConnectedHandler();
		const logSpy = jest.spyOn(console, 'log');

		handler.handleEvent();

		expect(handler).toBeDefined();
		expect(logSpy).toBeCalledWith('Connected');
	});
});
