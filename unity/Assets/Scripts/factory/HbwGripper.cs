/**=========================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  22-03-2023
 * @description    :  This script will controll the HbwGripper.
 *==========================================================================================================*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using FlexibleFischerFactory.Core;

namespace FlexibleFischerFactory.Factory {
	public class HbwGripper : MonoBehaviour {
		public float gripPosistion;

		[SerializeField] private PLCCommS7 _s7Comm;
		[SerializeField] private List<GameObject> _contains;

		private float _currentTime;
		private float _startTime;

		private const float _maxPosition = 120f;
		private const int _maxEncoder = 3100;

		private const float _mmPerEncoder = _maxPosition / _maxEncoder;

		void Update() {
			_currentTime = Time.time;

			if (_s7Comm.plcHbwGripperPosIn) {
				transform.localPosition = new Vector3(75.0f, -31.25f, -35.0f);
				_startTime = 0;
			} else if (_s7Comm.plcHbwGripperPosOut) {
				transform.localPosition = new Vector3(75.0f - 40f, -31.25f, -35.0f);
				_startTime = 0;
			} else {
				if (_startTime == 0) {
					_startTime = Time.time;
				}

				float deltaTime = _currentTime - _startTime;
				float speed = _mmPerEncoder / 1000f * _s7Comm.plcHbwGripperPwm;
				gripPosistion = deltaTime * speed;

				if (_s7Comm.plcHbwGripperForward) {
					transform.localPosition = new Vector3(75.0f - gripPosistion, -31.25f, -35.0f);
				}

				if (_s7Comm.plcHbwGripperBackward) {
					transform.localPosition = new Vector3(75.0f - 40f + gripPosistion, -31.25f, -35.0f);
				}
			}

			if (_s7Comm.plcHbwProductBind != 0 && !_s7Comm.plcHbwBeltForward && !_s7Comm.plcHbwBeltBackward && _s7Comm.plcHbwBeltPosIn && _s7Comm.plcHbwBeltPosOut) {
				_contains[_s7Comm.plcHbwProductBind - 1].transform.position = transform.position + new Vector3(-145f, -7f, -17f);
			} else if (!_s7Comm.plcHbwBeltForward && !_s7Comm.plcHbwBeltBackward && _s7Comm.plcHbwBeltPosIn && _s7Comm.plcHbwBeltPosOut) {
				_contains[0].transform.localPosition = new Vector3(107.0f, 210.5f, -213.5f);
				_contains[1].transform.localPosition = new Vector3(107.0f, 157.0f, -213.5f);
				_contains[2].transform.localPosition = new Vector3(107.0f, 97.0f, -213.5f);
				_contains[3].transform.localPosition = new Vector3(107.0f, 210.5f, -303.5f);
				_contains[4].transform.localPosition = new Vector3(107.0f, 157.0f, -303.5f);
				_contains[5].transform.localPosition = new Vector3(107.0f, 97.0f, -303.5f);
				_contains[6].transform.localPosition = new Vector3(107.0f, 210.5f, -393.5f);
				_contains[7].transform.localPosition = new Vector3(107.0f, 157.0f, -393.5f);
				_contains[8].transform.localPosition = new Vector3(107.0f, 97.0f, -393.5f);
			}
		}
	}
}
