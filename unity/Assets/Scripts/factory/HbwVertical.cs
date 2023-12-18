/**=========================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  22-03-2023
 * @description    :  This script will controll the vertical Hbw.
 *==========================================================================================================*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using FlexibleFischerFactory.Core;

namespace FlexibleFischerFactory.Factory {
	public class HbwVertical : MonoBehaviour {
		[SerializeField] private PLCCommS7 _s7Comm;

		private const float _maxPosition = 127f;
		private const int _maxEncoder = 3250;

		private const float _mmPerEncoder = _maxPosition / _maxEncoder;

		void Update() {
			float verPos = _s7Comm.plcHbwVerticalEncoder * _mmPerEncoder;
			transform.localPosition = new Vector3(7.5f, 240f-verPos, -29.5f);
		}
	}
}
