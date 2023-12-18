/*================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  29-03-2023
 * @description    :  This will contain the class that will handle the MQTT connection.
 *================================================================================================*/

import * as mqtt from 'mqtt';
import { IHandler } from '../DomainLayer/IHandler';
import { IMqttConnection } from '../DomainImplLayer/IMqttConnection';

export class MqttConnection implements IMqttConnection {
	private mqttClient: mqtt.Client;

	constructor(server: string, port: number) {
		this.mqttClient = mqtt.connect(`mqtt://${server}:${port}`);
	}

	/**
	 * @description: This will subscribe to a topic.
	 *
	 * @param topic: The topic to subscribe to.
	 *
	 * @returns: void
	 *
	 * @example: mqttConnection.subscribe('topic');
	 * @example: mqttConnection.subscribe('topic/with/slashes');
	 * @example: mqttConnection.subscribe('topic/with/slashes/#');
	 * @example: mqttConnection.subscribe('topic/with/slashes/+');
	 */
	public subscribe(topic: string) {
		this.mqttClient.subscribe(topic);
	}

	/**
	 * @description: This will publish a message to a topic.
	 *
	 * @param topic: The topic to publish to.
	 * @param message: The message to publish.
	 *
	 * @returns: void
	 *
	 * @example: mqttConnection.publish('topic', 'message');
	 * @example: mqttConnection.publish('topic/with/slashes', 'message');
	 * @example: mqttConnection.publish('topic/with/slashes/#', 'message');
	 * @example: mqttConnection.publish('topic/with/slashes/+', 'message');
	 */
	public publish(topic: string, message: string) {
		this.mqttClient.publish(topic, message);
	}

	/**
	 * @description: This will register a callback for when a message is received.
	 *
	 * @param callback: The callback to register. Must have two parameters: topic and message.
	 *
	 * @returns: void
	 *
	 * @example: mqttConnection.onMessage((topic, message) => {
	 * 	console.log(`Received message on topic ${topic}: ${message}`);
	 * });
	 */
	public onMessage(handler: IHandler) {
		this.mqttClient.on('message', (topic, message) => {
			handler.handleEvent(topic, message.toString());
		});
	}

	/**
	 * @description: This will register a callback for when the connection is established.
	 *
	 * @param callback: The callback to register.
	 *
	 * @returns: void
	 *
	 * @example: mqttConnection.onConnect(() => {
	 * 	console.log('Connected to MQTT server.');
	 * });
	 */
	public onConnect(handler: IHandler) {
		this.mqttClient.on('connect', () => {
			handler.handleEvent();
		});
	}

	/**
	 * @description: This will register a callback for when the connection is lost.
	 *
	 * @param callback: The callback to register.
	 *
	 * @returns: void
	 *
	 * @example: mqttConnection.onDisconnect(() => {
	 * 	console.log('Disconnected from MQTT server.');
	 * });
	 */
	public onDisconnect(handler: IHandler) {
		this.mqttClient.on('disconnect', () => {
			handler.handleEvent();
		});
	}

	/**
	 * @description: This will register a callback for when an error occurs.
	 *
	 * @param callback: The callback to register. Must have one parameter: error.
	 *
	 * @returns: void
	 *
	 * @example: mqttConnection.onError((error) => {
	 * 	console.log(`An error occurred: ${error}`);
	 * });
	 */
	public onError(handler: IHandler) {
		this.mqttClient.on('error', (error) => {
			// The 2 undefined are for the 2 optional parameters that are not present in the error state.
			handler.handleEvent(undefined, undefined, error);
		});
	}
}
