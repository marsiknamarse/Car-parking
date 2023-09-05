using UnityEngine;

public class FinishController : MonoBehaviour
{
    public GameObject finishCanvas;
    public GameObject carObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            finishCanvas.SetActive(true);
            Rigidbody carRigidbody = carObject.GetComponent<Rigidbody>();
            if (carRigidbody != null)
            {
                carRigidbody.velocity = Vector3.zero; 
                carRigidbody.angularVelocity = Vector3.zero;
                carRigidbody.isKinematic = true; 
            }
        }
    }
}
