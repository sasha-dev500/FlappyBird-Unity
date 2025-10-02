using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;
   
    private int score = 0;

    [SerializeField] private Text scoreText;

    public void Add(int amount)
    {
        score += amount;
        UpdateUI();   
    }

    public void ResetScore()
    {
        score = 0;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = score.ToString(); 
    }
    
    public int CurrentScore
    {
        get { return score;}
    }
    private void Awake()
    {
        Instance = this;
    }
}
