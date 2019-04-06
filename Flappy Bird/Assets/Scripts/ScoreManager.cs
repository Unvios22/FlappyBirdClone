using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public int Score = 0;

    [SerializeField] private Text scoreText;

    private void Update() {
        scoreText.text= "Score: " + Score;
    }

    public void ResetScore() {
        Score = 0;
    }
}
