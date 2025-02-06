using TMPro;
using UnityEngine;
using UnityEngine.UI; // This is necessary if you want to display the countdown on a UI Text element.
using Mirror;
public class CountdownTimer : NetworkBehaviour
{

    public float startTime = 60.0f; // Starting time for the countdown in seconds.
  [SyncVar] public float currentTime; // Current time of the countdown.
                              //    public TextMeshProUGUI countdownText; // Reference to a UI Text component to display the countdown.

    [Server]
    void Start()
    {
        currentTime = startTime; // Initialize the current time with the starting time.

    }

    [Server]
    void Update()
    {
        // Reduce the current time by the amount of time that has passed since the last frame.
        currentTime -= Time.deltaTime;

        // Clamp the current time to be not less than zero.
        currentTime = Mathf.Clamp(currentTime, 0, startTime);

        RpcUpdateTimer();

        // Check if the countdown has reached zero.
        if (currentTime <= 0)
        {
            if (!oneTime)
            {
                oneTime = true;

                Debug.Log("Countdown finished!");


                // Optionally, you can add any logic to execute when the countdown reaches zero.
            }

        }

    }

    [ClientRpc]
    private void RpcUpdateTimer()
    {
        //pdate the UI Text component with the current time.
        if (countdownText != null)
        {
            countdownText.text = "Time: " + Mathf.Ceil(currentTime).ToString();
        }
    }

    public void REsetTimer()
    {
        currentTime = startTime;
        oneTime = false;
    }

    bool oneTime = false;
 [SerializeField]   private Text countdownText;
}
