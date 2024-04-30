// Group 5
// Final Project
// Filename: ExitDoor.cs
// Description: Loads the appropriate level when going through the door's collider.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    public int nextLevel;

    void OnTriggerEnter(Collider col) {

        if ( col.name == "Player" ) {

            SceneManager.LoadScene(nextLevel);

        }

    }
}
