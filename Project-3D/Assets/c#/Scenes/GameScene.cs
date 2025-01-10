using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameScene : BaseScene
{

     public Transform start;
    public GameObject player;
    public AudioClip Bgm_clip;
     void Start()
    {
        Init();
        //start = GameObject.FindGameObjectWithTag("Start").transform;
    }

    public override void Init() {

        base.Init();

        scenetype = Define.Scene.Game;
        var resource2 = FindObjectOfType<Resource>();
        Object obj_1 = GameObject.FindObjectOfType(typeof(PlayerController));
        if (obj_1 == null)
        {
           
            player=resource2.Instantiate("Player/ThirdPersonCharacter", start);
            player.name = "Player";
            
            //Manager.RESOURCES.Instantiate("Player/ThirdPersonCharacter", start).name = "Player";
        }

        //���ӽ��۽� �ֿ� ui ����

        Object obj = GameObject.FindObjectOfType(typeof(UI_Control));
        if (obj == null)
        {
            //�̺�Ʈ�ý��� ����

            //resource2.Instantiate("UI/Scene/Basic_UI").name = "Basic_UI";
            //Manager.RESOURCES.Instantiate("UI/Scene/Basic_UI").name = "Basic_UI";\\
            Manager.UI.ShowBasicUI("Basic_UI");
            Manager.UI.ShowPopUI("UI_INVENTORY");
        }

        Manager.SOUNDMANAGER.Play(Define.Sound.Bgm, Bgm_clip, 1.0f);
    }


    public override void Clear()//�ش� ���� ����ɶ� �ؾߵ� �Լ� 
    {
        
    }

   
}
