using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    #region Events
    public static event Action SwipeUp;
    public static event Action SwipeDown;
    public static event Action SwipeLeft;
    public static event Action SwipeRight;

    #endregion
    [SerializeField]
    private float minDistance = .2f;
    [SerializeField]
    private float maxTime = 1f;
    [SerializeField, Range(0f, 1f)]
    private float directionThreshold = 0.9f;
    private InputManager inputManager;
    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;
    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }
    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minDistance &&
            (endTime - startTime) <= maxTime)
        {
            Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            SwipeUp?.Invoke();
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            SwipeDown?.Invoke();
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            SwipeLeft?.Invoke();
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            SwipeRight?.Invoke();
        }
    }
}
