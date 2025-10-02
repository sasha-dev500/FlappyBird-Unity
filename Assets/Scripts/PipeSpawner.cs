using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnEvery = 1.5f;
    public Vector2 yRange = new Vector2(-5f, 5f);
    public float startX = 10f;
    private float t;

    void Update()
    {
        t += Time.deltaTime;
        if (t >= spawnEvery)
        {
            float y = Random.Range(yRange.x, yRange.y);
            Instantiate(pipePrefab, new Vector3(startX, y, 0f), Quaternion.identity);
            t = 0f;
        }
    }
}
