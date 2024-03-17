using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyen : MonoBehaviour
{
    public Rigidbody2D rb;
    int tocdo = 4;
    public float traiphai;
    public bool facingRight = true;
    public Animator anim;

    public GameObject enem;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        traiphai = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(tocdo * traiphai, rb.velocity.y);

        // Set "di" based on input
        if (facingRight && traiphai == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
            anim.SetFloat("di", 1);
        }
        else if (!facingRight && traiphai == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
            anim.SetFloat("di", 1);
        }
        else if (Input.GetKey(KeyCode.W)) // Up
        {
            transform.position += Vector3.up * tocdo * Time.deltaTime;
            anim.SetFloat("di", 1); // w
        }
        else if (Input.GetKey(KeyCode.S)) // Down
        {
            transform.position += Vector3.down * tocdo * Time.deltaTime;
            anim.SetFloat("di", 1);
        }
        else
        {
            anim.SetFloat("di", 0); // Set "di" to 0 when no input is detected
        }
    }
}
