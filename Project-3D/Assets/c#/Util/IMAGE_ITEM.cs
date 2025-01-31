using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "IMAGE_ITEM",menuName ="Scriptable/IMAGE_ITEM")]
public class IMAGE_ITEM : ScriptableObject
{
   
    public int id;//아이템마다의 고유 id


    public int count;//갯수


    public string name;//갯수

   
    public Define.Grade grade;//아이템의 등급

    
    public Define.Consumable consumable;//무엇을 위한 소비인지 표시

   
    public int  figure;//효과 적용시 적용되는 수치 

    
    public string description;//아이템의 설명

    
    public Sprite  image;//아이템의 스프라이트 표시 



}
