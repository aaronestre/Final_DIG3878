using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintBrushController : MonoBehaviour
{

    public GameObject brush;
    public GameObject glob;
    public Image UIBrush;
    public Image ColorSelection;

    [Header("UI Stuff")]
    public Sprite UIRed;
    public Sprite UIGreen;
    public Sprite UIBlue;

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

        for ( int a = 1; a <= 3; a++ ) {

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
                glob.GetComponent<Renderer>().material.color = Color.red;
                ColorSelection.GetComponent<Image>().sprite = UIRed;
                UIBrush.color = Color.red;
                break;
            case 2: 
                glob.GetComponent<Renderer>().material.color = Color.green;
                ColorSelection.GetComponent<Image>().sprite = UIGreen;
                UIBrush.color = Color.green;
                break;
            case 3:
                glob.GetComponent<Renderer>().material.color = Color.blue;
                ColorSelection.GetComponent<Image>().sprite = UIBlue;
                UIBrush.color = Color.blue;
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

    void SwitchUI(GameObject curr) {



    }
}
