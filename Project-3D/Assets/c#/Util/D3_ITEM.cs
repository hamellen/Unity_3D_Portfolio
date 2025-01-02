using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "IMAGE_ITEM", menuName = "Scriptable/D3_ITEM")]
public class D3_ITEM : ScriptableObject
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    string name;

    [SerializeField]
    Define.Grade grade;

    [SerializeField]
    string description;

    [SerializeField]
    Sprite image;


}
