using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField]
    private float jumpForce;

    private float zRot;

    [SerializeField]
    private float currSpeed;

    [SerializeField] private float maxY;
    [SerializeField] private float minY;

    [SerializeField] private bool alive;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < maxY)
            {
                //Debug.Log("Jumped" + Time.frameCount);
                rb.velocity = Vector3.up * jumpForce;
            }

            currSpeed = rb.velocity.y;

            if (rb.velocity.y > 0)
            {
                zRot = rb.velocity.y * 10;
            }
            else if (rb.velocity.y < -15)
            {
                zRot = -90;
                rb.velocity = Vector3.down * 15;
            }
            else
            {
                zRot = rb.velocity.y * 6;
            }

            /*
            if(transform.position.y > maxY)
            {
                rb.velocity = Vector3.zero;
            }
            */
            if (transform.position.y < minY)
            {
                alive = false;
            }


            transform.eulerAngles = new Vector3(0, 0, zRot);
        }
        else
        {
            rb.velocity = Vector3.zero;
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }
}
