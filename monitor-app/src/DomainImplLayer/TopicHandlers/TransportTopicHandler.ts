import { BaseTopicHandler } from "./BaseTopicHandler";

export class TransportTopicHandler extends BaseTopicHandler {
	private startTime: Date = new Date();
	private lastState = false;

	public handleTopic(data: string): void {
		const json = JSON.parse(data);

		const state = json.onTransportBelt;

		// If the state is the same as the last state the sensor was not triggered again.
		if(state == this.lastState) {
			return;
		}

		this.lastState = state;
		const time = Date.parse(json.tsTransportBelt);

		// If the time is not a valid date we can not handle the event.
		if(isNaN(time)) {
			console.error('Invalid time received from transport belt');
			return;
		}

		if(state) {
			this.startTime = new Date(time);

			// The handling of the event is over so we can exit the function.
			return;
		}

		if(!state) {
			const endTime = new Date(time);
			const timeDiff = endTime.getTime() - this.startTime.getTime();

			// Publish the time the workpiece was on the transport belt.
			this.client.publish('transport/time', timeDiff.toString());

			const data = {
				"start": this.startTime,
				"end": endTime,
				"time": timeDiff
			};

			// Store the data
			// Its expected that the data is valid JSON; this is not checked.
			this.storagePlaces.forEach(storage => {
				storage.store(JSON.stringify(data));
			});
		}
	}
}
