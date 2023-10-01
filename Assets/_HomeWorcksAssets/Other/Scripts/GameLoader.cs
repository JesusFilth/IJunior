using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class GameLoader : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            Menu.Load();
        }
    }
}
