using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager 
{

    class Pool { 
        
        public GameObject Original { get; private set; }
        public Transform Root { get; set; }

        

    }

    Dictionary<string, Pool> _pool = new Dictionary<string, Pool>();

    Transform _root;

    public void Init() {


        if (_root == null) {

            _root = new GameObject { name = "Pool_root" }.transform;

            Object.DontDestroyOnLoad(_root);
        }
    
    
    }

    public void Push(Poolable poolable) { 
    
    
    }

    public Poolable Pop(GameObject go,Transform parent=null) {

        return null;
    
    }

    public GameObject GetOriginal(string name) {

        return null;
    }

}
