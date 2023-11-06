using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class RTSMousePoint : MonoBehaviour
    {
        [SerializeField] private RTSUIBuildingProducts _uiProducts;
        [SerializeField] private LayerMask _layerMask;

        private Camera _mainCamera;
        private RTSBuilding _currentBuilding;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
                {
                    if(hit.collider.TryGetComponent(out RTSBuilding building))
                    {
                        if (building.IsActive == false)
                            return;

                        _uiProducts.Show(building);
                    }
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                _uiProducts.Hide();
            }
        }
    }
}
