// Group 5
// Final Project
// Filename: EscpGame.cs
// Description: Exits the game when escape is pressed.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscpGame : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
            Application.Quit();
	}
}