using UnityEngine;
using UnityEngine.AI;

namespace RTS
{
    public class RTSConstructionBuilding : MonoBehaviour
    {
        [SerializeField] private float _buildDistance = 70f;

        private RTSConstructionBuildingLabel _currentBuilding;
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (_currentBuilding != null)
            {
                var groundPlane = new Plane(Vector3.up, Vector3.zero);
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (groundPlane.Raycast(ray, out float position))
                {
                    Vector3 worldPosition = ray.GetPoint(position);

                    int x = Mathf.RoundToInt(worldPosition.x);
                    int y = Mathf.RoundToInt(worldPosition.z);

                    bool available = true;

                    if (x < transform.position.x - _buildDistance || x > transform.position.x + _buildDistance)
                        available = false;
                    if (y < transform.position.z - _buildDistance || y > transform.position.z + _buildDistance)
                        available = false;

                    if (_currentBuilding.IsAvailable() == false) 
                        available = false;

                    _currentBuilding.transform.position = new Vector3(x, 0, y);
                    _currentBuilding.SetAvaliableColor(available);

                    if (available && Input.GetMouseButtonDown(0))
                    {
                        _currentBuilding.ToBuild();
                        _currentBuilding = null;
                    }

                    if (Input.GetMouseButton(1))
                    {
                        Destroy(_currentBuilding.gameObject);
                    }
                }
            }
        }

        public void StartPlacingBuilding(RTSConstructionBuildingLabel buildingPrefab)
        {
            if (_currentBuilding != null)
            {
                Destroy(_currentBuilding.gameObject);
            }

            _currentBuilding = Instantiate(buildingPrefab);
        }
    }
}
