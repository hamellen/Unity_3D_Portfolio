using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Reward_control : MonoBehaviour
{

    [SerializeField] Transform text_tran;
    [SerializeField] Camera camera;
    public  TextMeshProUGUI  text_GUI;

    public ParticleSystem lightning_vfx;

    public Reward reward_base;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        lightning_vfx = GetComponentInChildren<ParticleSystem>();
        lightning_vfx.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion q_hp = Quaternion.LookRotation(text_tran.transform.position - camera.transform.position);
        Vector3 hp_angle = Quaternion.RotateTowards(text_tran.transform.rotation, q_hp, 100).eulerAngles;
        text_tran.rotation = Quaternion.Euler(0, hp_angle.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {

            if (reward_base.type == Define.ItemType.Consumable) {

                Reward_con reward_Con = reward_base as Reward_con;
                Manager.ITEMMANAGER.Apply_Update_Consumer(reward_Con.id);
                
            }
            else if(reward_base.type == Define.ItemType.Equipment) { 



            }

            Destroy(gameObject);
        }


    }
}
