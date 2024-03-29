using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameObject YouWinText;

    void OnTriggerEnter(Collider col) {

        if ( col.name == "Player" ) {

            YouWinText.SetActive(true);

        }

    }
}
