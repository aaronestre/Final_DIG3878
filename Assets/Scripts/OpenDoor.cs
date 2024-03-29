using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public GameObject Door;
    private Vector3 orgDoorPos;
    private bool moveBack = false;
    private Color orgDoorColor;

    void Start() {

        orgDoorPos = Door.transform.position;
        orgDoorColor = Door.GetComponent<Renderer>().material.color;

    }

    void OnTriggerStay(Collider col) {

        if ( col.gameObject.tag == "Interactable" ) {

            Door.transform.Translate(0, -0.01f, 0);
            moveBack = false;

        }

    }

    void OnTriggerEnter(Collider col) {

        if ( col.gameObject.tag == "Interactable" ) { 

            Door.GetComponent<Renderer>().material.color = Color.green;

        }

    }

    void OnTriggerExit(Collider col) { 

        if ( col.gameObject.tag == "Interactable" ) { 

            moveBack = true;


        }

    }

    void Update() {

        if ( moveBack ) { 

            if (Door.transform.position.y < orgDoorPos.y) {

                Door.transform.Translate(0, 0.01f, 0);
                Door.GetComponent<Renderer>().material.color = orgDoorColor;

            }
            else {

                moveBack = false;

            }

        }

    }

}
