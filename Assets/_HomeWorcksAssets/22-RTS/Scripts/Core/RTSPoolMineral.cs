using UnityEngine;

public class RTSPoolMineral : RTSPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _capasity;

    private void OnEnable()
    {
        Initialize();
    }

    public void CreateObject(Vector3 position)
    {
        if (TryGetObject(out GameObject obj))
            base.CreateObject(obj, position);
    }

    protected override void Initialize()
    {
        if (_prefab == null)
            return;

        Transform parent = transform;

        if (Conteiner != null)
            parent = Conteiner;

        for (int i = 0; i < _capasity; i++)
        {
            GameObject temp = Instantiate(_prefab, parent);
            temp.SetActive(false);
            Objects.Add(temp);
        }
    }
}
