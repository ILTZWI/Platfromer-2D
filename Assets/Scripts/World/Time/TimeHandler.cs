using UnityEngine;

public class TimeHandler : MonoBehaviour 
{
    private const int StartTimeNumber = 1;
    private const int StopTimeNumber = 0;

    private void OnDisable()
    {
        Time.timeScale = StartTimeNumber;
    }

    private void OnEnable()
    {
        Time.timeScale = StopTimeNumber;
    }
}
