using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    private float timer;
    private float MaxTime;

    int chooseObstacle;

    void Start()
    {
        MaxTime = 3f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= MaxTime)
        {
            generateObstacle();
            randomMaxTime();
            timer = 0;

        }


    }

    void randomMaxTime()
    {
        MaxTime = Random.Range(1, 4);
    }

    void generateObstacle()
    {
        chooseObstacle = Random.Range(1, 4);
        if (chooseObstacle == 1) { Instantiate(prefab1); }
        if (chooseObstacle == 2) { Instantiate(prefab2); }
        if (chooseObstacle == 3) { Instantiate(prefab3); }

    }*/

    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }

    public SpawnableObject[] objects;

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;

        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}
