using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] meteorPrefabs;
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

            int index = Random.Range(0, meteorPrefabs.Length);
            GameObject selectedMeteor = meteorPrefabs[index];
            Instantiate(selectedMeteor, startPosition, Quaternion.identity);

        }
    }

    IEnumerator LineSpawning()
    {
        Vector3 lineTop = SpawnLineTop.position;
        Vector3 lineBottom = SpawnLineBottom.position;

        for (int i = 0; i < 100; i++)
        {
            float t = Random.Range(0f, 1f);
            Vector3 startPosition = Vector3.Lerp(lineTop, lineBottom, t);

            int index = Random.Range(0, meteorPrefabs.Length);
            GameObject selectedMeteor = meteorPrefabs[index];
            Instantiate(selectedMeteor, startPosition, Quaternion.identity);


            yield return new WaitForSeconds(2f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
