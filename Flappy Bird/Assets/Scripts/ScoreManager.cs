using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    
    [SerializeField] private Text scoreText;
    private int _score;

    public void ResetScore() {
        _score = 0;
    }

    public void IncreaseScore(int pointsAmount) {
        _score += pointsAmount;
    }
    
    private void Update() {
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay() {
        scoreText.text= "Score: " + _score; 
    }
}
