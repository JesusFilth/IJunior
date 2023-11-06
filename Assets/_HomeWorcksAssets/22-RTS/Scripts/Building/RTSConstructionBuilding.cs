using UnityEngine;
using UnityEngine.AI;

namespace RTS
{
    [RequireComponent(typeof(RTSMainBase))]
    public class RTSConstructionBuilding : MonoBehaviour
    {
        [SerializeField] private float _buildRadiusDistance = 70f;

        private Camera _mainCamera;
        private RTSMainBase _mainBase;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _mainBase = GetComponent<RTSMainBase>();
        }

        private void Update()
        {
            if (_mainBase.LabelBuildBuilding != null && _mainBase.LabelBuildBuilding.IsNeedBuild == false)
            {
                var groundPlane = new Plane(Vector3.up, Vector3.zero);
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (groundPlane.Raycast(ray, out float position))
                {
                    Vector3 worldPosition = ray.GetPoint(position);

                    int x = Mathf.RoundToInt(worldPosition.x);
                    int y = Mathf.RoundToInt(worldPosition.z);

                    bool available = true;

                    if (x < transform.position.x - _buildRadiusDistance || x > transform.position.x + _buildRadiusDistance)
                        available = false;
                    if (y < transform.position.z - _buildRadiusDistance || y > transform.position.z + _buildRadiusDistance)
                        available = false;

                    if (_mainBase.LabelBuildBuilding.IsAvailable() == false)
                        available = false;

                    _mainBase.LabelBuildBuilding.transform.position = new Vector3(x, 0, y);
                    _mainBase.LabelBuildBuilding.SetAvaliableColor(available);

                    if (available && Input.GetMouseButtonDown(0))
                    {
                        _mainBase.SetBuildLabel();
                    }

                    if (Input.GetMouseButton(1))
                    {
                        _mainBase.ResetLabelBuilding();
                    }
                }
            }
        }

        public void StartPlacingBuilding(RTSBuildingPrefabKeeper keeper)
        {
            RTSConstructionBuildingLabel prefabLabel = keeper.GetPrefab();

            _mainBase.ResetLabelBuilding();

            _mainBase.SetLabelBuildBuilding(Instantiate(prefabLabel));
        }
    }
}
