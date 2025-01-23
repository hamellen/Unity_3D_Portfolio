using BackEnd;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class UI_Login : MonoBehaviour
{
    public TMP_InputField id_input;
    public TMP_InputField pw_input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoginActive() {

         var bro=Manager.BACKENDLOGIN.CustomLogin(id_input.text, pw_input.text);

        if (bro.IsSuccess()) {
            //UI_LoadinScene.LoadingScene("Stage1");
            Manager.SCENEMANAGER.LoadScene("Stage1");
            Manager.BACKENDGAMEDATA.GameDataGet();//데이터 플레이어한테 적용
        }
        
    }

    public void SignUpActive() {

        Manager.BACKENDLOGIN.CustomSignUp(id_input.text, pw_input.text);
        Manager.BACKENDGAMEDATA.GameDataInsert();//초기 데이터 설정
    }
}
