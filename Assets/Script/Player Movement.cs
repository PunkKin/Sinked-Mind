using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool grounded;

    [SerializeField] private float speed;
<<<<<<< Updated upstream
=======
    [SerializeField] private float jumpSpeed = 3.5f;
    private bool Walk_Sound;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        grounded = true;
        Walk_Sound = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 )
        {
            if (!Walk_Sound)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Level/Walking");
                Walk_Sound = true;
            }
        }
        else
        {
            Walk_Sound = false;
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
<<<<<<< Updated upstream
            rb.velocity = new Vector2(rb.velocity.x, 3.5f);
=======
            FMODUnity.RuntimeManager.PlayOneShot("event:/Level/Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
>>>>>>> Stashed changes
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Terrain")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Level/Landing");
            grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Terrain")
        {
            grounded = false;
        }
    }
}
