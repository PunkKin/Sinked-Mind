using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    [SerializeField] private bool followPlayer = true;
    [SerializeField] private bool heldByPlayer;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject light;

    public bool locked;
    private bool touchingPlayer = false;

    private Rigidbody2D rb;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        locked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!locked)
        {
            if (Input.GetKeyDown(KeyCode.Q) && touchingPlayer)
            {
                Debug.Log("Held");
                swapToHeld();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Stop");
                if (followPlayer)
                    followPlayer = false;
                else
                    followPlayer = true;
            }

            if (followPlayer && !heldByPlayer)
                {
                if (transform.position.x + 0.25f < player.transform.position.x)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                else if (transform.position.x - 0.25f > player.transform.position.x)
                {
                    rb.velocity = new Vector2(speed * -1, rb.velocity.y);
                }
            }

            if (heldByPlayer)
            {
                this.gameObject.transform.localPosition = new Vector2(0, 0.75f);
            }
        }
    }

/*  Currently the object is used on player  */

    public void swapToHeld()
    {
        if (heldByPlayer)
        {
            heldByPlayer = false;
            rb.gravityScale = 1;
            this.gameObject.transform.parent = null;
            Debug.Log("Not Holden");
        }
        else
        {
            Debug.Log("holden");
            heldByPlayer = true;
            this.gameObject.transform.parent = player.transform;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
            this.gameObject.transform.localPosition = new Vector2(0, 0.75f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FriendPicker")
        {
            touchingPlayer = true;
            if (locked == true)
            {
                light.SetActive(true);
                locked = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "FriendPicker")
        {
            touchingPlayer = false;
        }
    }
}
