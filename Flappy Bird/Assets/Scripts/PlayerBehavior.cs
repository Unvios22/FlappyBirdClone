using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
	[SerializeField] private float jumpForce = 10f;
	[SerializeField] private float maxFallVelocity = 100f;
	[SerializeField] private float fallAccSpeed = 10f;
	[SerializeField] private float tiltDownSpeed = 1f;
	private Rigidbody2D rigidbody2D;
	private Quaternion forwardRotation;
	private Quaternion downRotation;

	private void Start() {
		rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		forwardRotation = Quaternion.Euler(0,0,35);
		downRotation = Quaternion.Euler(0,0,-90);
	}

	private void Update() {
		GetUserInput();
		AddFallVelocity();
	}

	private void GetUserInput() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			rigidbody2D.velocity = Vector2.zero;
			var forceVector = new Vector2(0, jumpForce);
			rigidbody2D.AddForce(forceVector,ForceMode2D.Impulse);
			transform.rotation = forwardRotation;
		}
		transform.rotation = Quaternion.Lerp(transform.rotation,downRotation,tiltDownSpeed * Time.deltaTime);

	}

	private void AddFallVelocity() {
		if (rigidbody2D.velocity.y >= -maxFallVelocity) {
			var forceVector = new Vector2(0, -fallAccSpeed);
			rigidbody2D.AddForce(forceVector,ForceMode2D.Force);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag(Tags.OBSTACLE)) {
			//TODO: Implement losing mechanic
			Debug.Log("YOU DIED!");
		}
	}
}
