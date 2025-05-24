using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Auto_Gen : MonoBehaviour//자동 생성
{
    public GameObject spawn_prefab;//생성할 프리팹
    public int current_object;//현재 생성된 오브젝트 갯수
    public int max_object;//최대 갯수
    public int spawn_intarval;//스폰 간격

    CancellationTokenSource cts;//UniTask 통제를 위한 토큰

    public Queue<GameObject> spawn_list=new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        cts = new CancellationTokenSource();//새로운 토큰 생성
        
        Generate_Prefab().Forget();
    }

    public async UniTaskVoid Generate_Prefab() { 

        while( spawn_list.Count < max_object) {
            await UniTask.Delay(spawn_intarval * 1000);
            GameObject go = Manager.RESOURCES.Instantiate_object(spawn_prefab,transform);
            spawn_list.Enqueue(go);
            go.transform.parent = transform;
           
        }

        if (spawn_list.Count == max_object) { //UniTask 중단 시키고 waitutil 사용해서 스폰 재개 

            Manager.TOKENMANAGER.RefreshToken(ref cts);//중지
            await UniTask.WaitUntil(()=> spawn_list.Count < max_object);
            Generate_Prefab().Forget();//프리팹 생성 재개
        }
    }

    public void Dequeue() {
        spawn_list.Dequeue();
    }
}
