/**=========================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  22-03-2023
 * @description    :  This script will controll the vertical Vgr.
 *==========================================================================================================*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using FlexibleFischerFactory.Core;

namespace FlexibleFischerFactory.Factory {
	public class VgrVertical : MonoBehaviour {
		[SerializeField] private PLCCommS7 _s7Comm;

		//The Internal variables:
		//In mm

		private const float _posMax = 120f;
		//The maximum encodercount
		private const int _encoderMax = 3100;

		private const float _mmPerEncoder = _posMax / _encoderMax;

		void Update() {
			float verPos = _s7Comm.plcVgrVerticalEncoder * _mmPerEncoder;

			//Move the model
			transform.localPosition = new Vector3(-22.5f, 222.5f - verPos, 0.0f);
		}
	}
}
