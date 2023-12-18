/**=========================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  22-03-2023
 * @description    :  This script will controll the Vgr rotation.
 *==========================================================================================================*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using FlexibleFischerFactory.Core;

namespace FlexibleFischerFactory.Factory {
	public class VgrRotate : MonoBehaviour {
		[SerializeField] private PLCCommS7 _s7Comm;

		//The Internal variables:
		//In degrees

		private const float _maxAngle = 270f;
		//The maximum encodercount
		private const int _encoderMax = 5350;

		private const float _degreePerEncorder = _maxAngle / _encoderMax;

		void Update() {
			float rotAngle = _s7Comm.plcVgrRotateEncoder * _degreePerEncorder;

			//Rotate the model
			transform.rotation = Quaternion.AngleAxis(rotAngle, Vector3.down);
		}
	}
}
