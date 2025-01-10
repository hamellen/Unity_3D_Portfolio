using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "IMAGE_ITEM",menuName ="Scriptable/IMAGE_ITEM")]
public class IMAGE_ITEM : ScriptableObject
{
   
    public int id;

    
    public int count;

    
    public string name;

   
    public Define.Grade grade;

    
    public Define.Consumable consumable;

   
    public int  figure;

    
    public string description;

    
    public Sprite  image;



}
