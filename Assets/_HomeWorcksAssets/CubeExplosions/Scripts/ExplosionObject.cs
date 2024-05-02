using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._HomeWorcksAssets.CubeExplosions.Scripts
{
    public class ExplosionObject
    {
        private const int MaxPercent = 100;

        private IExposion _exposion;

        public ExplosionObject(IExposion exposion) 
        {
            if(exposion == null)
                throw new ArgumentNullException(nameof(exposion));

            _exposion = exposion;
        }

        public void ExplodeModified()
        {
            float modifiedRadius = GetModifiedRadius();
            float modifiedForce = GetModifiedForce();

            foreach (Rigidbody explodableObject in GetExplodableObjects())
            {
                float force = GetForceFromDistanceObject(explodableObject.transform, modifiedForce);
                explodableObject.AddExplosionForce(force, _exposion.GetPoint(), modifiedRadius, 1f, ForceMode.Impulse);
            }
        }

        public void ExplodeSimple(Rigidbody rigidbody)
        {
            if (rigidbody == null)
                throw new ArgumentNullException(nameof(rigidbody));

            rigidbody.AddExplosionForce(_exposion.GetForce(), _exposion.GetPoint(), _exposion.GetRadius());
        }

        private List<Rigidbody> GetExplodableObjects()
        {
            Collider[] hits = Physics.OverlapSphere(_exposion.GetPoint(), _exposion.GetRadius());

            List<Rigidbody> objects = new List<Rigidbody>();

            foreach (Collider hit in hits)
            {
                if (hit.attachedRigidbody != null)
                    objects.Add(hit.attachedRigidbody);
            }

            return objects;
        }

        private float GetForceFromDistanceObject(Transform objectPosition, float initialForce)
        {
            float distance = Vector3.Distance(_exposion.GetPoint(), objectPosition.position);
            return initialForce * (1f - distance / _exposion.GetRadius());
        }

        private float GetModifiedRadius()
        {
            return (MaxPercent / _exposion.GetSeparation()) * _exposion.GetRadius();
        }

        private float GetModifiedForce()
        {
            return (MaxPercent / _exposion.GetSeparation()) * _exposion.GetForce();
        }
    }
}
