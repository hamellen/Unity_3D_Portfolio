using BackEnd;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackendManager 
{

   


    public void Initilize() {

        var bro = Backend.Initialize(); // 뒤끝 초기화

        // 뒤끝 초기화에 대한 응답값
        if (bro.IsSuccess())
        {
            Debug.Log("초기화 성공 : " + bro); // 성공일 경우 statusCode 204 Success
        }
        else
        {
            Debug.LogError("초기화 실패 : " + bro); // 실패일 경우 statusCode 400대 에러 발생
        }

        
    }

    void Test() {

        
    }
}
