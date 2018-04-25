using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject tank;
    [SerializeField] private GameObject healer;
    [SerializeField] private GameObject flagBearer;
    [SerializeField] private GameObject sniper;
    [SerializeField] private GameObject barbarian;

    [SerializeField] private int enemyResources;

    private float timer;
    [SerializeField] private float resourcesPerSecond;
    public bool isEnemyDead;
    private float spawnTimer;
    [SerializeField] private float timeToSpawn;
    public bool updateList;
    private List<GameObject> spawningObjects;

    // Use this for initialization
    void Start()
    {
        isEnemyDead = false;
        spawningObjects = new List<GameObject>();
        updateList = false;
        updateSpawnList();

        enemyResources = 100;
        //resourcesPerSecond = 4;

        timer = 0.0f;
        spawnTimer = 0.0f;
        //timeToSpawn = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnemyDead || GameObject.Find("Main Camera").GetComponent<GamePause>().isPlayerDead)
        {
            if (timer > (1.0 / resourcesPerSecond))
            {
                enemyResources++;
                timer = 0.0f;
            }

            if (spawnTimer >= timeToSpawn)
            {
                GenerateUnits();
                spawnTimer = 0.0f;
            }
            if (updateList)
            {
                updateList = false;
                updateSpawnList();
            }
            timer += Time.deltaTime;
            spawnTimer += Time.deltaTime;
        }
    }

    public void GenerateUnits()
    {
        int rand = (int)Mathf.Floor(Random.value * 5.0f) + 1;
        GameObject createType = null;
        if (rand == 1)
        {
            createType = tank;
        }
        else if (rand == 2)
        {
            createType = healer;
        }
        else if (rand == 3)
        {
            updateList = true;
            createType = flagBearer;
        }
        else if (rand == 4)
        {
            createType = sniper;
        }
        else if (rand == 5)
        {
            createType = barbarian;
        }
        if (createType != null && enemyResources >= createType.GetComponent<UnitScript>().unitCost)
        {
            createType.GetComponent<UnitGeneralBehavior>().goesRight = false;
            int randBase = Random.Range(0, spawningObjects.Count - 1);

            GameObject selectedBase = spawningObjects[randBase];
            Instantiate(createType, selectedBase.transform.position, Quaternion.identity);

            enemyResources -= createType.GetComponent<UnitScript>().unitCost;
        }
    }

    private void updateSpawnList()
    {
        spawningObjects.Clear();
        GameObject[] bases = GameObject.FindGameObjectsWithTag("EnemyBase");
        for (int i = 0; i < bases.GetLength(0); i++)
            spawningObjects.Add(bases[i]);

        if (spawningObjects.Count == 0)
        {
            YouWin();
        }

        GameObject[] allUnits = GameObject.FindGameObjectsWithTag("Unit");
        for (int i = 0; i < allUnits.GetLength(0); i++)
        {
            if ((allUnits[i].GetComponent<UnitScript>().thisUnitType == UnitScript.unitTypes.Flagbearer) &&
                (allUnits[i].GetComponent<UnitGeneralBehavior>().goesRight == false))
            {
                spawningObjects.Add(allUnits[i]);
            }
        }


    }


    void YouWin()
    {
        isEnemyDead = true;
        GameObject.Find("Main Camera").GetComponentInChildren<GamePause>().isEnemyDead = true;
    }
}