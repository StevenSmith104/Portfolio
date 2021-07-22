using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class NPCWander : MonoBehaviour {

	public float speed = 1;
	public float directionChangeInterval = 2;
	public float maxHeadingChange = 90;
	public float idle = 0;
	public bool moveDecision = false;
	public bool pause = false;

	CharacterController controller;
	float heading;
	Vector3 targetRotation;

	void Awake()
	{
		controller = GetComponent<CharacterController>();

		idle = Random.Range(0.0f, 1.0f);
		if (idle <= 0.5f)
		{
			moveDecision = false;
		}
		else
		{
			moveDecision = true;
		}
			

		//Random initial rotation selected
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);

		StartCoroutine(NewHeading());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveDecision == true && pause == false)
		{
			speed = 1;
		}
		else if (moveDecision == false || pause == true)
		{
			speed = 0;
		}

		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * speed);
	}

	IEnumerator NewHeading()
	{
		while(true)
		{
			NewHeadingRoutine();
			yield return new WaitForSeconds(directionChangeInterval);

		}
	}

	void NewHeadingRoutine()
	{
		if (pause == true)
		{
			targetRotation = new Vector3(0, 0, 0);
		}
		else
		{
			var min = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
			var max = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
			heading = Random.Range(min, max);
			targetRotation = new Vector3(0, heading, 0);
		}

		idle = Random.Range(0.0f, 1.0f);
		if (idle < 0.5f)
		{
			moveDecision = false;
		}
		else
		{
			moveDecision = true;
		}
	}
}
