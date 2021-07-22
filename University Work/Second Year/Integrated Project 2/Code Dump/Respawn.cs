using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour 
{
	public GameObject player1;
	public GameObject player2;

	public Score score;


	public void P1StartRespawn ()
	{
		StartCoroutine (P1Respawn ());
	}

	public void P2StartRespawn ()
	{
		StartCoroutine (P2Respawn ());
	}

	public void P1StartRespawnShot ()
	{
		StartCoroutine (P1RespawnShot ());
	}
	
	public void P2StartRespawnShot ()
	{
		StartCoroutine (P2RespawnShot ());
	}
	
	IEnumerator P1Respawn ()
	{
		yield return new WaitForSeconds (1f);
		Instantiate(player1, (transform.position - new Vector3(9,0,0)), transform.rotation);
	}

	IEnumerator P2Respawn ()
	{
		yield return new WaitForSeconds (1f);
		Instantiate(player2, (transform.position + new Vector3(9,0,0)), transform.rotation);
	}

	IEnumerator P1RespawnShot ()
	{
		score.player2Score++;
		yield return new WaitForSeconds (1f);
		Instantiate(player1, (transform.position - new Vector3(9,0,0)), transform.rotation);
	}
	
	IEnumerator P2RespawnShot ()
	{
		score.player1Score++;
		yield return new WaitForSeconds (1f);
		Instantiate(player2, (transform.position + new Vector3(9,0,0)), transform.rotation);
	}
}