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

         var bro=BackendLogin.instance.CustomLogin(id_input.text, pw_input.text);

        if (bro.IsSuccess()) {
            //UI_LoadinScene.LoadingScene("Stage1");
            Manager.SCENEMANAGER.LoadScene("Stage1");
        }
        
    }

    public void SignUpActive() {

        BackendLogin.instance.CustomSignUp(id_input.text, pw_input.text);
    }
}
