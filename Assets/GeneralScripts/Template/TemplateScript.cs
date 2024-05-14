using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemplateScript : MonoBehaviour
{
    public Text text;
    private void OnEnable()
    {
        InputManager.Tap += Ganaste;
    }

    private void OnDisable()
    {
        InputManager.Tap -= Ganaste;
    }

    void Ganaste()
    {
        text.text = "You Won";
        GetComponentInParent<MicrogameScript>().hasWon();
    }
}
