using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public TextMeshPro text;
    public float speed;
    public float alphaspeed;
    Color alpha;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        alpha = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,speed*Time.deltaTime,0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaspeed);
    }
}
