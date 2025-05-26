using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseContraption : MonoBehaviour
{
    [SerializeField] private GameObject contraption;

    private int active = 0;

    [SerializeField] private bool isDoor;

    private bool closed;    

    [SerializeField] private bool isLift;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActive()
    {
        if (isDoor)
        {
            contraption.SetActive(false);
        }
    }
    
    public void SetInactive()
    {
        if (isDoor)
        {
            contraption.SetActive(false);
        }
    }
}
