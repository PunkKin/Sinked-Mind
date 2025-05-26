using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveManager : MonoBehaviour
{
    [SerializeField] private GameObject[] inputOutput;

    public bool active;

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

    public bool GetActive()
    {
        return active;
    }

    public void Activate()
    {
        if (!active)
        {
            active = true;
            foreach (GameObject connex in inputOutput)
            {
                Script = connex.GetComponent<ActiveManager>();
                if (Script == null) {
                    SideScript = connex.GetComponent<UseContraption>();
                    if (SideScript != null)
                    {
                        SideScript.Activate();
                    }
                } else {
                    Script.Activate();
                }
            }
        }
    }

    public void Unactivate()
    {
        if (active)
        {
            active = false;
            foreach (GameObject connex in inputOutput)
            {
                Script = connex.GetComponent<ActiveManager>();
                if (Script == null) {
                    SideScript = connex.GetComponent<UseContraption>();
                    if (SideScript != null)
                    {
                        SideScript.Unactivate();
                    }
                } else {
                    Script.Unactivate();
                }
            }
        }
    }
}
