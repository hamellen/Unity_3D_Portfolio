using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "IMAGE_ITEM",menuName ="Scriptable/IMAGE_ITEM")]
public class IMAGE_ITEM : ScriptableObject
{
    [SerializeField]
    string name;

    [SerializeField]
    Define.Grade grade;

    [SerializeField]
    Define.Effect effect;

    [SerializeField]
    int  figure;

    [SerializeField]
    string description;

    [SerializeField]
    Sprite  image;



}
