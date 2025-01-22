using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{

    int order = 0;

    Stack<UI_POPUP> popupStack = new Stack<UI_POPUP>();

    public Action MerChantBtn;
    public Action InventoryBtn;

    public UI_POPUP ShowPopUI(string name)  {
        order++;
        GameObject go=Manager.RESOURCES.Instantiate($"UI/Popup/{name}");

        go.GetComponent<Canvas>().sortingOrder = order;
        popupStack.Push(go.GetComponent<UI_POPUP>());

        return go.GetComponent<UI_POPUP>();
    }

    public void ShowBasicUI(string name) {

        Manager.RESOURCES.Instantiate($"UI/Scene/{name}");

        
    }

    public void Set_Top_OnActive() {

      
    }

    public void ClosePopUp() {
        order--;
        if (popupStack.Count == 0) {
            return;
        }
        else if (popupStack.Count > 0){

            UI_POPUP popup=popupStack.Pop();

            Manager.RESOURCES.Destroy(popup.gameObject);
        }
    }
}
