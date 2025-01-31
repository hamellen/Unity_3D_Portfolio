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
    SceneManagerEx scenemanager = new SceneManagerEx();//�� ��ȯ
    SoundManager soundManager = new SoundManager();//�Ҹ� 
     DataManager dataManager = new DataManager();//������ ����
    ItemManager itemManager = new ItemManager();//������ ������ ��Ȳ
    TokenManager tokenManager = new TokenManager();//UniTask �ߴ� ����
    BackendManager backendManager = new BackendManager();//�ڳ� �Ŵ��� �ʱ�ȭ
    BackendLogin backendLogin = new BackendLogin();//�ڳ� �α���
    BackendGameData backend_gamedata = new BackendGameData();//�����ͺ��̽��κ����� ���� ����
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
        manager.backendManager.Initilize();//�ڳ� �ʱ�ȭ

        manager.backend_gamedata.GameDataGet();//������ �ҷ�����

        manager.dataManager.Init();//������ �Ŵ��� �ʱ�ȭ
        manager.soundManager.Init();//���� �Ŵ��� �ʱ�ȭ
        manager.itemManager.Init();

       

        

    }

  
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Init();//static  �Լ� 
        if (manager != null)
        {
            Debug.Log("�Ŵ��� �ε� ����");
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
