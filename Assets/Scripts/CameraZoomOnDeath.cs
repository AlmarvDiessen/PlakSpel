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
    }

    public IEnumerator ZoomCamera(float zoomSpeed, float duration)
    {
        float timeElapsed = 0;

        CMcamObject.SetActive(true);

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            CMcam.m_Orbits[1].m_Radius += zoomSpeed * Time.deltaTime;

            yield return null;
        }

        StartCoroutine(MoveCamera(10));
    }

    IEnumerator MoveCamera(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        CMcamObject.SetActive(false);
    }
}
