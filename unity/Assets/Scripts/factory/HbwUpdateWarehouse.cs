/**=========================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  22-03-2023
 * @description    :  This script will controll the horizontal Hbw.
 *==========================================================================================================*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using FlexibleFischerFactory.Core;

namespace FlexibleFischerFactory.Factory {
	public class HbwUpdateWarehouse : MonoBehaviour {
		[SerializeField] private PLCCommS7 _s7Comm;

		[SerializeField] private List<GameObject> _products;

		[SerializeField] private Material _redMaterial;
		[SerializeField] private Material _blueMaterial;
		[SerializeField] private Material _whiteMaterial;

		private void setProduct(GameObject product, byte color) {
			product.SetActive(true);

			// TODO: Optimise the call to GetComponent<Renderer>(). This is a heavy call for the engine.
			switch (color) {
				case 1:
					product.GetComponent<Renderer>().material = _whiteMaterial;
					break;
				case 2:
					product.GetComponent<Renderer>().material = _redMaterial;
					break;
				case 3:
					product.GetComponent<Renderer>().material = _blueMaterial;
					break;
				default:
					product.SetActive(false);
					break;
			}
		}

		void Update() {
			setProduct(_products[0], _s7Comm.plcHbwProduct1Color);
			setProduct(_products[1], _s7Comm.plcHbwProduct2Color);
			setProduct(_products[2], _s7Comm.plcHbwProduct3Color);
			setProduct(_products[3], _s7Comm.plcHbwProduct4Color);
			setProduct(_products[4], _s7Comm.plcHbwProduct5Color);
			setProduct(_products[5], _s7Comm.plcHbwProduct6Color);
			setProduct(_products[6], _s7Comm.plcHbwProduct7Color);
			setProduct(_products[7], _s7Comm.plcHbwProduct8Color);
			setProduct(_products[8], _s7Comm.plcHbwProduct9Color);
		}
	}
}
