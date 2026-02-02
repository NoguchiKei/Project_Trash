using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 4f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 foce = Vector2.zero;
        float dy, dx = 0;
        dx = Input.GetAxis("Horizontal");
        dy = Input.GetAxis("Vertical");
        foce = new Vector2(dx, dy) * speed;
        rb.MovePosition(rb.position + foce * Time.fixedDeltaTime);
        if (dx != 0 )
        {
            if (dx < 0)
            {
                spriteRenderer.flipX = true;
            }
            else 
            {
                spriteRenderer.flipX = false;
            }
        }

        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag=="Enemy")
    //    {
    //        Debug.Log("Player hit enemy");
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    GetComponent<Renderer>().material.color = Color.red;
    //}


}
