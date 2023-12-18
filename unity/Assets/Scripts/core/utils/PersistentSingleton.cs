/**------------------------------------------------------------------------------------------------
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  24-03-2023
 * @description    :  This script is used to inherit as a singleton and dont destroy on scene load.
 *------------------------------------------------------------------------------------------------**/

using UnityEngine;

namespace FlexibleFischerFactory.Core {
	public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour {
		/**==============================================
		 **                     Awake
		 *?  This function is called when the object is
		 *?  instantiated. It will call the base class
		 *?  Awake which is Singleton.
		 *
		 *@return void
		 *=============================================**/
		protected override void Awake() {
			base.Awake();
			DontDestroyOnLoad(gameObject);
		}
	}
}
