using Addressable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class LoadObjects : MonoBehaviour
{

    public string Name;
    public List<GameObject> objs = new List<GameObject>();

    // Start is called before the first frame update
    async void Start()
    {
        await AddressableLoader.LoadObjects(Name, objs);
        foreach (var g in objs)
        {
            Debug.Log(g.name);
            Instantiate(g);
         
        }
    }

    public AssetReference explosion;

}
