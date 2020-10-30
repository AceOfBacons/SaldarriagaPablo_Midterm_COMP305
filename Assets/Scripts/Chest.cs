using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool isOpen = false;
    public Animator anim;
    public GameObject star;
    public Transform spawnPoint;

    public float spawnRate;
    private bool isInRange = false;
    private float spawnCounter = 2;

    public void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("isOpen", true);
            isOpen = true;

        }
        if (isOpen)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                spawnCounter = spawnRate;
                Instantiate(star, spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;

    }
}




