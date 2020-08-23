using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceLocations;
namespace Addressable
{
    public class LoadedAssetsLocation : AddressableHandeler
    {
#pragma warning disable 649
        [SerializeField] private string label;
#pragma warning restore 649
        public IList<IResourceLocation> AssetLocation { get; } = new List<IResourceLocation>();



        async void Start()
        {
            await GetAssetsLocationByLabel(label, AssetLocation);

            foreach (var g in AssetLocation)
                Debug.Log(g.PrimaryKey);


            List<GameObject> Assets = new List<GameObject>();
            await GetObjectsByLocation(AssetLocation, Assets);

            foreach (GameObject g in Assets)
                Debug.Log(g.name);
            
        }


 

    }
}