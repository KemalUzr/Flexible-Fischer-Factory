/**=========================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  22-03-2023
 * @description    :  This script will controll the Vgr gripper.
 *==========================================================================================================*/

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using FlexibleFischerFactory.Core;

namespace FlexibleFischerFactory.Factory {
	public class VgrGripper : MonoBehaviour {
		[SerializeField] private PLCCommS7 _s7Comm;
		[SerializeField] private GameObject _staticGripper;

		void Update() {

			float clamped = 0f;

			if (_s7Comm.plcVgrRotateEncoder > 5000) {
				clamped = Mathf.Max(_staticGripper.transform.position.y, 260f);
			} else if (_s7Comm.plcVgrRotateEncoder > 1900) {
				clamped = Mathf.Max(_staticGripper.transform.position.y, 190f);
			} else if (_s7Comm.plcVgrRotateEncoder > 1000) {
				clamped = Mathf.Max(_staticGripper.transform.position.y, 158f);
			} else if (_s7Comm.plcVgrRotateEncoder > 800) {
				clamped = Mathf.Max(_staticGripper.transform.position.y, 208f);
			} else if (_s7Comm.plcVgrRotateEncoder > 150) {
				clamped = Mathf.Max(_staticGripper.transform.position.y, 182f);
			} else if (_s7Comm.plcVgrRotateEncoder > 0) {
				clamped = Mathf.Max(_staticGripper.transform.position.y, 165f);
			}

			transform.position = new Vector3(_staticGripper.transform.position.x, clamped, _staticGripper.transform.position.z);
		}
	}
}
