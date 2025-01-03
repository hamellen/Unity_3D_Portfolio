using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Manager : MonoBehaviour
{

     static Manager manager;
      //public static Manager managers { get {  return manager; } }


    //PlayerInput playerinput = new PlayerInput();

    UIManager ui = new UIManager();
    ResourcesManager resourcesManager = new ResourcesManager();
    SceneManagerEx scenemanager = new SceneManagerEx();
    SoundManager soundManager = new SoundManager();
     DataManager dataManager = new DataManager();

    public static DataManager DATAMANAGER { get { return manager.dataManager; } }

    public static UIManager UI { get { return manager.ui; } }

 
    public static ResourcesManager RESOURCES { get { return manager.resourcesManager; } }

    public static SceneManagerEx SCENEMANAGER { get { return manager.scenemanager; } }

    public static SoundManager SOUNDMANAGER { get { return manager.soundManager; } }

   
    static void Init() {



        manager = FindObjectOfType<Manager>();


        manager.dataManager.Init();//데이터 매니저 초기화
        manager.soundManager.Init();//사운드 매니저 초기화
        
    }

    private void OnEnable()
    {
        //playerinput.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();//static  함수 
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
