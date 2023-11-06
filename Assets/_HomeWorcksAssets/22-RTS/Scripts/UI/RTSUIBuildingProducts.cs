using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(CanvasGroup))]
    public class RTSUIBuildingProducts : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Transform _productConteiner;
        [SerializeField] private RTSUIProduct _productPrefab;

        private CanvasGroup _canvasGroup;

        private void OnEnable()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show(RTSBuilding building)
        {
            ShowDisplay();
            SetNameText(building.GetName());
            InitConteiner(building);
        }

        public void Hide()
        {
            HideDisplay();
            ClearConteiner();
        }

        private void ShowDisplay()
        {
            _canvasGroup.interactable = true;
            _canvasGroup.alpha = 1f;
        }

        private void HideDisplay()
        {
            _canvasGroup.interactable = false;
            _canvasGroup.alpha = 0f;
        }

        private void SetNameText(string text)
        {

        }

        private void InitConteiner(RTSBuilding building)
        {
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
