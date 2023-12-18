/**=========================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  22-03-2023
 * @description    :  This script will controll the Vgr product colors.
 *==========================================================================================================*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using FlexibleFischerFactory.Core;

namespace FlexibleFischerFactory.Factory {
	public class VgrProductColor : MonoBehaviour {
		[SerializeField] private Material _redMaterial;
		[SerializeField] private Material _blueMaterial;
		[SerializeField] private Material _whiteMaterial;
		[SerializeField] private Material _unknownMaterial;

		[SerializeField] private PLCCommS7 _s7;

		[SerializeField] private GameObject _productRef;

		// Update is called once per frame
		void Update() {
			_productRef.SetActive(true);
			switch (_s7.plcVgrProductColor) {
				case 1:
					_productRef.GetComponent<Renderer>().material = _whiteMaterial;
					break;
				case 2:
					_productRef.GetComponent<Renderer>().material = _redMaterial;
					break;
				case 3:
					_productRef.GetComponent<Renderer>().material = _blueMaterial;
					break;
				case 4:
					_productRef.GetComponent<Renderer>().material = _unknownMaterial;
					break;
				default:
					_productRef.SetActive(false);
					break;
			}
		}
	}
}
