using UnityEngine;
using System.Collections;

public class SolutionScript : MonoBehaviour {

    public int winState = 3;
    public bool isInWinState = false;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {

        PipeChangeScript pipeChangeScript = gameObject.GetComponent<PipeChangeScript>();
        if (!pipeChangeScript)
        {
            StraightPipeScript straightPipeScript = gameObject.GetComponent<StraightPipeScript>();

            if (straightPipeScript.currentState == winState)
            {
                isInWinState = true;
            }
            else
            {
                isInWinState = false;
            }

        }
        else
        {
            if (pipeChangeScript.currentState == winState)
            {
                isInWinState = true;
            }
            else
            {
                isInWinState = false;
            }
        }
	
	}
}
