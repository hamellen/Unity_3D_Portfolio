using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{

    public Define.Scene scenetype = Define.Scene.Unknown;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public virtual void Init() {

        var resource = FindObjectOfType<Resource>();

        if (resource == null) {

            GameObject gobj = new GameObject { name = "Resource" };
            gobj.AddComponent<Resource>();
            DontDestroyOnLoad(gobj);
        }



        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null) {
            //�̺�Ʈ�ý��� ����
            var resource2 = FindObjectOfType<Resource>();
            //Manager.RESOURCES.Instantiate("UI/EventSystem").name="EventSystem";
            resource2.Instantiate("UI/EventSystem").name = "EventSystem";
            Debug.Log("�̺�Ʈ �ý��� �����Ϸ�");
        }
        
        
    }

    public abstract void Clear();
}


