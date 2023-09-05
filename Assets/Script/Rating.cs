using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] objectiveTexts; 
    public Text scoreText; 

    private int remainingObjectives = 3; 

    private void Start()
    {
        UpdateObjectiveText(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cone")) 
        {
            if (remainingObjectives > 0)
            {
                remainingObjectives--; 
                UpdateObjectiveText(); 

                if (remainingObjectives == 2)
                {
                    scoreText.text = "A";
                }
                else if (remainingObjectives == 1)
                {
                    scoreText.text = "B";
                }
                else if (remainingObjectives == 0)
                {
                    scoreText.text = "C";
                }
            }
        }
    }

    private void UpdateObjectiveText()
    {
        for (int i = 0; i < objectiveTexts.Length; i++)
        {
            if (i < remainingObjectives)
            {
                objectiveTexts[i].text = "X";
            }
            else
            {
                objectiveTexts[i].text = ""; 
            }
        }
    }
}
