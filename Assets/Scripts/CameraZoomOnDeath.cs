using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraZoomOnDeath : MonoBehaviour
{
    CinemachineFreeLook CMcam;
    public GameObject CMcamObject;

    private void Start()
    {
        CMcam = CMcamObject.GetComponent<CinemachineFreeLook>();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(ZoomCamera(10f, 1f, 5f));
    }

    public IEnumerator ZoomCamera(float zoomSpeed, float duration, float lookAroundTime)
    {
        float timeElapsed = 0;

        CMcamObject.SetActive(true);

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            CMcam.m_Orbits[1].m_Radius += zoomSpeed * Time.deltaTime;

            yield return null;
        }

        StartCoroutine(MoveCamera(lookAroundTime));
    }

    IEnumerator MoveCamera(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        CMcamObject.SetActive(false);
    }
}
