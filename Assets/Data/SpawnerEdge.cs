using UnityEngine;

public class SpawnerEdge : MonoBehaviour
{
    [SerializeField] private GameObject edge;
    [SerializeField] Transform[] pointSpawn = new Transform[4];
    public static float timeSpawn = 2f;

    private void Start()
    {
        timeSpawn = 2f;
        Invoke("RandomSpawner", timeSpawn);
    }

    private void RandomSpawner()
    {
        Instantiate<GameObject>(edge, pointSpawn[RandomPositionEdge()]);
        Invoke("RandomSpawner", timeSpawn);
    }

    private int RandomPositionEdge()
    {
       return Random.Range(0, pointSpawn.Length);
    }



}
