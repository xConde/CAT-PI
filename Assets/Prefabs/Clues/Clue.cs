using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{
    //Clue script is going to handle responding to a user when they are nearby
    SphereCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<SphereCollider>();
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Make the clue more visible
    }

    private void OnTriggerExit(Collider other)
    {
        //Make the clue less visible
    }

    public void findClue()
    {
        //Do the thing to count this clue as found
        collider.enabled = false;
        //Make the clue less visible
    }

    public bool setRealClue()
    {
        if (collider.enabled)
            return false;
        collider.enabled = true;
        return true;
    }
}
