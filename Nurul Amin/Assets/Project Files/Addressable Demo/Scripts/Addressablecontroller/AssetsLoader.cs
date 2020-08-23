using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Addressable
{
    public class AssetsLoader : MonoBehaviour
    {
        [SerializeField] private string LableName;
        public List<IResourceLocation> Locations = new List<IResourceLocation>();

       
        async void Start()
        {
            await AddressableLoader.GetLocations(LableName, Locations);
            GetComponent<AddressableSceneManagement>().Load();

             
        }

        public void Spawn(int resourceIndx, Vector3 pos)
        {
            if (Locations.Count > 0 && Locations.Count > resourceIndx)
            {
                Addressables.Instantiate(Locations[resourceIndx], pos, Quaternion.identity);
            }
        }

        public int GetRandomResourceInxd => Locations.Count > 0 ? UnityEngine.Random.Range(0, Locations.Count-1) : -1;
        public bool isLoaded => Locations.Count > 0;
    }
}
           
