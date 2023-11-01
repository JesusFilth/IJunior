using UnityEngine;
using UnityEngine.AI;

namespace RTS
{
    public class RTSBuildingGrid : MonoBehaviour
    {
        [SerializeField] private Transform _startGridPosition;
        [SerializeField] private Transform _endGridPosition;
        [Space]
        [SerializeField] private RTSGameStats _gameStats;

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

                    if (x < _startGridPosition.position.x || x > _endGridPosition.position.x - _currentBuilding.Size.x) 
                        available = false;
                    if (y < _startGridPosition.position.z || y > _endGridPosition.position.z - _currentBuilding.Size.y) 
                        available = false;

                    if (_currentBuilding.IsAvailable() == false) 
                        available = false;

                    _currentBuilding.transform.position = new Vector3(x, 0, y);
                    _currentBuilding.SetAvaliableColor(available);

                    if (available && Input.GetMouseButtonDown(0))
                    {
                        _currentBuilding.Build(_gameStats);
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
