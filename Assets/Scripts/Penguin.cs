using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
    }
}
