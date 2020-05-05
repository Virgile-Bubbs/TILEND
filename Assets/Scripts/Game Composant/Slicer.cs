using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    public Sprite arrow_up;
    public Sprite arrow_right;
    public Sprite arrow_down;
    public Sprite arrow_left;

    public int id;

    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        int r = rand.Next(4);
        switch(r)
        {
            case 0:
                GetComponent<UnityEngine.UI.Image>().sprite = arrow_up;
                id = 0;
                break;

            case 1:
                GetComponent<UnityEngine.UI.Image>().sprite = arrow_right;
                id = 1;
                break;

            case 2:
                GetComponent<UnityEngine.UI.Image>().sprite = arrow_down;
                id = 2;
                break;

            case 3:
                GetComponent<UnityEngine.UI.Image>().sprite = arrow_left;
                id = 3;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
