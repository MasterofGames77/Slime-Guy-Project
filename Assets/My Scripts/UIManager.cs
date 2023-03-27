using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private TextMeshProUGUI levelTimerText;

    [SerializeField] private TextMeshProUGUI gemsText;

    [SerializeField] private GameObject Player;

    public Button restartButton;

    public Button nextLevelButton;

    public Button quitButton;

    public GameObject levelCompleteScreen;

    private float timeLeft;

    //private float startTime = 0;

    private bool isGameActive;

    private int seconds;

    private static int gemsCollected;

    private static UIManager uiManagerInstance;

    //private static TokenInstance tokenInstance;


    // Start is called before the first frame update
    void Start()
    {
        if (uiManagerInstance == null)
        {
            uiManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1.0f;
        isGameActive = true;
        timeLeft += Time.deltaTime;
        gemsCollected = 0;
        Player.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        gemsText.gameObject.SetActive(true);
        gemsText.text = $"Gems: " + gemsCollected.ToString();
        restartButton.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            timeLeft += Time.deltaTime;
            timerText.SetText("Time: " + Mathf.Round(timeLeft));
            if (timeLeft <= 0)
            {
                Debug.Log("Game Over!");
            }
        }
    }

    public void CollectedGem(int gemsToAdd)
    {
        gemsCollected += gemsToAdd;
        gemsText.text = $"Gems: " + gemsCollected.ToString();
        Debug.Log("Gem Collected");
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1.0f;
        ResetTimer();
        timeLeft = Time.deltaTime;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("The next level has been loaded");
        isGameActive = true;
        Player.gameObject.SetActive(true);
        gemsCollected = 0;
        levelCompleteScreen.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        ResetTimer();
        timeLeft = Time.deltaTime;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("The Scene has been reloaded.");
        isGameActive = true;
        Player.gameObject.SetActive(true);
        gemsCollected = 0;
        levelCompleteScreen.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    public void ResetTimer()
    {
        Time.timeScale = 1.0f;
        timeLeft = 0;
        Debug.Log("Reset the Timer");
    }

    public void LevelCompleted()
    {
        Time.timeScale = 0.0f;
        levelCompleteScreen.gameObject.SetActive(true);
        levelTimerText.gameObject.SetActive(true);
        levelTimerText.SetText("Final Time: " + Mathf.Round(timeLeft) + " Seconds");
        levelTimerText = timerText;
        timerText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        nextLevelButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }
}
