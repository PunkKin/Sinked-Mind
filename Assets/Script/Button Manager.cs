using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public int pressure = 0;

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

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Friend")
        {
            pressure += 1;
            foreach(GameObject connex in connected)
            {
                Script = connex.GetComponent<ActiveManager>();
                if (Script == null) {
                    SideScript = connex.GetComponent<UseContraption>();
                    if (SideScript == null)
                    {
                        SideScript.Activate();
                    }
                } else {
                    Script.Activate();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Friend")
        {
            pressure -= 1;
            
            if (pressure >= 1)
            {
                foreach(GameObject connex in connected)
                {
                    Script = connex.GetComponent<ActiveManager>();
                    if (Script == null) {
                        SideScript = connex.GetComponent<UseContraption>();
                        if (SideScript == null)
                        {
                            SideScript.Activate();
                        }
                    } else {
                        Script.Activate();
                    }
                }
            } else {
                foreach(GameObject connex in connected)
                {
                    Script = connex.GetComponent<ActiveManager>();
                    if (Script == null)
                    {
                        SideScript = connex.GetComponent<UseContraption>();
                        if (SideScript == null)
                        {
                            SideScript.Unactivate   ();
                        }
                    }
                    else {
                        Script.Unactivate();
                    }
                }
            }
        }
    }
}
