using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Pool : MonoBehaviour
{
    [SerializeField] protected Transform _conteiner;

    protected List<GameObject> _objects = new List<GameObject>();

    protected bool TryGetObject(out GameObject objPool)
    {
        objPool = null;

        if (_objects.Count == 0)
            return false;

        objPool = _objects.Where(obj => obj.gameObject.activeSelf == false).FirstOrDefault();

        if (objPool == null)
            return false;

        return true;
    }

    protected bool TryGetRandomObject(out GameObject objPool)
    {
        objPool = null;

        if (_objects.Count == 0)
            return false;

        GameObject[] freeObject;

        try
        {
            freeObject = _objects.Where(obj => obj.gameObject.activeSelf == false).ToArray();
            objPool = freeObject[Random.Range(0, freeObject.Length)];
        }
        catch
        {
            Debug.Log("Добавте в пулл дополнительно объекты");
            return false;
        }
        
        return true;
    }

    protected virtual void CreateObject(GameObject obj, Vector3 position)
    {
        obj.SetActive(true);
        obj.transform.position = position;
    }

    protected abstract void Initialize();
}
