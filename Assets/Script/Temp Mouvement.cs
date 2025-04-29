using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMouvement : MonoBehaviour
{
    float x = 5;
    float y;
    
    [SerializeField]private float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.position = new Vector2(x, y);
    }
}
