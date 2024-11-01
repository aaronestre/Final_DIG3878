// Group 5
// Final Project
// Filename: PressurePlate.cs
// Description: The main controller for the pressure plates. Checks to see if the cubes are on the pressure plate. If one is, then the plate is activated.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressurePlate : MonoBehaviour
{
    public bool IsActive = false;
    public Color initColor;

    void Start() {

        initColor = GetComponent<Renderer>().material.color;

    }

    void OnCollisionStay(Collision col) {

        if ( col.gameObject.tag == "Interactable" ) {

            IsActive = true;
            GetComponent<Renderer>().material.color = Color.green;

        
        }

    }

    void OnCollisionEnter(Collision col) {

        if ( col.gameObject.tag == "Interactable" ) { 

            IsActive = true;

        }

    }

    void OnCollisionExit(Collision col) { 

        if ( col.gameObject.tag == "Interactable" ) { 

            IsActive = false;
            GetComponent<Renderer>().material.color = initColor;

        }

    }

}
