// Group 5
// Final Project
// Filename: LoadLevel.cs
// Description: Loads the specified level or quits the application. Used for the Start Screen.

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void Load(int level) {

        SceneManager.LoadScene(level);

    }

    public void Quit() {

        Application.Quit();

    }

}
