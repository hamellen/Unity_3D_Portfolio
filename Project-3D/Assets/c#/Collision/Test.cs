using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�浹 �߻�"+collision.gameObject.name);
    }
}
