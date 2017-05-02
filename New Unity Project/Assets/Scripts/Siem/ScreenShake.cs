using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

    Vector3 originalCameraPosition;

    float shakeAmt = 0;

    public Camera mainCamera;

    void Update()
    {
    }

    // Makes the camera shake for 0.3 seconds
    public void StartShaking()
    {
        shakeAmt = .25f;
        InvokeRepeating("CameraShake", 0, .01f);
        Invoke("StopShaking", 0.1f);
    }

    // Creates the camera shake
    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.y += quakeAmt; // can also add to x and/or z
            pp.z = -40;
            mainCamera.transform.position = pp;
        }
    }

    // Stops the camera from shaking
    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }
}
