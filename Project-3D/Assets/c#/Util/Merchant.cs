using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Manager.UI.MerChantBtn();
    }

    private void OnTriggerExit(Collider other)
    {
        Manager.UI.MerChantBtn();
    }
}
