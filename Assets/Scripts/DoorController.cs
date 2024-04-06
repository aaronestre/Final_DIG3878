using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    public bool canOpen = false;
    public int platesNeeded = 2;
    private int currPlates = 0;
    private Vector3 orgDoorPos;
    private bool moveBack = false;
    private Color orgDoorColor;

    private GameObject[] plates;

    void Start() {

        orgDoorPos = Door.transform.position;
        orgDoorColor = Door.GetComponent<Renderer>().material.color;
        plates = GameObject.FindGameObjectsWithTag ("PressurePlates");

    }

    void OnCollisionStay(Collision col) {

        if ( col.gameObject.tag == "Interactable" ) {

            if ( Door.transform.position.y > orgDoorPos.y / 9 ) {

                Door.transform.Translate(0, -0.01f, 0);
                moveBack = false;

            }
        
        }

    }

    void OnCollisionEnter(Collision col) {

        if ( col.gameObject.tag == "Interactable" ) { 

            Door.GetComponent<Renderer>().material.color = Color.green;

            if ( Door.transform.position.y > 0.4f ) {

                Door.transform.Translate(0, -0.01f, 0);
                moveBack = false;

            }

        }

    }

    void OnCollisionExit(Collision col) { 

        if ( col.gameObject.tag == "Interactable" ) { 

            moveBack = true;

        }

    }

    void Update() {

        for ( int a = 0; a < plates.Length; a++ ) {

            if ( plates[a].GetComponent<PressurePlate>().IsActive ) {

                currPlates++;

            }

        }

        if ( currPlates >= platesNeeded ) {

            Door.GetComponent<Renderer>().material.color = Color.green;

            if ( Door.transform.position.y > orgDoorPos.y / 9 ) {

                Door.transform.Translate(0, -0.01f, 0);
                moveBack = false;

            }

        }
        else {

            moveBack = true;

        }

        if ( moveBack ) { 

            if (Door.transform.position.y < orgDoorPos.y) {

                Door.transform.Translate(0, 0.01f, 0);
                Door.GetComponent<Renderer>().material.color = orgDoorColor;

            }
            else {

                moveBack = false;

            }

        }

        currPlates = 0;

    }

}
