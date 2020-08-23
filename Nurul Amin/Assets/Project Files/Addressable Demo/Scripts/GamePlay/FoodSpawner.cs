using Addressable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField, Range(1f, 5f)] private float DelayTime;
    [SerializeField, Range(0.2f, 1f)] private float MinDelayTime;
    [SerializeField, Range(0.01f, 1f)] private float DelayFirster;

    [SerializeField, Range(1, 10)] private int StepLength;


    private AssetsLoader assets;
    void Start() => StartCoroutine(StartSpawn());

    //hanle runtime food spawn system
    private IEnumerator StartSpawn()
    {
        assets = FindObjectOfType<AssetsLoader>();
        while (!assets.isLoaded)
        {
            Debug.Log("Waiting for Foods");
            yield return new WaitForSeconds(1);
        }

        int currStep = 0;
        while (true)
        {
            if (StepDone(ref currStep))
                UpdateTimer(MinDelayTime);

            SpawnRanddomFood();
            yield return new WaitForSeconds(DelayTime);
        }
    }

    //spaw step counter
    private bool StepDone(ref int currStep)
    {
        bool isdone = currStep >= StepLength;
        currStep = isdone ? 0 : ++currStep;
        return isdone;
    }


    //update delay to faster if delay time greater than minimum time
    private void UpdateTimer(float mindelayTime)
    {
        if(DelayTime > mindelayTime)
            DelayTime -= DelayFirster;
    }

    //return nearest random position from this transform
    private Vector3 GetRandPosition => new Vector3(Random.Range(this.transform.position.x - 5.5f,
                                                                this.transform.position.x + 5.5f),
                                                                 this.transform.position.y, 0);
    //return random food gameobject from "Foods" list
    private void SpawnRanddomFood()
    {
        assets = FindObjectOfType<AssetsLoader>();
        assets.Spawn(assets.GetRandomResourceInxd, GetRandPosition);
    }
}

