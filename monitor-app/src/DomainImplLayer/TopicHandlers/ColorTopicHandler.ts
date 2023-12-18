import { BaseTopicHandler } from "./BaseTopicHandler";

export class ColorTopicHandler extends BaseTopicHandler {
	//private previousData : string | null = null;
	private lastState = false;

	public handleTopic(data: string): void {
		const json = JSON.parse(data);
		//const time = Date.parse(json.tsColor);
		const state = json.colorObserved;
		const color = json.observedColor;

		//if state goes from true to false, color can be read
		if( state && !this.lastState){
			this.client.publish('detected/color', color);
		}
		this.lastState = state;
	}
	
}
