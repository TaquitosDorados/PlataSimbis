using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptdelMono : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            animator.Play("WalkUp");
        } else if(Input.GetKey(KeyCode.S))
        {
            animator.Play("WalkDown");
        } else
        {
            animator.Play("Idle");
        }
        
    }
}
