using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public T Load<T>(string path) where T : Object
    {

        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent )
    {

        GameObject prefab = Resources.Load<GameObject>($"Prefab/{path}");

        if (prefab == null)
        {
            Debug.Log("로드실패");
            return null;
        }


        return Instantiate(prefab, parent.position,parent.rotation);


    }

    public GameObject Instantiate(GameObject go, Transform parent)
    {

    
        return Instantiate(go, parent.position, parent.rotation);


    }

    public GameObject Instantiate(string path)
    {

        GameObject prefab = Resources.Load<GameObject>($"Prefab/{path}");

        if (prefab == null)
        {
            Debug.Log("로드실패");
            return null;
        }


        return Instantiate(prefab);


    }
}
