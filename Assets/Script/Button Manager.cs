using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    int pressure = 0;

    [SerializeField] GameObject[] connected;

    
    public ActiveManager Script;
    public UseContraption SideScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pressure >= 1)
        {
            foreach(GameObject connex in connected)
            {
                Script = connex.GetComponent<ActiveManager>();
                if (Script == null)
                    SideScript = connex.GetComponent<UseContraption>();
                    SideScript.SetInactive();
                Script.SetInactive();
            }
        } else {
            foreach(GameObject connex in connected)
            {
                Script = connex.GetComponent<ActiveManager>();
                if (Script == null)
                    SideScript = connex.GetComponent<UseContraption>();
                    SideScript.SetInactive();
                Script.SetInactive();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Friend")
        {
            pressure += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Friend")
        {
            pressure -= 1;
        }
    }
}
