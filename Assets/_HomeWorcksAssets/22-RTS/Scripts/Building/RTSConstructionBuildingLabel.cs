using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(RTSBuilding))]
    public class RTSConstructionBuildingLabel : MonoBehaviour
    {
        [SerializeField] private Vector2Int _size = Vector2Int.one;
        [SerializeField] private Renderer[] _renderer;

        [SerializeField] private float _riseGrid = 1f;

        [SerializeField] private Color _availableColor = Color.green;
        [SerializeField] private Color _notAvailableColor = Color.red;
        [SerializeField] private Color _labelColor = Color.yellow;
        public Vector2Int Size => _size;
        public bool IsNeedBuild { get; private set; }
        public bool HasSlave { get; private set; }
        public bool IsAvailable() => _builds.Count == 0;

        private Color _defaultColor = Color.white;
        private List<RTSBuildingObjectLock> _builds = new List<RTSBuildingObjectLock>();

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

        public void SetReservation()
        {
            HasSlave = true;
        }

        public void ToBuild()
        {
            SetColor(_defaultColor);
            GetComponent<RTSBuilding>().Init();
        }

        public void SetLabel()
        {
            IsNeedBuild = true;
            SetColor(_labelColor);
        }

        public void SetAvaliableColor(bool available)
        {
            if (available)
                SetColor(_availableColor);
            else
                SetColor(_notAvailableColor);
        }

        private void SetColor(Color color)
        {
            if (_renderer == null)
                return;

            foreach (Renderer render in _renderer)
            {
                render.material.color = color;
            }
        }
    }
}
