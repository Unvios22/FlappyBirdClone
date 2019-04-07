using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
	[SerializeField] private float jumpForce = 12f;
	[SerializeField] private float maxFallVelocity = 10f;
	[SerializeField] private float fallAccSpeed = 10f;
	[SerializeField] private float tiltDownSpeed = 1f;
	
	private Rigidbody2D _rigidbody2D;
	private Quaternion _forwardRotation;
	private Quaternion _downRotation;
	private ScoreManager _scoreManager;
	private GameManager _gameManager;

	private void Start() {
		_rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		_forwardRotation = Quaternion.Euler(0,0,45);
		_downRotation = Quaternion.Euler(0,0,-90);
		_scoreManager = FindObjectOfType<ScoreManager>();
		_gameManager = FindObjectOfType<GameManager>();
	}

	private void Update() {
		GetUserInput();
		AddFallVelocity();
	}

	private void GetUserInput() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			ApplyJumpForce();
			transform.rotation = _forwardRotation;
		}	
		transform.rotation = Quaternion.Lerp(transform.rotation,_downRotation,tiltDownSpeed * Time.deltaTime);

	}

	private void ApplyJumpForce() {
		_rigidbody2D.velocity = Vector2.zero;
		var forceVector = new Vector2(0, jumpForce);
		_rigidbody2D.AddForce(forceVector,ForceMode2D.Impulse);
	}

	private void AddFallVelocity() {
		if (_rigidbody2D.velocity.y >= -maxFallVelocity) {
			var forceVector = new Vector2(0, -fallAccSpeed);
			_rigidbody2D.AddForce(forceVector,ForceMode2D.Force);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag(Tags.OBSTACLE_KILL)) {
			_gameManager.GameOver();
			Debug.Log("YOU DIED!");
		}
		else if (other.gameObject.CompareTag(Tags.OBSTACLE_TRIGGER)) {
			_scoreManager.Score++;
		}
	}

	public void ResetState() {
		_rigidbody2D.velocity = Vector2.zero;
		transform.rotation = _forwardRotation;
	}
}
