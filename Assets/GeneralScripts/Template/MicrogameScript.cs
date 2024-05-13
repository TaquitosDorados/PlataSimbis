using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameScript : MonoBehaviour
{
    public bool victory = false;

    public void hasWon()
    {
        victory = true;
    }
}
