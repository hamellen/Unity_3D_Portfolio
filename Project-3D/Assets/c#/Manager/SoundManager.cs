using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager 
{
    AudioSource[] audioSources= new AudioSource[(int)Define.Sound.MaxCount];


    public void Init() {

        GameObject root = GameObject.Find("Sound");

        if (root == null) {

            root = new GameObject { name = "Sound" };
            Object.DontDestroyOnLoad(root);
            
            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));

            for (int i=0;i<soundNames.Length-1;i++)
            {
                

                GameObject go = new GameObject { name = soundNames[i] };
                audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;

            }

            audioSources[(int)Define.Sound.Bgm].loop = true;
        }
    
    
    }


    public void Clear() { 
    
        foreach(AudioSource audioSource in audioSources)
        {

            audioSource.clip = null;
            audioSource.Stop();

        }
    
    
    }

    public void Play(Define.Sound type, string path) {

        if (type == Define.Sound.Bgm)
        {
            AudioClip audioClip = Manager.RESOURCES.Load<AudioClip>(path);

            if (audioClip == null) {

                return;
            }

            AudioSource audiosource = audioSources[(int)Define.Sound.Bgm];
            if (audiosource.isPlaying) {
                audiosource.Pause();
            }

            audiosource.clip = audioClip;
            audiosource.Play();
        }
        else if (type == Define.Sound.Effect) {

            AudioClip audioClip = Manager.RESOURCES.Load<AudioClip>(path);

            if (audioClip == null)
            {

                return;
            }

            AudioSource audiosource = audioSources[(int)Define.Sound.Effect];
            audiosource.PlayOneShot(audioClip);//´Ü¹ß¼º

        }
    
    }



}
