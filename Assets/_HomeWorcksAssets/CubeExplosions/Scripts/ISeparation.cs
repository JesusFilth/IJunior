
using UnityEngine;

namespace Assets._HomeWorcksAssets.CubeExplosions.Scripts
{
    public interface ISeparation
    {
        void SetSeporationChance(float chance);

        void SetColor(Color32 color);

        void SetScale(Vector3 scale);
    }
}
