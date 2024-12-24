using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public static Manager manager;


    UIManager ui = new UIManager();
    ResourcesManager resourcesManager = new ResourcesManager();
    SceneManagerEx scenemanager = new SceneManagerEx();
    SoundManager soundManager = new SoundManager();

    public static UIManager UI { get { return manager.ui; } }
    public static ResourcesManager RESOURCES { get { return manager.resourcesManager; } }

    public static SceneManagerEx SCENEMANAGER { get { return manager.scenemanager; } }

    public static SoundManager SOUNDMANAGER { get { return manager.soundManager; } }
    static void Init() {

        manager = FindObjectOfType<Manager>();
        manager.soundManager.Init();
    }


    // Start is called before the first frame update
    void Start()
    {
        Init();
        if (manager != null)
        {
            Debug.Log("매니저 로드 성공");
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Clear() {

        SOUNDMANAGER.Clear();
        SCENEMANAGER.Clear();

    }
}
