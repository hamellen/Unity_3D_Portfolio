using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameScene : BaseScene
{

     public Transform start;
    public GameObject player;
    public AudioClip Bgm_clip;
    public PlayerController player_controller;
     void Start()
    {
        Init();
        start = GameObject.FindGameObjectWithTag("Start").transform;
        
    }

    public override void Init() {

        base.Init();
        
        scenetype = Define.Scene.Game;
        var resource2 = FindObjectOfType<Resource>();
        Object obj_1 = GameObject.FindObjectOfType(typeof(PlayerController));
        if (obj_1 == null)
        {
           
            player=resource2.Instantiate("Player/ThirdPersonCharacter", start);
            //player = Manager.RESOURCES.Instantiate("Player/ThirdPersonCharacter", start);
            player.name = "Player";
            
            //Manager.RESOURCES.Instantiate("Player/ThirdPersonCharacter", start).name = "Player";
        }

        //게임시작시 주요 ui 생성

        Object obj = GameObject.FindObjectOfType(typeof(UI_Control));
        player_controller = FindObjectOfType<PlayerController>();
        if (obj == null)
        {
            //이벤트시스템 생성

            //resource2.Instantiate("UI/Scene/Basic_UI").name = "Basic_UI";
            //Manager.RESOURCES.Instantiate("UI/Scene/Basic_UI").name = "Basic_UI";\\
            Manager.UI.ShowBasicUI("Basic_UI");
            //Manager.UI.ShowPopUI("UI_INVENTORY");

            player_controller.inventory_obj= resource2.Instantiate($"UI/Popup/UI_INVENTORY");
            if (player_controller.inventory_obj != null) {

                player_controller.inventory_obj.SetActive(false);

            }
           
        }

        Manager.SOUNDMANAGER.Play(Define.Sound.Bgm, Bgm_clip, 1.0f);
    }


    public override void Clear()//해당 씬이 종료될때 해야될 함수 
    {
        
    }

   
}
