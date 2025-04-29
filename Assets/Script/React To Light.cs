using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactToLight : MonoBehaviour
{
    [SerializeField] private bool hideInLight;
    [SerializeField] private bool showInLight;

    [SerializeField] private GameObject collider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("First Contact");

        if (other.gameObject.tag == "Light")
        {
            if (hideInLight == true)
            {
                collider.SetActive(false);
            }
            else if (showInLight == true)
            {
                collider.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Un-Contact");

        if (other.gameObject.tag == "Light")
        {
            if (hideInLight == true)
            {
                collider.SetActive(true);
            }
            else if (showInLight == true)
            {
                collider.SetActive(false);
            }
        }
    }
}
