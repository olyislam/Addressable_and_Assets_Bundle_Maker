using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;


namespace Addressable
{
    public class AssetRefObjectData : AddressableHandeler
    {
        [Header("Input")]
#pragma warning disable 649
        [SerializeField] private AssetReference Ref;
#pragma warning restore 649
        [SerializeField] private List<AssetReference> references = new List<AssetReference>();

        [Header("Output")]
        [SerializeField] private List<GameObject> Assets = new List<GameObject>();

   

       async void Start()
        {
            references.Add(Ref);
            await GetObjectByAssetRefS(references, Assets);

            foreach (GameObject g in Assets)
                Debug.Log(g.name);
        }


   
    }
}