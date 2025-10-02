using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Panels")]
    public GameObject menuPanel;
    public GameObject gameOverPanel;

    [Header("UI Texts")]
    public Text finalScoreText;

    public enum GameState { Menu, Playing, GameOver }
    public GameState currentState = GameState.Menu;

    private void Awake()
    {
        if (Instance == null) Instance = this; else Destroy(gameObject);
        menuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    private void Start()
    {
        Time.timeScale = 0f; 
    }

    public void StartGame()
    {
        menuPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        Score.Instance.ResetScore();

        Time.timeScale = 1f;
        currentState = GameState.Playing;

        var bird = Object.FindFirstObjectByType<Bird>();
        if (bird != null) bird.EnablePhysics();
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        gameOverPanel.SetActive(true);
        if (finalScoreText != null)
            finalScoreText.text = "Score: " + Score.Instance.CurrentScore;

        Debug.Log($"[GM] GameOver: score={Score.Instance.CurrentScore}, text={(finalScoreText ? finalScoreText.name : "NULL")}");

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
