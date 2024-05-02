using System;
using UnityEngine;

namespace Assets._HomeWorcksAssets.CubeExplosions.Scripts
{
    public class CubeSeparation
    {
        private const int MaxPercent = 100;
        private float DecreaseChance = 2;

        public void Divide(ISeparation separation, float originalСhance)
        {
            if (separation == null)
                throw new ArgumentNullException(nameof(separation));

            float newSeparationChance = originalСhance / DecreaseChance;

            separation.SetSeporationChance(newSeparationChance);
            separation.SetColor(GetRandomColor());
            separation.SetScale(GetModifiedScale(newSeparationChance));
        }

        public bool CanDivide(float maxChance)
        {
            float randomChance = UnityEngine.Random.Range(0, MaxPercent);

            return randomChance <= maxChance;
        }

        private Color32 GetRandomColor()
        {
            const byte MinColorRange = 0;
            const byte MaxColorRange = 255;

            byte red = (byte)UnityEngine.Random.Range(MinColorRange, MaxColorRange);
            byte green = (byte)UnityEngine.Random.Range(MinColorRange, MaxColorRange);
            byte blue = (byte)UnityEngine.Random.Range(MinColorRange, MaxColorRange);

            return new Color32(red, green, blue, MaxColorRange);
        }

        private Vector3 GetModifiedScale(float chance)
        {
            float valueScale = chance / MaxPercent;

            return new Vector3(valueScale, valueScale, valueScale);
        }
    }
}
