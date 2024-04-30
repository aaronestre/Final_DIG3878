using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cubes;
    public float timer = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= 0 ) {

            Instantiate(cubes, cubes.transform);
            timer = 5f;
            return;

        }

        timer -= Time.deltaTime;

    }

}