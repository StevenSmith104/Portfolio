using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class OmegaAgentScript : MonoBehaviour {

	public float speed = 1;
	public float constSpeed;
	public float directionChangeInterval = 2;
	public float maxChange = 90;

	CharacterController charController;
	float rotation;
	Vector3 targetRotation;

	void Awake()
	{
		//Grab the character controller off the omega agent
		charController = GetComponent<CharacterController>();
		//Randomize the speed and direction
		constSpeed = Random.Range(0.0f, 3.0f);
		rotation = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, rotation, 0);

		StartCoroutine(NewRotation());
	}

	void Update()
	{
		//Slerp between the rotations of the agent and move the character controller forward
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);
		charController.SimpleMove(forward * speed);
	}

	IEnumerator NewRotation()
	{
		while(true)
		{
			NewRotationRoutine();
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}

	void NewRotationRoutine()
	{
		//Picks a new random rotation 
		var min = Mathf.Clamp(rotation - maxChange, 0, 360);
		var max = Mathf.Clamp(rotation + maxChange, 0, 360);
		rotation = Random.Range(min, max);
		targetRotation = new Vector3(0, rotation, 0);
	}
}
