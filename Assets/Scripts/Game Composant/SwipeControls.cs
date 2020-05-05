using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    public Swipe swipe;
    public GameObject slicer;

    public bool swipeOK;
    public bool swipeERR;

    private void Start()
    {
        swipeOK = false;
        swipeERR = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(swipe)
        {
            if (swipe.swipeUp)
            {
                if (slicer.GetComponent<Slicer>().id == 0)
                    swipeOK = true;
                else
                    swipeERR = true;

            }
            else if (swipe.swipeRight)
            {
                if (slicer.GetComponent<Slicer>().id == 1)
                    swipeOK = true;
                else
                    swipeERR = true;

            }
            else if (swipe.swipeDown)
            {
                if (slicer.GetComponent<Slicer>().id == 2)
                    swipeOK = true;
                else
                    swipeERR = true;
            }
            else if (swipe.swipeLeft)
            {
                if (slicer.GetComponent<Slicer>().id == 3)
                    swipeOK = true;
                else
                    swipeERR = true;
            }
        }  
    }
}
