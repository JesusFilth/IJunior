using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class RTSMousePoint : MonoBehaviour
    {
        [SerializeField] private RTSUIBuildingProducts _uiProducts;

        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Debug.Log(hit.collider.gameObject.name);

                    if(hit.collider.TryGetComponent(out RTSBuilding building))
                    {
                        _uiProducts.Show(building);
                    }
                    else
                    {
                        //_uiProducts.Hide();
                    }
                }
            }
        }
    }
}
