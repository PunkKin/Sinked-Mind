using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseContraption : MonoBehaviour
{
    [SerializeField] private GameObject closeDoor;
    [SerializeField] private GameObject openDoor;

    public int active;

    [SerializeField] private bool isDoor;

    [SerializeField] private bool reverse;

    [SerializeField] private bool isLift;

    [SerializeField] private Vector3 startingPoint;
    [SerializeField] private Vector3 endingPoint;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLift && active < 1 && transform.position != startingPoint)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, startingPoint, speed * Time.deltaTime);
        }
        else if (isLift && active >= 1 && transform.position != endingPoint)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, endingPoint, speed * Time.deltaTime);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Level/Moving_Plateforme");
        }
    }

    public void Activate()
    {
        active += 1;
        if (isDoor)
        {
            if (reverse)
            {
                closeDoor.SetActive(true);
                openDoor.SetActive(false);
                FMODUnity.RuntimeManager.PlayOneShot("event:/Level/Door_Close");
            } 
            else 
            {
                closeDoor.SetActive(false);
                openDoor.SetActive(true); FMODUnity.RuntimeManager.PlayOneShot("event:/Level/Door_Open");
            }
        }
    }
    
    public void Unactivate()
    {
        active -= 1;
        if (isDoor && active < 1)
        {
            if (reverse)
            {
                closeDoor.SetActive(false);
                openDoor.SetActive(true);
                FMODUnity.RuntimeManager.PlayOneShot("event:/Level/Door_Open");
            } 
            else 
            {
                closeDoor.SetActive(true);
                openDoor.SetActive(false);
                FMODUnity.RuntimeManager.PlayOneShot("event:/Level/Door_Close");
            }
        }
    }
}
