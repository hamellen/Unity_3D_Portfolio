using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Buy_Slot : MonoBehaviour
{
    public int price;
    public TextMeshProUGUI text_price;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update_State(int _price) {

        price = _price;
        text_price.text = $"{price}";
    }

   
}
