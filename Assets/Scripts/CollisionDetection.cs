using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public Material interacted;
    public PhysicMaterial bouncy;
    public PhysicMaterial maxFriction;
    public PhysicMaterial zeroFriction;

    private PhysicMaterial currMaterial;

    void OnTriggerEnter(Collider col) {

        if (col.name == "PaintBrush" && PaintBrushController.IsSwiping && PaintBrushController.currColor != 0) {

            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Renderer>().material = interacted;

            currMaterial = GetPhysicMaterial(PaintBrushController.currColor);
            GetComponent<Collider>().sharedMaterial = currMaterial;

        }

    }

    void OnTriggerStay(Collider col) {

        if (col.name == "PaintBrush" && PaintBrushController.IsSwiping && PaintBrushController.currColor != 0) {

            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Renderer>().material = interacted;
            
            currMaterial = GetPhysicMaterial(PaintBrushController.currColor);
            GetComponent<Collider>().sharedMaterial = currMaterial;

        }

    }

    PhysicMaterial GetPhysicMaterial(int color) {

        switch (color) { 

            case 1:
                return bouncy;
                break;
            case 2:
                return maxFriction;
                break;
            case 3: 
                return zeroFriction;
                break;
            default: 
                return zeroFriction;

        }

    }
}
