using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    private bool holdStarted;
    private void OnEnable()
    {
        InputManager.Tap += HasTapped;
        InputManager.HoldStarted += HasStartedHold;
        InputManager.HoldEnded += HasEndedHold;
        SwipeDetection.SwipeUp += SwipedUp;
        SwipeDetection.SwipeDown += SwipedDown;
        SwipeDetection.SwipeLeft += SwipedLeft;
        SwipeDetection.SwipeRight += SwipedRight;
    }

    private void OnDisable()
    {
        InputManager.Tap -= HasTapped;
        InputManager.HoldStarted -= HasStartedHold;
        InputManager.HoldEnded -= HasEndedHold;
        SwipeDetection.SwipeUp -= SwipedUp;
        SwipeDetection.SwipeDown -= SwipedDown;
        SwipeDetection.SwipeLeft -= SwipedLeft;
        SwipeDetection.SwipeRight -= SwipedRight;
    }

    private void HasEndedHold()
    {
        if (!holdStarted)
            return;
        holdStarted = false;
        Debug.Log("Hold Ended");
    }

    private void HasStartedHold()
    {
        holdStarted = true;
        Debug.Log("Hold Started");
    }

    private void HasTapped()
    {
        Debug.Log("Tapped");
    }

    private void SwipedUp()
    {
        Debug.Log("Swipe Up");
    }
    private void SwipedDown()
    {
        Debug.Log("Swipe Down");
    }
    private void SwipedLeft()
    {
        Debug.Log("Swipe Left");
    }
    private void SwipedRight()
    {
        Debug.Log("Swipe Right");
    }
}
