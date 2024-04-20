using System.Collections;
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