using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public Material interacted;
    void OnTriggerEnter(Collider col) {

        if (col.name == "PaintBrush" && PaintBrushController.IsSwiping ) {

            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Renderer>().material = interacted;

        }

    }

    void OnTriggerStay(Collider col) {

        if (col.name == "PaintBrush" && PaintBrushController.IsSwiping ) {

            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Renderer>().material = interacted;

        }

    }
}
