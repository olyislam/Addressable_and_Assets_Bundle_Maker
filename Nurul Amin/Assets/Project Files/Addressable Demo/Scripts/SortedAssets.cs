using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;


namespace Addressable
{
    public class SortedAssets : MonoBehaviour
    {

        [SerializeField] private List<string> Lables = new List<string>();

        async void Start()
        {
            await sortingUntilComplete(Lables);
        }

        private async Task sortingUntilComplete(List<string> labels)
        {

            var locations = await Addressables.LoadResourceLocationsAsync(labels.ToArray(), Addressables.MergeMode.Union).Task;
            foreach (var location in locations)
            {
                Addressables.InstantiateAsync(locations);
            }   

        }
    }
}