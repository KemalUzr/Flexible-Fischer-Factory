/**=========================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  24-03-2023
 * @description    :  This script is to use as a template for all scripts.
 *==========================================================================================================*/

using UnityEngine;

namespace FlexibleFischerFactory.Core {
	public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour {
		// This is the instance of the object.
		public static T Instance { get; private set; }

		/**==============================================
		 **                    Awake
		 *?  This function is called when the object is
		 *?  instantiated. It will set the instance to
		 *?  this object.
		 *
		 *@return void
		 *=============================================**/
		protected virtual void Awake() => Instance = this as T;

		/**==============================================
		 **              OnApplicationQuit
		 *?  This function is called when the application
		 *?  is quit. It will set the instance to null
		 *?  and destroy this object.
		 *
		 *@return void
		 *=============================================**/
		protected virtual void OnApplicationQuit() {
			Instance = null;
			Destroy(gameObject);
		}
	}
}
