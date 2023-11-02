using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RTS
{
    public class RTSUIBuildingProducts : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Transform _productConteiner;
        [SerializeField] private RTSUIProduct _productPrefab;

        public void Show(RTSBuilding building)
        {
            ClearConteiner();

            _name.text = building.GetName();

            for (int i = 0; i < building.BuildingProducts.Count; i++)
            {
                RTSUIProduct tempProduct = Instantiate(_productPrefab, _productConteiner);
                tempProduct.Init(
                    building.BuildingProducts[i].Description,
                    building.BuildingProducts[i].MineralPrice.ToString(),
                    building.BuildingProducts[i].Icon,
                    building.BuildingProducts[i].Action);
            }
        }

        public void Hide()
        {
            ClearConteiner();
        }

        private void ClearConteiner()
        {
            DestroyAllChildren(_productConteiner);
        }

        private void DestroyAllChildren(Transform parent)
        {
            foreach (Transform child in parent)
            {
                DestroyAllChildren(child);
                Destroy(child.gameObject);
            }
        }
    }
}
