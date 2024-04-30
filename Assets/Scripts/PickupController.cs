using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{

    [SerializeField] Transform HoldArea;
    private GameObject heldObject = null;
    private Rigidbody heldObjRB;
    private RigidbodyConstraints initConsraints;

    [SerializeField] private float PickUpRange = 5f;
    [SerializeField] private float PickUpForce = 150f;
    [SerializeField] private float throwForce = 150f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e")) {

            if ( heldObject == null ) {

                RaycastHit hit;

                if ( Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, PickUpRange) ) {

                    //Pick up object
                    if ( hit.transform.gameObject.GetComponent<CollisionDetection>().interacted) {

                        PickUpObj(hit.transform.gameObject);

                    }

                }

            }
            else {

                DropObj();

            }

        }
        if ( heldObject != null) {

            //Move Object
            MoveObj();

            if ( Input.GetKeyDown("f")) {

                ThrowObj(20f);

            }

        }
    }

    void MoveObj() {

        if ( Vector3.Distance(heldObject.transform.position, HoldArea.position) > .1f ) {

            Vector3 moveDirection = HoldArea.position - heldObject.transform.position;
            heldObjRB.AddForce(moveDirection * PickUpForce);

        } 

    }

    void PickUpObj(GameObject obj) {

        if ( obj.GetComponent<Rigidbody>() ) {

            heldObjRB = obj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            initConsraints = heldObjRB.constraints;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = HoldArea;
            heldObject = obj;

        }

    }

    void DropObj() {

        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = initConsraints;

        heldObjRB.transform.parent = null;
        heldObject = null;

    }

    void ThrowObj(float force) { 

        heldObjRB.transform.parent = null;
        heldObjRB.useGravity = true;
        heldObjRB.constraints = initConsraints;
        heldObjRB.drag = 1;
        heldObjRB.AddForce(HoldArea.transform.forward * throwForce, ForceMode.Impulse);
        heldObject = null;

    }
}
