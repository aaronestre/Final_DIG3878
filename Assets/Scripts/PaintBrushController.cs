using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrushController : MonoBehaviour
{

    public GameObject brush;

    [Header("Paint Brush Settings")]
    public float Cooldown = 1.0f;
    public bool CanSwipe = true;
    public static bool IsSwiping = false;
    public static int currColor = 0;

    void Update() {

        if ( Input.GetMouseButtonDown(0) ) {

            if ( CanSwipe ) { 

                PaintSwipe();

            }

        }

        for ( int a = 1; a <= 5; a++ ) {

            if ( Input.GetKeyDown(a.ToString() ) ) {

                UpdateColor(a);

            }

        }

    }

    public void UpdateColor(int _color) {

        Debug.Log(_color);
        currColor = _color;

        switch ( _color ) {

            case 1:
                brush.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 2: 
                brush.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 3:
                brush.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 5:
                brush.GetComponent<Renderer>().material.color = Color.black;
                break;

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
