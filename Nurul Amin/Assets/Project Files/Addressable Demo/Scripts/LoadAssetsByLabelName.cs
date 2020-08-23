using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Addressable
{
    public class LoadAssetsByLabelName : AddressableHandeler
    {
#pragma warning disable 649
        [SerializeField] private string label;
        [SerializeField] private string AssetsName;
#pragma warning restore 649
        private List<GameObject> Assets { get; } = new List<GameObject>();

        async void Start()
        {
           await GetObjectsByLabel(label, Assets);
            foreach (GameObject g in Assets)
                Debug.Log(g.name);
        }


    }
}