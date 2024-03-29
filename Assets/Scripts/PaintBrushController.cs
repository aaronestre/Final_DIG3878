using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrushController : MonoBehaviour
{

    public GameObject brush;
    public float Cooldown = 1.0f;
    public bool CanSwipe = true;
    public static bool IsSwiping = false;

    void Update() {

        if ( Input.GetMouseButtonDown(0) ) {

            if ( CanSwipe ) { 

                PaintSwipe();

            }

        }

    }

    public void PaintSwipe() {

        IsSwiping = true;
        CanSwipe = false;
        Animator anim = brush.GetComponent<Animator>();
        anim.SetTrigger("Swipe");
        StartCoroutine(ResetCooldown());

    }

    IEnumerator ResetCooldown() {

        StartCoroutine(ResetBoolCooldown());
        yield return new WaitForSeconds(Cooldown);
        CanSwipe = true;

    }

    IEnumerator ResetBoolCooldown() {

        yield return new WaitForSeconds(1.0f);
        IsSwiping = false;

    }
}
