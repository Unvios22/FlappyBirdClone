using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Obstacle : MonoBehaviour {

	[SerializeField] private float maxHeight = 1.5f;
	[SerializeField] private float minHeight = -1.5f;
	[SerializeField] private float obstacleSpeed = 1;
	private Rigidbody2D _rigidbody2D;

	private void Awake() {
		_rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		SetRandomHeight();
		SetMotion();
	}

	private void SetRandomHeight() {
		var newPosition = new Vector3(transform.position.x, Random.Range(maxHeight, minHeight));
		transform.position = newPosition;
	}
	
	private void SetMotion() {
		var forceVector = new Vector2(-obstacleSpeed,0);
		// obstacle speed < 0 to move object to the left
		_rigidbody2D.AddForce(forceVector,ForceMode2D.Impulse);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag(Tags.DESPAWNER)) {
			Destroy(gameObject);
		}
	}
}
