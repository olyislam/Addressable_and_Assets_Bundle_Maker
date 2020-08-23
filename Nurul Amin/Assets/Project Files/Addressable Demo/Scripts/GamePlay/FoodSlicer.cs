using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSlicer : MonoBehaviour
{
    [SerializeField] private string TargetTag;
    [SerializeField] private Camera cam;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject food;
            if (isDetected(out food))
            {
                food.GetComponent<Rigidbody>().isKinematic = true;
                food.GetComponent<Collider>().enabled = false;
                Destroy(food, 0.5f);
                GameObject.FindObjectOfType<PlayerScore>().AddScore(1); ;
            }
        }
    }
        

    private bool isDetected(out GameObject food)
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == TargetTag)
            {
                food = hit.collider.gameObject;
                return true;
            }
        }

        food = null;
        return false;
    }




}
