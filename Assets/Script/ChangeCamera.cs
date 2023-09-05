using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    void Start()
    {
        ActivateCamera(currentCameraIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchCamera(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchCamera(1); 
        }
    }

    void SwitchCamera(int newCameraIndex)
    {
        cameras[currentCameraIndex].gameObject.SetActive(false);

        ActivateCamera(newCameraIndex);

        currentCameraIndex = newCameraIndex;
    }

    void ActivateCamera(int cameraIndex)
    {
        cameras[cameraIndex].gameObject.SetActive(true);
    }
}
