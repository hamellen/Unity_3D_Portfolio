using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public static Manager manager;

    static void Init() {

        manager = FindObjectOfType<Manager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        Init();
        if (manager != null)
        {
            Debug.Log("매니저 로드 성공");
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
