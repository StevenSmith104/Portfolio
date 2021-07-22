using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour {

    public GameObject winText;
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile5;
    public GameObject tile6;
    public GameObject tile7;
    public GameObject tile8;
    public GameObject tile9;
    public GameObject tile10;
    public GameObject tile11;
    public GameObject tile12;
	public float timer;

	bool ran = false;

    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        bool win1 = tile1.gameObject.GetComponent<SolutionScript>().isInWinState;
        bool win2 = tile2.gameObject.GetComponent<SolutionScript>().isInWinState;
        bool win3 = tile3.gameObject.GetComponent<SolutionScript>().isInWinState;
        bool win4 = tile4.gameObject.GetComponent<SolutionScript>().isInWinState;
        bool win5 = tile5.gameObject.GetComponent<SolutionScript>().isInWinState;
        bool win6 = tile6.gameObject.GetComponent<SolutionScript>().isInWinState;
        bool win7 = tile7.gameObject.GetComponent<SolutionScript>().isInWinState;
        bool win8 = tile8.gameObject.GetComponent<SolutionScript>().isInWinState;
        bool win9 = tile9.gameObject.GetComponent<SolutionScript>().isInWinState;
        bool win10 = tile10.gameObject.GetComponent<SolutionScript>().isInWinState;
        bool win11 = tile11.gameObject.GetComponent<SolutionScript>().isInWinState;
        bool win12 = tile12.gameObject.GetComponent<SolutionScript>().isInWinState;

		if (win1 == true && win2 == true && win3 == true && win5 == true && win6 == true && win7 == true && win8 == true && win10 == true && win11 == true && win12 == true) {
			//Debug.Log("Holy shit it worked");
			if (winText!= null && ran == false) 
			{
				winText.SetActive (true);
				Destroy (winText, timer);
				GameObject.Find ("PipeGrid").SetActive (false);
				ran = true;
				SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
			}
		} 
		else
		{
			winText.SetActive (false);
		}
    }
}
