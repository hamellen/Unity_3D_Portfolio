using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScene : BaseScene
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {

        base.Init();

        scenetype = Define.Scene.Login;


        //���ӽ��۽� �ֿ� ui ����
    }


    public override void Clear()//�ش� ���� ����ɶ� �ؾߵ� �Լ� 
    {

    }



}
