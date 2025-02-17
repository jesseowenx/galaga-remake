using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SurvivalTimer : MonoBehaviour
{
    public TextMeshProUGUI survivalTimeText;
    private float survivalTime = 0f;

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            survivalTime += Time.deltaTime;
        }
        DisplaySurvivalTime();
    }

    private void DisplaySurvivalTime()
    {
        int minutes = Mathf.FloorToInt(survivalTime / 60f);
        int seconds = Mathf.FloorToInt(survivalTime % 60f);
        survivalTimeText.text = "Time survived: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
