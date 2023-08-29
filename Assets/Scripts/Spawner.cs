using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Patterns")]
    public GameObject[] easyPatterns;
    public GameObject[] mediumPatterns;
    public GameObject[] hardPatterns;

    [Header("Time")]
    public float startTimeBtwSpawns; //1.5
    private float TimeBtwSpawns; 
    public float decrease; //.02
    public float spawnRate;

    [Header("Regulations")]
    public float minTime;
    public float minHeight;
    public float maxHeight;
    public float minSpawn;

    public GameManager gameManager;

    bool isStarted;

    // Start is called before the first frame update
    void Start()
    {
        TimeBtwSpawns = startTimeBtwSpawns;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    isStarted = gameManager.isStarted;

    //    TimeBtwSpawns -= Time.deltaTime;
    //    if (TimeBtwSpawns <= 0 && isStarted)
    //    {
    //        if (startTimeBtwSpawns <= 1.1f && startTimeBtwSpawns > 0.8f)
    //        {
    //            Debug.Log("Medium");
    //            GameObject obstacle = Instantiate(mediumPatterns[Random.Range(0, mediumPatterns.Length)], new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
    //            obstacle.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    //            gameManager.GetComponent<GameManager>().AddScore(100);
    //        }
    //        if (startTimeBtwSpawns <= 0.8f && startTimeBtwSpawns > 0.6f)
    //        {
    //            Debug.Log("Hard");
    //            GameObject obstacle = Instantiate(hardPatterns[Random.Range(0, hardPatterns.Length)], new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
    //            obstacle.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    //            gameManager.GetComponent<GameManager>().AddScore(150);
    //        }
    //        else 
    //        {
    //            Debug.Log("Easy");
    //            GameObject obstacle = Instantiate(easyPatterns[Random.Range(0, easyPatterns.Length)], new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
    //            obstacle.transform.position += Vector3.left * Random.Range(minHeight, maxHeight);
    //            gameManager.GetComponent<GameManager>().AddScore(50);
    //        }

    //        if (startTimeBtwSpawns > minTime)
    //        {
    //            startTimeBtwSpawns -= decrease;
    //        }

    //        TimeBtwSpawns = startTimeBtwSpawns;
    //    }
    //}

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    void Spawn()
    {
        if(startTimeBtwSpawns > 0.4f)
        {
            Debug.Log("Easy");
            GameObject obstacle = Instantiate(easyPatterns[Random.Range(0, easyPatterns.Length)], new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            obstacle.transform.position += Vector3.left * Random.Range(minHeight, maxHeight);
            gameManager.GetComponent<GameManager>().AddScore(50);
        }
        if (startTimeBtwSpawns <= 0.4f && startTimeBtwSpawns > 0.3f)
        {
            Debug.Log("Medium");
            GameObject obstacle = Instantiate(mediumPatterns[Random.Range(0, mediumPatterns.Length)], new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            obstacle.transform.position += Vector3.left * Random.Range(minHeight, maxHeight);
            gameManager.GetComponent<GameManager>().AddScore(100);
        }
        if (startTimeBtwSpawns <= 0.3f /*&& startTimeBtwSpawns > 0.6f*/)
        {
            Debug.Log("Hard");
            GameObject obstacle = Instantiate(hardPatterns[Random.Range(0, hardPatterns.Length)], new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            obstacle.transform.position += Vector3.left * Random.Range(minHeight, maxHeight);
            gameManager.GetComponent<GameManager>().AddScore(150);
        }

        if (startTimeBtwSpawns > minTime){ startTimeBtwSpawns -= decrease * Time.deltaTime; }

        if (spawnRate > minSpawn){ spawnRate -= decrease * Time.deltaTime; }
    }
}
