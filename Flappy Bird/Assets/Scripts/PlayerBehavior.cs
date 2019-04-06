using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
	public float JumpForce = 10f;
	public float maxFallVelocity = 100f;
	public float FallAccSpeed = 10f;
	private Rigidbody2D rigidbody2D;

	private void Start() {
		rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
	}

	private void Update() {
		GetUserInput();
		AddFallVelocity();
	}

	private void GetUserInput() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			rigidbody2D.velocity = Vector2.zero;
			var forceVector = new Vector2(0, JumpForce);
			rigidbody2D.AddForce(forceVector,ForceMode2D.Impulse);
		}
	}

	private void AddFallVelocity() {
		if (rigidbody2D.velocity.y >= -maxFallVelocity) {
			var forceVector = new Vector2(0, -FallAccSpeed);
			rigidbody2D.AddForce(forceVector,ForceMode2D.Force);
		}
	}
	
}
