using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour
{
    private float totalTimePlayed = 0f;

    [SerializeField] TextMeshProUGUI timeText;

    private void Update()
    {
        totalTimePlayed += Time.deltaTime;

        UpdateTime(totalTimePlayed);
    }

    private void UpdateTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
