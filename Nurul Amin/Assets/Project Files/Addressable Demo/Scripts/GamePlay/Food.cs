using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    void Start() => Destroy(this.gameObject, 5f);

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Finish")
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().enabled = false; //disable collider for ignore raycast

            Destroy(this.gameObject, 1.5f);
    }

}
