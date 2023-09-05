using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public GameObject restartCanvas;
    public Canvas speedCanvas;
    public Text speedText;
    public Text[] errorTexts;
    public GameObject carObject;

    private float previousSpeed;
    private float lastUpdateTime;
    private const float updateInterval = 0.8f;

    private Rigidbody carRigidbody;
    private bool isCrashed = false;
    private int errorsLeft = 3; 
    private const int maxCollisions = 2;
    private int currentErrorIndex = 0; 

    private Vector3 initialPosition;

    private void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        restartCanvas.SetActive(false);
        initialPosition = transform.position;

        UpdateErrorText(); // Оновлення тексту з помилками на початку
    }

    private void Update()
    {
        float currentSpeed = carRigidbody.velocity.magnitude;

        if (Mathf.Abs(currentSpeed - previousSpeed) > 5f || Time.time - lastUpdateTime > updateInterval)
        {
            speedText.text = currentSpeed.ToString("F0");
            lastUpdateTime = Time.time;
        }

        previousSpeed = currentSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cone") && !isCrashed)
        {
            errorsLeft--;

            if (errorsLeft <= 0)
            {
                isCrashed = true;
                Rigidbody carRigidbody = carObject.GetComponent<Rigidbody>();
                if (carRigidbody != null)
                {
                    carRigidbody.velocity = Vector3.zero;
                    carRigidbody.angularVelocity = Vector3.zero;
                    carRigidbody.isKinematic = true;
                }

                UpdateErrorText();

                restartCanvas.SetActive(true);
            }
            else
            {
                errorTexts[currentErrorIndex].color = Color.red;

                currentErrorIndex = (currentErrorIndex + 1) % errorTexts.Length;

                UpdateErrorText();
            }
        }
    }

    private void UpdateErrorText()
    {
        for (int i = 0; i < errorTexts.Length; i++)
        {
            errorTexts[i].text = i < errorsLeft ? "X" : "";
        }
    }
}
