using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class RTSCameraMovement : MonoBehaviour
    {
        [SerializeField] private float scrollSpeed = 3.0f;

        private void Update()
        {
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;

            Vector3 direction = new Vector3();

            if (mouseX > screenWidth * 0.95f)
            {
                direction += transform.right;
            }
            else if (mouseX < screenWidth * 0.05f)
            {
                direction -= transform.right;
            }

            if (mouseY > screenHeight * 0.95f)
            {
                direction += Vector3.left;
            }
            else if (mouseY < screenHeight * 0.05f)
            {
                direction -= Vector3.left;
            }

            direction.Normalize();
            transform.position += direction * scrollSpeed * Time.deltaTime;
        }
    }
}
