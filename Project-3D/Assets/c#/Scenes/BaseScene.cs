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
        
    }

    public virtual void Init() {

        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null) {
            //이벤트시스템 생성

            Manager.RESOURCES.Instantiate("UI/EventSystem").name="EventSystem";

        }
        
    }

    public abstract void Clear();
}
