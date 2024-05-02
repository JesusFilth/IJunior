using UnityEngine;

namespace Assets._HomeWorcksAssets.CubesRain.Scripts
{
    public class CubeRainChangeColor : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CubeRain cube))
                cube.GenerateRandomColor();
        }
    }
}
