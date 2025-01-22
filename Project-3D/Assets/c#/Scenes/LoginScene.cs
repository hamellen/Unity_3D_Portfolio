using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScene : BaseScene
{

    public AudioClip login_bgm;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {

        base.Init();

        scenetype = Define.Scene.Login;

        Manager.SOUNDMANAGER.Play(Define.Sound.Bgm, login_bgm, 1.0f);

        //게임시작시 주요 ui 생성
    }


    public override void Clear()//해당 씬이 종료될때 해야될 함수 
    {

    }



}
