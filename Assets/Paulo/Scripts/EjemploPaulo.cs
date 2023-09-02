using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploPaulo : MonoBehaviour
{
    private void Awake()
    {
        InputManager.Tap += EmpezarJuego;
    }

    private void EmpezarJuego()
    {
        InputManager.Tap -= EmpezarJuego;
        SwipeDetection.SwipeRight += Chompis;
    }

    private void OnDisable()
    {
        InputManager.Tap -= EmpezarJuego;
        SwipeDetection.SwipeRight -= Chompis;
    }

    private void Chompis()
    {
        Debug.Log("Comes Webos");
    }


}
