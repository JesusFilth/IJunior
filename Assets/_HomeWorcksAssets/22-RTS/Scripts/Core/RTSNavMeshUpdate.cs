using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RTS
{
    public class RTSNavMeshUpdate : MonoBehaviour
    {
        [SerializeField] private NavMeshSurface _navMesh;
        [SerializeField] private NavMeshData _data;

        public void ToUpdate()
        {
            _navMesh.UpdateNavMesh(_data);
        }
    }
}
