using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_controller : MonoBehaviour
{
    public Slider bgm_slider;
    public Slider sfx_slider;

    public AudioClip click_sfx;
    // Start is called before the first frame update
    void Start()
    {
        bgm_slider.value = Manager.SOUNDMANAGER.audioSources[(int)Define.Sound.Bgm].volume;
        sfx_slider.value = Manager.SOUNDMANAGER.audioSources[(int)Define.Sound.D2_Effect].volume;
    }

    public void Exit_event() {


        Manager.UI.ClosePopUp();
    }

    public void Change_bgm_value() {

        Manager.SOUNDMANAGER.Change_Sound_Value(Define.Sound.Bgm, bgm_slider.value);
    
    }

    public void Change_sfx_value()
    {

        Manager.SOUNDMANAGER.Change_Sound_Value(Define.Sound.D2_Effect, sfx_slider.value);

    }
    public void Play_sfx()
    {

        Manager.SOUNDMANAGER.Play(Define.Sound.D2_Effect, click_sfx, 1.0f);
    }

    public void EndGame() {

        Play_sfx();
        Debug.Log("게임 종료 ");
    }
}
