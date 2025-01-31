using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using Cysharp.Threading.Tasks;
public class Manager : MonoBehaviour
{

    public static Manager manager;
      //public static Manager managers { get {  return manager; } }


    //PlayerInput playerinput = new PlayerInput();

    UIManager ui = new UIManager();
    ResourcesManager resourcesManager = new ResourcesManager();
    SceneManagerEx scenemanager = new SceneManagerEx();//씬 전환
    SoundManager soundManager = new SoundManager();//소리 
     DataManager dataManager = new DataManager();//데이터 보관
    ItemManager itemManager = new ItemManager();//실질적 아이템 현황
    TokenManager tokenManager = new TokenManager();//UniTask 중단 설정
    BackendManager backendManager = new BackendManager();//뒤끝 매니저 초기화
    BackendLogin backendLogin = new BackendLogin();//뒤끝 로그인
    BackendGameData backend_gamedata = new BackendGameData();//데이터베이스로부터의 정보 수신
    //public PlayerController playerController;

    public static DataManager DATAMANAGER { get { return manager.dataManager; } }

    public static ItemManager ITEMMANAGER { get { return manager.itemManager; } }

    public static BackendGameData BACKENDGAMEDATA { get { return manager.backend_gamedata; } }
    public static UIManager UI { get { return manager.ui; } }

    public static BackendLogin BACKENDLOGIN { get { return manager.backendLogin; } }
    public static ResourcesManager RESOURCES { get { return manager.resourcesManager; } }

    public static SceneManagerEx SCENEMANAGER { get { return manager.scenemanager; } }

    public static SoundManager SOUNDMANAGER { get { return manager.soundManager; } }

    public static TokenManager TOKENMANAGER { get { return manager.tokenManager; } }
    static void Init() {



        manager = FindObjectOfType<Manager>();
        manager.backendManager.Initilize();//뒤끝 초기화

        manager.backend_gamedata.GameDataGet();//데이터 불러오기

        manager.dataManager.Init();//데이터 매니저 초기화
        manager.soundManager.Init();//사운드 매니저 초기화
        manager.itemManager.Init();

       

        

    }

  
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Init();//static  함수 
        if (manager != null)
        {
            Debug.Log("매니저 로드 성공");
        }

       
       
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
