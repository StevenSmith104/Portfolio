using UnityEngine;
using System.Collections;

public class LerpScript : MonoBehaviour {

	GameObject cube;
	const float travelTime1 = 3.0f;
	const float travelDistance1 = 3.0f;
	const float travelTime2 = 2.0f;
	const float travelDistance2 = 2.0f;
	const float travelDistance3 = 1.0f;
	const float travelTime3 = 1.0f;
	const float travelDistance4 = 1.0f;
	const float travelTime4 = 1.0f;
	Vector3 wayPoint1, wayPoint2, wayPoint3, wayPoint4, wayPoint5;
	//bool lerping = false;

	// Use this for initialization
	void Start () {

		StartLerping ();
	
	}

	IEnumerator Lerp1()
	{
		if (cube) 
		{
			float t = 0;
			cube.transform.position = wayPoint1;
			while(t< travelTime1)
			{
				t+=Time.deltaTime;
				cube.transform.position = Vector3.Lerp(wayPoint1,wayPoint2,t/travelTime1);
				yield return 0;
			}
			cube.transform.position = wayPoint2;
			StartCoroutine(Lerp2());
		}
	}

	IEnumerator Lerp2()
	{
		if (cube) 
		{
			float t = 0;
			cube.transform.position = wayPoint2;
			while(t< travelTime2)
			{
				t+=Time.deltaTime;
				cube.transform.position = Vector3.Lerp(wayPoint2,wayPoint3,t/travelTime2);
				yield return 0;
			}
			cube.transform.position = wayPoint3;
			StartCoroutine(Lerp3());
		}
	}

	IEnumerator Lerp3()
	{
		if (cube) 
		{
			float t = 0;
			cube.transform.position = wayPoint3;
			while(t< travelTime3)
			{
				t+=Time.deltaTime;
				cube.transform.position = Vector3.Lerp(wayPoint3,wayPoint4,t/travelTime3);
				yield return 0;
			}
			cube.transform.position = wayPoint4;
			StartCoroutine(Lerp4());
		}
	}

	IEnumerator Lerp4()
	{
		if (cube) 
		{
			float t = 0;
			cube.transform.position = wayPoint4;
			while(t< travelTime4)
			{
				t+=Time.deltaTime;
				cube.transform.position = Vector3.Lerp(wayPoint4,wayPoint5,t/travelTime4);
				yield return 0;
			}
			cube.transform.position = wayPoint5;
			//StartCoroutine(Lerp3());
		}
	}


	void StartLerping()
	{
		//lerping = true;
		cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		//wayPoint1 = wayPoint2 = Vector3.zero;

		wayPoint1 = new Vector3 (0.5f, 1.5f, 0.5f);
		wayPoint2 = new Vector3 (3.5f, 1.5f, 0.5f);
		wayPoint3 = new Vector3 (3.5f, 1.5f, 2.5f);
		wayPoint4 = new Vector3 (4.5f, 1.5f, 2.5f);
		wayPoint5 = new Vector3 (4.5f, 1.5f, 3.5f);

		StartCoroutine (Lerp1 ());
	}

	void StopLerping()
	{
		StopAllCoroutines();
		Destroy(cube);
		//lerping = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
