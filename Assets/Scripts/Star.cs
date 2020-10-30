using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    //public float upForce = 1f;
    //public float sideForce = 0f;
    //private Rigidbody2D rb;

    [SerializeField] private float speed = 7.5f;
    private Vector3 direction;

    void Start()
    {
        //float xForce = Random.Range(-sideForce, sideForce);
        //float yForce = Random.Range(upForce / 2f, upForce);

        //Vector2 force = new Vector2(xForce, yForce);

        //rb.GetComponent<Rigidbody2D>();
        //rb.velocity = force;

        direction = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

}
