/**=========================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  22-03-2023
 * @description    :  This script will controll the HbwBelt.
 *==========================================================================================================*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using FlexibleFischerFactory.Core;

namespace FlexibleFischerFactory.Factory {
	public class HbwBelt : MonoBehaviour {
		public List<GameObject> containList;
		public float beltPos;

		[SerializeField] private PLCCommS7 _s7Comm;
		[SerializeField] private GameObject _gripper;

		// The Internal variables:
		private float _currentTime;
		private float _startTime;
		private Vector3 _tempPos;

		/*
		 * Update is called once per frame
		 */
		void Update() {
			if (_s7Comm.plcHbwProductBind <= 0) {
				return;
			}

			GameObject gameObj = containList[_s7Comm.plcHbwProductBind - 1];

			_currentTime = Time.time;

			if (!_s7Comm.plcHbwBeltPosIn) {
				_startTime = 0;
				_tempPos = gameObj.transform.localPosition;
			} else if (!_s7Comm.plcHbwBeltPosOut) {
				_startTime = 0;
				_tempPos = new Vector3(10, gameObj.transform.localPosition.y, gameObj.transform.localPosition.z);
			} else {
				if (_startTime == 0) {
					_startTime = Time.time;
				}

				float deltaTime = _currentTime - _startTime;
				float speed = (125f / 0.33f) / 1000f * _s7Comm.plcHbwBeltPwm;
				beltPos = deltaTime * speed;

				// These values are to optimise the if statements below.
				float tempBeltPos = beltPos;
				float lockedPos = gameObj.transform.localPosition.x;

				if (_s7Comm.plcHbwBeltForward) {
					tempBeltPos *= -1;

					if (gameObj.transform.localPosition.x < 10) {
						lockedPos = 10f;
					}
				}

				if (_s7Comm.plcHbwBeltBackward && gameObj.transform.localPosition.x > 110) {
					lockedPos = 110f;
				}

				gameObj.transform.localPosition = _tempPos + new Vector3(tempBeltPos, 0f, 0f);
				gameObj.transform.localPosition = new Vector3(lockedPos, gameObj.transform.localPosition.y, gameObj.transform.localPosition.z);
			}
		}
	}
}
