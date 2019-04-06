using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField] private GameObject obstaclePrefab;
	[SerializeField] private float spawnInterval = 3;
	[SerializeField] private Transform spawnPoint;

	private void Start() {
		StartCoroutine(SpawnObstacles());
	}

	private IEnumerator SpawnObstacles() {
		for (;;) {
			SpawnObstacle();
			yield return new WaitForSeconds(spawnInterval);
		}
	}

	private void SpawnObstacle() {
		var obstacle = Instantiate(obstaclePrefab,spawnPoint.position, Quaternion.identity);
	}
}
