using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField] private GameObject obstaclePrefab;
	[SerializeField] private Transform spawnPoint;
	[SerializeField] private float spawnInterval = 3;

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
		Instantiate(obstaclePrefab,spawnPoint.position, Quaternion.identity);
	}
}
