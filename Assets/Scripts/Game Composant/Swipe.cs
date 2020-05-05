using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public bool tap;

    public bool swipeUp;
    public bool swipeRight;
    public bool swipeDown;
    public bool swipeLeft;

    private bool isDragging;

    public Vector2 startTouch;
    public Vector2 swipeDelta;

    // Update is called once per frame
    void Update()
    {
        tap = swipeUp = swipeRight = swipeDown = swipeLeft = false;

        if(Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }

        }

        //Caluclate distance 

        swipeDelta = Vector2.zero;

        if(isDragging)
        {
            if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
        }

        //Did we cross the deadzone ?

        if(swipeDelta.magnitude > 125)
        {
            // Which direction ?

            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Right or left

                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or down

                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();
        }
    }

    private void Reset()
    {
        startTouch = Vector2.zero;
        swipeDelta = Vector2.zero;

        isDragging = false;
    }
}
