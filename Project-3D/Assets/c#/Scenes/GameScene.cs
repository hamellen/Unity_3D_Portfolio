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

            
            Manager.UI.ShowBasicUI("Basic_UI");
            

            player_controller.inventory_obj= resource2.Instantiate($"UI/Popup/UI_INVENTORY");
            if (player_controller.inventory_obj != null) {

                player_controller.inventory_obj.SetActive(false);

            }
           
        }
        //Initilize_player_data();
        Manager.SOUNDMANAGER.Play(Define.Sound.Bgm, Bgm_clip, 1.0f);
    }


    public override void Clear()//해당 씬이 종료될때 해야될 함수 
    {
        
    }

    public void Initilize_player_data() {

        player_controller.stat.LEVEL = Manager.BACKENDGAMEDATA.UserData.level;
        player_controller.stat.HP = Manager.BACKENDGAMEDATA.UserData.hp;
        player_controller.stat.MAXHP = Manager.BACKENDGAMEDATA.UserData.MaxHp;
        player_controller.stat.ATTACK = Manager.BACKENDGAMEDATA.UserData.atk;
        player_controller.stat.DEFENCE = Manager.BACKENDGAMEDATA.UserData.defence;
        player_controller.stat.SPEED = Manager.BACKENDGAMEDATA.UserData.speed;
        player_controller.stat.GOLD = Manager.BACKENDGAMEDATA.UserData.gold;
        player_controller.stat.EXP = Manager.BACKENDGAMEDATA.UserData.exp;
        player_controller.stat.Asked_max_exp = Manager.BACKENDGAMEDATA.UserData.asked_max_exp;
    }
}
