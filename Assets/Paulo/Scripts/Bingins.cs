using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Bingins : MonoBehaviour
{
    bool si;
    private InputManager inputManager;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += boingas;
        InputManager.HoldEnded += noboingas;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= boingas;
        InputManager.HoldEnded -= noboingas;
    }

    void boingas(Vector2 position, float time)
    {
        //Cast a ray in the direction specified in the inspector.
        RaycastHit2D hit = Physics2D.Raycast(position, new Vector3(0,0,1));

        //If something was hit.
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("si"))
            {
                si = true;
            }
        }
    }
    void noboingas()
    {
        si = false;
    }

    private void Update()
    {
        if(si)
        {
            transform.position = InputManager.position;
        }
    }
}
