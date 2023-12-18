/*------------------------------------------------------------------------------------------------
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  05-04-2023
 * @description    :  An interface which all the mqtt events will use.
 *------------------------------------------------------------------------------------------------*/

export interface IHandler {
	handleEvent(topic?: string, message?: string, error?: Error): void;
}
