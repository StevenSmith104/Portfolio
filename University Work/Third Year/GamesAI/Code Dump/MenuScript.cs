using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void LoadScenario1()
	{
		//Load scenario 1
		SceneManager.LoadScene("GameAICourseworkScenario1", LoadSceneMode.Single);
	}

	public void LoadScenario2()
	{
		//Load scenario 2
		SceneManager.LoadScene("GameAICourseworkScenario2", LoadSceneMode.Single);
	}

	public void LoadMenu()
	{
		//Load the main menu
		SceneManager.LoadScene("GameAICourseworkMenu", LoadSceneMode.Single);
	}
}
