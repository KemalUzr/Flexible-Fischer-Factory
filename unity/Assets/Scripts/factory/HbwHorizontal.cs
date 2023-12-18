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
	public class HbwHorizontal : MonoBehaviour {
		[SerializeField] private PLCCommS7 _s7Comm;

		private const float _maxPosition = 296f;
		private const int _maxEncoder = 7560;

		private const float _mmPerEncoder = _maxPosition / _maxEncoder;

		void Update() {
			float horPos = _s7Comm.plcHbwHorizontalEncoder * _mmPerEncoder;
			transform.localPosition = new Vector3(212.0f, 20.0f, -horPos -18.5f);
		}
	}
}
