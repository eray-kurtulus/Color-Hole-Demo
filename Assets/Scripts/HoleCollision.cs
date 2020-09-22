using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FallingObject")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            other.gameObject.layer = LayerMask.NameToLayer("ObjectInHole");
            rb.AddForce(10 * ((transform.position + 2*Vector3.down) - other.transform.position));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "FallingObject")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            other.gameObject.layer = LayerMask.NameToLayer("ObjectInHole");
            rb.AddForce(5 * ((transform.position + 2*Vector3.down) - other.transform.position));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "FallingObject")
        {
            other.gameObject.layer = LayerMask.NameToLayer("ObjectOnPlatform");
        }
    }
}
