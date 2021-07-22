using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LerpCubeScript : MonoBehaviour {

    GameObject cube;
    const float travelTime = 2.0f;
    const float travelDistance = 2.0f;
    Vector3 leftPosition, rightPosition;
    public Text toggleText;
    bool lerping = false;

    // Move the cube towards the left position via linear interpolation until the travel time has expired
    IEnumerator LerpLeft()
    {
        if (cube)
        {
            float t = 0;
            cube.transform.position = rightPosition;
            while(t < travelTime)
            {
                t += Time.deltaTime;
                cube.transform.position = Vector3.Lerp(rightPosition, leftPosition, t/travelTime);
                yield return 0;
            }
            cube.transform.position = leftPosition;
            StartCoroutine(LerpRight());
        }
    }

    // Move the cube towards the right position via linear interpolation until the travel time has expired
    IEnumerator LerpRight()
    {
        if (cube)
        {
            float t = 0;
            cube.transform.position = leftPosition;
            while (t < travelTime)
            {
                t += Time.deltaTime;
                cube.transform.position = Vector3.Lerp(leftPosition, rightPosition, t / travelTime);
                yield return 0;
            }
            cube.transform.position = rightPosition;
            StartCoroutine(LerpLeft());
        }
    }

    // spawn a cube at the origin and call the LerpRight coroutine
    void StartLerping()
    {
        lerping = true;
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftPosition = rightPosition = Vector3.zero;
        leftPosition.x -= travelDistance;
        rightPosition.x += travelDistance;

        StartCoroutine(LerpRight());

    }

    // stop all learping transforms and destory the cube
    void StopLerping()
    {
        StopAllCoroutines();
        Destroy(cube);
        lerping = false;
    }

    // toggle the lerp movement status of the cube
    public void ToggleLerp()
    {
        if (lerping)
        {
            StopLerping();
            toggleText.text = "Start Lerping";
        }
        else
        {
            StartLerping();
            toggleText.text = "Stop Lerping";
        }
    }
}
