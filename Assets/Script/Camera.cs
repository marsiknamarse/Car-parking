using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Car; // —сылка на объект машины, за которой будет следить камера
    public float speed = 1.5f;

    void FixedUpdate()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = Car.transform.position;

        Vector3 newPosition = targetPosition - Car.transform.forward * 45.0f + Vector3.up * 50.0f;
        transform.position = Vector3.Lerp(currentPosition, newPosition, speed * Time.deltaTime);

        transform.LookAt(targetPosition);
    }
}
