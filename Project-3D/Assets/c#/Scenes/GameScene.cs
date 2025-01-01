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
        

       //게임시작시 주요 ui 생성

       Object obj = GameObject.FindObjectOfType(typeof(UI_Control));
        if (obj == null)
        {
            //이벤트시스템 생성

            Manager.RESOURCES.Instantiate("UI/Scene/Basic_UI").name = "Basic_UI";
        }
    }


    public override void Clear()//해당 씬이 종료될때 해야될 함수 
    {
        
    }

   
}
