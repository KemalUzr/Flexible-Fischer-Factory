/*================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  29-03-2023
 * @description    :  This is the starting point of the application.
 *================================================================================================*/

import { Application } from "./PresentationLayer/Application";

function main(): void {
	const app = new Application();

	app.run();
}

main();
