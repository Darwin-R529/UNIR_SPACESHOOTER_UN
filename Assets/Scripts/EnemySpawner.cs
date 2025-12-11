using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] private Transform shootPoint;

    public enum SpawnMode
    {
        Line,
        Points,
    }

    [SerializeField] SpawnMode spawnMode = SpawnMode.Line;

    [SerializeField] Transform SpawnLineTop;
    [SerializeField] Transform SpawnLineBottom;

    [SerializeField] Transform[] spawnPoints;

    void Start()
    {

        if (spawnMode == SpawnMode.Line)
        {
            StartCoroutine(LineSpawning());
        }
        else if (spawnMode == SpawnMode.Points)
        {
            int numPoints = spawnPoints.Length;
            int j = Random.Range(0, numPoints);

            float t = Random.Range(0f, 1f);
            Vector3 startPosition = spawnPoints[j].position;

            Instantiate(enemyPrefab, startPosition, Quaternion.identity);
        }
    }

    IEnumerator LineSpawning()
    {
        Vector3 lineTop = SpawnLineTop.position;
        Vector3 lineBottom = SpawnLineBottom.position;

        for (int i = 0; i < 5; i++)
        {
            float t = Random.Range(0f, 1f);
            Vector3 startPosition = Vector3.Lerp(lineTop, lineBottom, t);

            Instantiate(enemyPrefab, startPosition, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
