using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PipeChangeScript : MonoBehaviour {

    public int currentState = 1;
    
    // Use this for initialization
    void Start () {
        
       
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ChangePipe()
    {
        gameObject.transform.Rotate(0, 0, 90);
        currentState++;
        if(currentState > 4)
        {
            currentState = 1;
        }
    }
}
