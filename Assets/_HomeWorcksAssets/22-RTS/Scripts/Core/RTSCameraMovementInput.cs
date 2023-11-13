using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class RTSCameraMovementInput : MonoBehaviour
    {
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";
        private const string MouseScrollWheelInput = "Mouse ScrollWheel";

        [SerializeField] private float _moveSpeed = 15f;
        [SerializeField] private float _zoomSpeed = 15f;
        [SerializeField] private float _minZoom = 20f;
        [SerializeField] private float _maxZoom = 60f;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Move();
            Zoom();
        }

        private void Move()
        {
            float x = Input.GetAxis(HorizontalInput);
            float z = Input.GetAxis(VerticalInput);

            Vector3 direction = transform.forward * z + transform.right * x;
            direction.y = 0;
            direction.Normalize();

            transform.position += direction * _moveSpeed * Time.deltaTime;
        }

        private void Zoom()
        {
            float scrollInput = Input.GetAxis(MouseScrollWheelInput);

            float newSize = _camera.fieldOfView - scrollInput * _zoomSpeed;
            _camera.fieldOfView = Mathf.Clamp(newSize, _minZoom, _maxZoom);
        }
    }
}
