using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateState : MonoBehaviour
{
    public GameObject goHinge;
    public Text gateText;
    //public UnityStandardAssets.Cameras.LookatTarget interactPromptLooker;
    public float degreesRotate = -24;
    public float secondsToOpen = 1.0f;
    public float secondsToClose = 1.0f;

    protected float degreesClosed;
    protected float degreesOpened;

    protected enum HingeState
    {
        closed,
        opening,
        opened,
        closing
    }
    protected HingeState hingeState;

    protected bool isPlayerNear;
    protected float timeStartedRotation;

    // Use this for initialization
    void Start()
    {
        gateText.text = "[R] Gate";
        gateText.gameObject.SetActive(false);
        if (secondsToClose <= 0)
        {
            Debug.LogWarning("Seconds To Close must be > 0. Defaulting to 1 second.");
            secondsToClose = 1.0f;
        }
        if (secondsToOpen <= 0)
        {
            Debug.LogWarning("Seconds To Open must be > 0. Defaulting to 1 second.");
            secondsToOpen = 1.0f;
        }
        degreesClosed = goHinge.transform.eulerAngles.z;
        degreesOpened = degreesClosed + degreesRotate;

        //if (interactPromptLooker)
        //{
        //    interactPromptLooker.SetTarget(Camera.main.transform);
        //}
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayerNear)
        {
            if (hingeState == HingeState.closed || hingeState == HingeState.opened)
            {
                if (gateText.enabled == true && Input.GetKeyDown(KeyCode.R))
                {
                    gateText.text = "";
                    hingeState = (hingeState == HingeState.closed) ? HingeState.opening : HingeState.closing;
                    timeStartedRotation = Time.time;
                }
            }
        }

        // Update rotation if in closing or opening state
        if (hingeState == HingeState.closing)
        {
            if (InterpRotationZ(goHinge.transform, timeStartedRotation, secondsToClose, degreesOpened, degreesClosed))
            { // Done rotating
                hingeState = HingeState.closed;
                gateText.text = "[R] Gate";
            }
        }
        else if (hingeState == HingeState.opening)
        {
            if (InterpRotationZ(goHinge.transform, timeStartedRotation, secondsToOpen, degreesClosed, degreesOpened))
            { // Done rotating
                hingeState = HingeState.opened;
                gateText.text = "[R] Gate";
            }
        }
    }

    // Returns true when rotation is complete
    bool InterpRotationZ(Transform trans, float timeStarted, float secondsDuration, float degreesStart, float degreesEnd)
    {

        float timeElapsed = Time.time - timeStarted;
        float interp = timeElapsed / secondsDuration;
        if (interp < 1.0f)
        {
            float degreesInterp = degreesStart + (degreesEnd - degreesStart) * interp;
            trans.eulerAngles = new Vector3(0, 0, degreesInterp);
        }
        else
        {
            trans.eulerAngles = new Vector3(0, 0, degreesEnd);
            return true;
        }
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by: " + other.name);
        isPlayerNear = true;
        gateText.gameObject.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exited by: " + other.name);
        isPlayerNear = false;
        gateText.gameObject.SetActive(false);
    }
}
