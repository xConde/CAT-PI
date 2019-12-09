using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{
    //Clue script is going to handle responding to a user when they are nearby
    // Start is called before the first frame update
    GameObject go;
    Light clueLight;
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has entered a clue zone");
        clueLight.enabled = true;
        //Make the clue more visible
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player has exited a clue zone");
        clueLight.enabled = false;
        //Make the clue less visible
    }

    public void findClue()
    {
        Debug.Log("Player has found the clue");
        //Do the thing to count this clue as found
        GetComponent<Collider>().enabled = false;
        Destroy(go);
        Destroy(gameObject);
        //coll.enabled = false;
        //Make the clue less visible
    }

    public bool setRealClue(GameObject go)
    {
        Debug.Log(gameObject + " is now a clue at: " + transform.position);
        //if (gameObject.name != null)
        //    return true;
        //transform.parent.gameObject
        if (this.go != null)
            return false;
        this.go = Instantiate(go, transform.parent, false);
        clueLight = this.go.GetComponent<Light>();
        clueLight.enabled = false;
        GetComponent<Collider>().enabled = true;
        return true;
    }


    public void destroyFakes()
    {
        if (go == null)
            Destroy(gameObject);
    }
}