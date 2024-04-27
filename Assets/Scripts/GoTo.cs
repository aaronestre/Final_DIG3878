/*Final Project
 *Marin Sazama
 *GoTo.cs
 *This program allows the player controlled by a first person rigid body script
 *to enter the attatched trigger area and be sent to a scene with the same name as inputed in the string
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoTo : MonoBehaviour
{
    [SerializeField] private string levelToLoad;
    //Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Application.LoadLevel(levelToLoad);
        }
    }
    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Application.LoadLevel(levelToLoad);
    //    }
    //}
}
