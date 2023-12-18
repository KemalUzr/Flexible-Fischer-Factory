/**=========================================================================================================
 * ?                                           ABOUT
 * @author         :  Noah Knegt
 * @email          :  personal@noahknegt.com
 * @repo           :  https://github.com/RemanufacturingLab-StudentTeams/FlexibleFischerFactory
 * @createdOn      :  15-03-2023
 * @description    :  This script is to control the camera in the game.
 *==========================================================================================================*/

using System.Collections;

using UnityEngine;

namespace FlexibleFischerFactory.Core {
    public class CameraController : Singleton<CameraController> {
        [SerializeField] private float _normalSpeed = 100.0f; // Normal movement speed
        [SerializeField] private float _shiftSpeed = 540.0f; // Speed multiplier when shift is held down
        [SerializeField] private float _speedCap = 540.0f; // Cap for speed when shift is held down
        [SerializeField] private float _cameraSensitivity = 0.2f; // How sensitive is the camera to mouse movement

        private Vector3 _mouseLocation = new Vector3(255, 255, 255); // Mouse location on screen during play (Set to near the middle of the screen)
        private float _totalSpeed = 100.0f; // Total speed variable for shift

        /*
         * This is called once per frame
         * This is inherited from the MonoBehaviour class
         */
        void Update() {
            if (Input.GetKey(KeyCode.Tab)) {
                // Camera angles based on mouse position
                _mouseLocation = Input.mousePosition - _mouseLocation;
                _mouseLocation = new Vector3(-_mouseLocation.y * _cameraSensitivity, _mouseLocation.x * _cameraSensitivity, 0);
                _mouseLocation = new Vector3(transform.eulerAngles.x + _mouseLocation.x, transform.eulerAngles.y + _mouseLocation.y, 0);
                transform.eulerAngles = _mouseLocation;
                _mouseLocation = Input.mousePosition;

                // Keyboard controls
                Vector3 cameraVelocity = GetBaseInput();
                if (Input.GetKey(KeyCode.LeftShift)) {
                    _totalSpeed += Time.deltaTime;
                    cameraVelocity *= _totalSpeed * _shiftSpeed;
                    cameraVelocity.x = Mathf.Clamp(cameraVelocity.x, -_speedCap, _speedCap);
                    cameraVelocity.y = Mathf.Clamp(cameraVelocity.y, -_speedCap, _speedCap);
                    cameraVelocity.z = Mathf.Clamp(cameraVelocity.z, -_speedCap, _speedCap);
                } else {
                    _totalSpeed = Mathf.Clamp(_totalSpeed * 0.5f, 1f, 1000f);
                    cameraVelocity *= _normalSpeed;
                }

                cameraVelocity *= Time.deltaTime;
                Vector3 newPosition = transform.position;
                if (Input.GetKey(KeyCode.Space)) {
                    // If the player wants to move on X and Z axis only by pressing space (good for re-adjusting angle shots)
                    transform.Translate(cameraVelocity);
                    newPosition.x = transform.position.x;
                    newPosition.z = transform.position.z;
                    transform.position = newPosition;
                } else {
                    transform.Translate(cameraVelocity);
                }
            }
        }

        private Vector3 GetBaseInput() {
            float horizontalInput = Input.GetAxis("Horizontal"); // Input for horizontal movement
            float verticalInput = Input.GetAxis("Vertical"); // Input for Vertical movement

            return new Vector3(horizontalInput, 0, verticalInput);
        }
    }
}
