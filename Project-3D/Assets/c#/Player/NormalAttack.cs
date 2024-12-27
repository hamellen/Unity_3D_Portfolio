using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : MonoBehaviour
{

    Animator animator;

    int hashAttackCount = Animator.StringToHash("Attack_Count");


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   public int AttackCount {

        get => animator.GetInteger(hashAttackCount);
        set => animator.SetInteger(hashAttackCount, value);
    
    }
}
