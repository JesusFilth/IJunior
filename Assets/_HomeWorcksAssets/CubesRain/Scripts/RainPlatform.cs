using UnityEngine;

namespace Assets._HomeWorcksAssets.CubesRain.Scripts
{
    public class RainPlatform : MonoBehaviour
    {
        [SerializeField] private float _height = 5;

        public Vector3 GetRandomPosition()
        {
            const float HalfSize = 2f;

            Vector3 platformCenter = transform.position;
            Vector3 platformSize = transform.localScale;

            float randomX = Random.Range(platformCenter.x - platformSize.x / HalfSize, platformCenter.x + platformSize.x / HalfSize);
            float randomZ = Random.Range(platformCenter.z - platformSize.z / HalfSize, platformCenter.z + platformSize.z / HalfSize);

            float height = platformCenter.y + _height;

            return new Vector3(randomX, height, randomZ);
        }
    }
}
