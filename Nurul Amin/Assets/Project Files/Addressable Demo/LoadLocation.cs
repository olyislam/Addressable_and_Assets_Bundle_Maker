using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Addressable;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadLocation : MonoBehaviour
{
    public string labelORname;
    public List<IResourceLocation> locations  = new List<IResourceLocation>();


    private async void OnEnable()
    {
        await AddressableLoader.GetLocations(labelORname, locations);
        foreach (var v in locations)
        {
            Addressables.InstantiateAsync(v);
            Debug.Log(v.PrimaryKey);
        }

    }
    
 
}
