using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    [SerializeField] private bool followPlayer;

    [SerializeField] private GameObject player;

    private Rigidbody2D rb;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {}
        if (transform.position.x + 0.25f < player.transform.position.x)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            Debug.Log("AI Veut aller à droite");
        }
        else if (transform.position.x - 0.25f > player.transform.position.x)
        {
            rb.velocity = new Vector2(speed * -1, rb.velocity.y);
            Debug.Log("AI Veut aller à Gauche");
        }
    }
}
