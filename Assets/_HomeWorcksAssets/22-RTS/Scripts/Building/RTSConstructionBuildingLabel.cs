using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(RTSBuilding))]
    public class RTSConstructionBuildingLabel : MonoBehaviour
    {
        [SerializeField] private Vector2Int _size = Vector2Int.one;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Transform _slabsParent;

        [SerializeField] private float _riseGrid = 1f;

        [SerializeField] private Color _availableColor = Color.green;
        [SerializeField] private Color _notAvailableColor = Color.red;

        private Color _defaultColor = Color.white;

        private List<RTSBuildingObjectLock> _builds = new List<RTSBuildingObjectLock>();

        public Vector2Int Size => _size;

        public bool IsAvailable() => _builds.Count == 0;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out RTSBuildingObjectLock build))
                _builds.Add(build);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out RTSBuildingObjectLock build))
                _builds.Remove(build);
        }

        private void OnDrawGizmos()
        {
            for (int x = 0; x < Size.x; x++)
            {
                for (int y = 0; y < Size.y; y++)
                {
                    if ((x + y) % 2 == 0) Gizmos.color = _availableColor;
                    else Gizmos.color = _notAvailableColor;

                    Gizmos.DrawCube(transform.position + new Vector3(x * _riseGrid, 0, y * _riseGrid), new Vector3(1 * _riseGrid, .1f, 1 * _riseGrid));
                }
            }
        }

        public void Build(RTSGameStats stats)
        {
            SetDefaultColor();
            GetComponent<RTSBuilding>().Init(stats);
        }

        public void SetAvaliableColor(bool available)
        {
            if (available)
            {
                _renderer.material.color = _availableColor;
                SetAvaliableSlabsColor(_availableColor);
            }
            else
            {
                _renderer.material.color = _notAvailableColor;
                SetAvaliableSlabsColor(_notAvailableColor);
            }
        }

        public void SetDefaultColor()
        {
            _renderer.material.color = _defaultColor;
            SetAvaliableSlabsColor(_defaultColor);
        }

        private void SetAvaliableSlabsColor(Color color)
        {
            for (int i = 0; i < _slabsParent.childCount; i++)
            {
                _slabsParent.GetChild(i).GetComponent<Renderer>().material.color = color;
            }
        }
    }
}
