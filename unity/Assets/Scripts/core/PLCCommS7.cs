/**=========================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  15-03-2023
 * @description    :  This script will handle the communication with the PLC.
 *==========================================================================================================*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Sharp7;

namespace FlexibleFischerFactory.Core {
    public class PLCCommS7 : MonoBehaviour {
        [SerializeField] private string _resultaat = "";
        [SerializeField] private string _plcIp = "192.168.0.1";
        private S7Client _client;

		/*
		 * PLC variables from S7
		 */
		[Header("PLC variables")]
		[Header("HBW encoder")]
		public int plcHbwHorizontalEncoder;
		public int plcHbwVerticalEncoder;

		[Header("HBW gripper")]
		public bool plcHbwGripperPosIn;
		public bool plcHbwGripperPosOut;
		public bool plcHbwGripperForward;
		public bool plcHbwGripperBackward;
		public int plcHbwGripperPwm;

		[Header("HBW belt")]
		public bool plcHbwBeltPosIn;
		public bool plcHbwBeltPosOut;
		public bool plcHbwBeltForward;
		public bool plcHbwBeltBackward;
		public int plcHbwBeltPwm;

		[Header("HBW product colors")]
		public byte plcHbwProduct1Color;
		public byte plcHbwProduct2Color;
		public byte plcHbwProduct3Color;
		public byte plcHbwProduct4Color;
		public byte plcHbwProduct5Color;
		public byte plcHbwProduct6Color;
		public byte plcHbwProduct7Color;
		public byte plcHbwProduct8Color;
		public byte plcHbwProduct9Color;

		public byte plcHbwProductBind = 0;

		public byte plcHbwProductInOutColor = 0;
		public bool plcHbwProductInOutToggle = false;

		[Header("Vacuum gripper robot")]
		public int plcVgrRotateEncoder;
		public int plcVgrHorizontalEncoder;
		public int plcVgrVerticalEncoder;

		public byte plcVgrProductColor;

		/*
		 * This function is called at the creation of the object.
		 * This is a function derived from Monobehaviour.
		 */
		void Awake() {
			_client = new S7Client();

			Connect();
		}

		/*
		 * This function is only called once per frame.
		 * From Monobehaviour.
		 */
		void Update() {
			byte[] db1Buffer = new byte[31];
			int result = _client.DBRead(45, 0, 31, db1Buffer);

			// If the read is unsuccessful, display the error and try to reconnect.
			if (result != 0) {
				Debug.LogWarning($"Error: {_client.ErrorText(result)}");
				_client.Disconnect();
				Connect();
			}

			plcHbwHorizontalEncoder = S7.GetIntAt(db1Buffer, 0);
			plcHbwVerticalEncoder = S7.GetIntAt(db1Buffer, 2);

			plcHbwGripperPosIn = S7.GetBitAt(db1Buffer, 4, 0);
			plcHbwGripperPosOut = S7.GetBitAt(db1Buffer, 4, 1);
			plcHbwGripperForward = S7.GetBitAt(db1Buffer, 4, 2);
			plcHbwGripperBackward = S7.GetBitAt(db1Buffer, 4, 3);
			plcHbwGripperPwm = S7.GetIntAt(db1Buffer, 6);

			plcHbwBeltPosIn = S7.GetBitAt(db1Buffer, 8, 0);
			plcHbwBeltPosOut = S7.GetBitAt(db1Buffer, 8, 1);
			plcHbwBeltForward = S7.GetBitAt(db1Buffer, 8, 2);
			plcHbwBeltBackward = S7.GetBitAt(db1Buffer, 8, 3);
			plcHbwBeltPwm = S7.GetIntAt(db1Buffer, 10);

			plcHbwProduct1Color = S7.GetByteAt(db1Buffer, 12);
			plcHbwProduct2Color = S7.GetByteAt(db1Buffer, 13);
			plcHbwProduct3Color = S7.GetByteAt(db1Buffer, 14);
			plcHbwProduct3Color = S7.GetByteAt(db1Buffer, 15);
			plcHbwProduct3Color = S7.GetByteAt(db1Buffer, 16);
			plcHbwProduct3Color = S7.GetByteAt(db1Buffer, 17);
			plcHbwProduct3Color = S7.GetByteAt(db1Buffer, 18);
			plcHbwProduct3Color = S7.GetByteAt(db1Buffer, 19);
			plcHbwProduct3Color = S7.GetByteAt(db1Buffer, 20);

			plcHbwProductBind = S7.GetByteAt(db1Buffer, 21);

			plcHbwProductInOutColor = S7.GetByteAt(db1Buffer, 22);
			plcHbwProductInOutToggle = S7.GetBitAt(db1Buffer, 23, 0);

			plcVgrRotateEncoder = S7.GetIntAt(db1Buffer, 24);
			plcVgrVerticalEncoder = S7.GetIntAt(db1Buffer, 26);
			plcVgrHorizontalEncoder = S7.GetIntAt(db1Buffer, 28);

			plcVgrProductColor = S7.GetByteAt(db1Buffer, 30);
		}


		// OnApplicationQuit is called after the last frame
		void OnApplicationQuit() {
			// Disconnect the client
			_client.Disconnect();
		}

		/*
		 * This will try to connect to the PLC.
		 */
		private int Connect() {
			int result = _client.ConnectTo(_plcIp, 0, 1);
			// If the connection errors
			if (result != 0) {
				_resultaat = _client.ErrorText(result);

				// Early return as the function ends at an error.
				return result;
			}

			_resultaat = $"Connected to {_plcIp}";

			return result;
		}
	}
}
