using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOnDeath : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(ZoomCamera(10, 1));
    }

    public IEnumerator ZoomCamera(float zoomSpeed, float duration)
    {
        float timeElapsed = 0;

        while(timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            Camera.main.transform.position -= transform.forward * (zoomSpeed) * Time.deltaTime;

            yield return null;
        }

        StartCoroutine(MoveCamera(10, 10));
    }

    IEnumerator MoveCamera(float cameraSpeed, float duration)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            float mouseX = Input.GetAxis("Mouse X");

            Camera.main.transform.LookAt(new Vector3(0, 0, 0));
            Camera.main.transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f), 20 * Time.deltaTime * cameraSpeed * mouseX);

            yield return null;
        }
    }
}
