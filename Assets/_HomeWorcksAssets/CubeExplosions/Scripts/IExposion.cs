using UnityEngine;

namespace Assets._HomeWorcksAssets.CubeExplosions.Scripts
{
    public interface IExposion
    {
        Vector3 GetPoint();

        float GetRadius();

        float GetForce();

        float GetSeparation();
    }
}
