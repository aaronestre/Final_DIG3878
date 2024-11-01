// Group 5
// Final Project
// Filename: CollisionDetection.cs
// Description: The is the main script for cubes. It detects if it collides with the paintbrush and using the color from the paintbrush will change to the coresponding PhysicsMaterial. You can also set a starting material that does not need to be interacted with first.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public bool interacted = false;

    private PhysicMaterial currMaterial;
    public PhysicMaterial startMaterial;

    [Header("Availabel Materials")]
    public PhysicMaterial bouncy;
    public PhysicMaterial maxFriction;
    public PhysicMaterial zeroFriction;
    public PhysicMaterial basic;

    void Start() {

        if ( startMaterial != null) {

            StartInteractable();

        }

    }


    void OnTriggerEnter(Collider col) {

        if (col.name == "PaintBrush" && PaintBrushController.IsSwiping && PaintBrushController.currColor != 0) {

            PaintInteractable(col);

        }

        if ( col.name == "DestroyCubes") {


            Destroy(gameObject);

        }

    }

    void OnTriggerStay(Collider col) {

        if (col.name == "PaintBrush" && PaintBrushController.IsSwiping && PaintBrushController.currColor != 0) {

            PaintInteractable(col);

        }

    }

    void PaintInteractable(Collider col) {

        currMaterial = GetPhysicMaterial(PaintBrushController.currColor);
        GetComponent<Collider>().sharedMaterial = currMaterial;
        GetComponent<Rigidbody>().useGravity = true;
        interacted = true;

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;


        if ( currMaterial == maxFriction || currMaterial == basic) {

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;

        }
    }

    void StartInteractable() {

        currMaterial = startMaterial;

        GetComponent<Collider>().sharedMaterial = currMaterial;
        GetComponent<Rigidbody>().useGravity = true;
        interacted = true;

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;


        if ( currMaterial == maxFriction || currMaterial == basic) {

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;

        }

    }

    PhysicMaterial GetPhysicMaterial(int color) {

        switch (color) { 

            case 1:
                GetComponent<Renderer>().material.color = Color.red;
                return bouncy;
            case 2:
                GetComponent<Renderer>().material.color = Color.green;
                return maxFriction;
            case 3: 
                GetComponent<Renderer>().material.color = Color.blue;
                return zeroFriction;
            case 4:
                GetComponent<Renderer>().material.color = Color.black;
                return basic;
            default: 
                return zeroFriction;;

        }

    }
}
