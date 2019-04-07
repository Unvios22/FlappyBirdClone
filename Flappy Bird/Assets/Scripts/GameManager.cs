﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private bool isGameOver;
	private bool isGameStarted;
	[SerializeField] private Text gameOverText;
	[SerializeField] private ScoreManager scoreManager;
	[SerializeField] private PlayerBehavior player;

	private void Start() {
		player = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerBehavior>();
		Time.timeScale = 0f;
	}

	private void Update() {
		if (!isGameStarted & Input.GetKeyDown(KeyCode.Space)) {
			StartGame();
		}
		
		if (isGameOver & Input.GetKeyDown(KeyCode.Space)){
			RestartGame();
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void GameOver() {
		isGameOver = true;
		player.enabled = false;
		gameOverText.gameObject.SetActive(true);
		Time.timeScale = 0f;
	}
	
	
	private void StartGame() {
		Time.timeScale = 1f;
		isGameStarted = true;
	}

	private void RestartGame() {
		isGameOver = false;
		player.enabled = true;
		gameOverText.gameObject.SetActive(false);
		Time.timeScale = 1f;
		ResetGameState();
		
	}

	private void ResetGameState() {
		foreach (var obstacle in FindObjectsOfType<Obstacle>()) {
			Destroy(obstacle.gameObject);
		}
		player.transform.position = new Vector2(0,0);
		player.ResetState();
		scoreManager.ResetScore();
	}
}
