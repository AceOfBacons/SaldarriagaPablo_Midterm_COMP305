using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool isOpen = false;
    public Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void openChest()
    {
        if(Input.GetKeyDown("e"))
        {
            anim.SetBool("isOpen", true);
        }


    }
}




