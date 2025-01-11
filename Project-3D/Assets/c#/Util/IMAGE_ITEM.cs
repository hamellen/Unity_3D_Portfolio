using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "IMAGE_ITEM",menuName ="Scriptable/IMAGE_ITEM")]
public class IMAGE_ITEM : ScriptableObject
{
   
    public int id;


    public int count;//갯수


    public string name;

   
    public Define.Grade grade;

    
    public Define.Consumable consumable;

   
    public int  figure;//효과 적용시 적용되는 수치 

    
    public string description;

    
    public Sprite  image;



}
