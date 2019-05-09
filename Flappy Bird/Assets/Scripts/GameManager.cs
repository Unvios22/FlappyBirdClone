using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	[SerializeField] private Text gameOverText;
	[SerializeField] private ScoreManager scoreManager;
	
	private PlayerBehavior _player;
	private bool _isGameOver;
	private bool _isGameStarted;

	public void GameOver() {
		_isGameOver = true;
		_player.enabled = false;
		gameOverText.gameObject.SetActive(true);
		Time.timeScale = 0f;
	}
	
	private void Start() {
		_player = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerBehavior>();
		Time.timeScale = 0f;
		_player.enabled = false;
	}

	private void Update() {
		if (!_isGameStarted & Input.GetKeyDown(KeyCode.Space)) {
			StartGame();
		}
		
		if (_isGameOver & Input.GetKeyDown(KeyCode.Space)){
			RestartGame();
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
	
	private void StartGame() {
		Time.timeScale = 1f;
		_player.enabled = true;
		_isGameStarted = true;
	}

	private void RestartGame() {
		_isGameOver = false;
		_player.enabled = true;
		gameOverText.gameObject.SetActive(false);
		Time.timeScale = 1f;
		ResetGameState();
		
	}

	private void ResetGameState() {
		foreach (var obstacle in FindObjectsOfType<Obstacle>()) {
			Destroy(obstacle.gameObject);
		}
		_player.transform.position = new Vector2(0,0);
		_player.ResetPlayerState();
		scoreManager.ResetScore();
	}
}
