using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameScene : BaseScene
{

     public Transform start;
    public GameObject player;
     void Start()
    {
        Init();
        start = GameObject.FindGameObjectWithTag("Start").transform;
    }

    public override void Init() {

        base.Init();

        scenetype = Define.Scene.Game;


        Manager.RESOURCES.Instantiate("Player/ThirdPersonCharacter", start).name="Player";
        

       //���ӽ��۽� �ֿ� ui ����

       Object obj = GameObject.FindObjectOfType(typeof(UI_Control));
        if (obj == null)
        {
            //�̺�Ʈ�ý��� ����

            Manager.RESOURCES.Instantiate("UI/Scene/Basic_UI").name = "Basic_UI";
        }
    }


    public override void Clear()//�ش� ���� ����ɶ� �ؾߵ� �Լ� 
    {
        
    }

   
}
