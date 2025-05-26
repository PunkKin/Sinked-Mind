using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveManager : MonoBehaviour
{
    [SerializeField] private GameObject[] inputOutput;

    private bool active;

    public ActiveManager Script;
    public UseContraption SideScript;

    [SerializeField] private bool change;
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

    public void SetActive()
    {
        if (!active)
        {
            active = true;
            foreach (GameObject connex in inputOutput)
            {
                Script = connex.GetComponent<ActiveManager>();
                if (Script == null)
                    SideScript = connex.GetComponent<UseContraption>();
                    SideScript.SetActive();
                Script.SetActive();
            }
        }
    }

    public void SetInactive()
    {
        if (active)
        {
            active = false;
            foreach (GameObject connex in inputOutput)
            {
                Script = connex.GetComponent<ActiveManager>();
                if (Script == null)
                    SideScript = connex.GetComponent<UseContraption>();
                    SideScript.SetInactive();
                Script.SetInactive();
            }
        }
    }
}
