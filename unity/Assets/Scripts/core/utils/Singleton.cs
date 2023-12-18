/**================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  24-03-2023
 * @description    :  This script is used to inherit as a singleton.
 *================================================================================================**/

using UnityEngine;

namespace FlexibleFischerFactory.Core {
	public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour {
		/**==============================================
		 **                     Awake
		 *?  This function is called when the object is
		 *?  instantiated. It will check if there is
		 *?  already an instance of this object. If so
		 *?  it will destroy this object. If not it will
		 *?  call the base class Awake which is
		 *?  StaticInstance.
		 *
		 *@return void
		 *=============================================**/
		protected override void Awake() {
			if (Instance != null) {
				Destroy(gameObject);
				return;
			}

			base.Awake();
		}
	}
}
