import { OvenTopicHandler } from "../DomainImplLayer/TopicHandlers/OvenTopicHandler";
import { MessageHandler } from "../DomainImplLayer/Handlers/MessageHandler";
import { MqttConnection } from "./MqttConnection";
import { ConnectedHandler } from "../DomainImplLayer/Handlers/ConnectedHandler";
import { ErrorHandler } from "../DomainImplLayer/Handlers/ErrorHandler";
import { ConsoleStorage } from "../DomainImplLayer/Storage/ConsoleStorage";
import { FileStorage } from "../DomainImplLayer/Storage/FileStorage";
import { SawTopicHandler } from "../DomainImplLayer/TopicHandlers/SawTopicHandler";
import { ColorTopicHandler } from "../DomainImplLayer/TopicHandlers/ColorTopicHandler";
import { TransportTopicHandler } from "../DomainImplLayer/TopicHandlers/TransportTopicHandler";

export class Application {
	public run(): void {
		const ip = process.env.MQTT_BROKER_HOST || '192.168.0.10';
		const port = Number(process.env.MQTT_BROKER_PORT) || 1883;

		const mqttConnection = new MqttConnection(ip, port);

		const ovenTopicHandler = new OvenTopicHandler(
			'f/i/state/mpo',
			mqttConnection,
			[
				new ConsoleStorage(),
				new FileStorage("database/oven.txt")
			]
		);

		const sawTopicHandler = new SawTopicHandler(
			'f/i/state/mpo',
			mqttConnection,
			[
				new ConsoleStorage(),
				new FileStorage("database/saw.txt")
			]
		);

		const colorTopicHandler = new ColorTopicHandler(
      'f/i/state/sld',
			mqttConnection,
			[
				new ConsoleStorage(),
        new FileStorage("database/color.txt")
      ]
    );

		const transportTopicHandler = new TransportTopicHandler(
			'f/i/state/sld',
			mqttConnection,
			[
				new ConsoleStorage(),
				new FileStorage("database/transport.txt")
			]
		);

		const messageHandler = new MessageHandler([
			ovenTopicHandler,
			sawTopicHandler,
			colorTopicHandler,
			transportTopicHandler
		]);

		const connectedHandler = new ConnectedHandler();

		const errorHandler = new ErrorHandler();

		mqttConnection.onConnect(connectedHandler);
		mqttConnection.onMessage(messageHandler);
		mqttConnection.onError(errorHandler);
	}
}
