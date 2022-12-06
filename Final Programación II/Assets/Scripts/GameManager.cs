using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefab1;
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

    }
}
