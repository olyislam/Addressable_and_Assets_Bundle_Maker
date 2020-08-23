using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Addressable
{
    public class AddressableHandeler : MonoBehaviour
    {
        /// <summary>
        /// return asset locations collection by label
        /// </summary>
        /// <param name="label"></param>
        /// <param name="AssetLocation"></param>
        /// <returns></returns>
        protected async Task GetAssetsLocationByLabel(string label, IList<IResourceLocation> AssetLocation)
        {
            await AddressableLoader.GetLocations(label, AssetLocation);
           
        }

        /// <summary>
        /// return list of game objects by IResourceLocation
        /// </summary>
        /// <param name="locations"></param>
        /// <param name="Assets"></param>
        /// <returns></returns>
        protected async Task GetObjectsByLocation(IList<IResourceLocation> locations, List<GameObject> Assets)
        {
            await AddressableLoader.LoadObjects(locations, Assets);
          
        }

        /// <summary>
        /// return a list of game objects by label
        /// </summary>
        /// <param name="label"></param>
        /// <param name="Assets"></param>
        /// <returns></returns>
        protected async Task GetObjectsByLabel(string label, List<GameObject> Assets)
        {
            await AddressableLoader.LoadObjects(label, Assets);
            //await AddressableLoader.GetAssetBy_Name_or_Lable(AssetsName, Assets);
        }

        /// <summary>
        /// return a list of game objects by List of AssetsReference 
        /// </summary>
        /// <param name="references"></param>
        /// <param name="Assets"></param>
        /// <returns></returns>
        protected async Task GetObjectByAssetRefS(List<AssetReference> references, List<GameObject> Assets)
        {
            await AddressableLoader.LoadObjects(references, Assets);
        }

      
    }
}