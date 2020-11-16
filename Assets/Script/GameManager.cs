using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyObjects;
    public GameObject[] citrusObjects;
    public Transform[] spawnPoints;

    public GameObject player;
    public Text scoreText;
    public Image[] lifeImage;
    public GameObject gameOverSet;

    public float maxSpawnDelay;
    public float curSpawnDelay;

 
    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            SpawnCitrus();
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;
        }

        //UI Score Update
        PlayerMove playerLogic = player.GetComponent<PlayerMove>();
        scoreText.text = string.Format("{0:n0}", playerLogic.point); 
    }
    /*
    public void UpdateLifeIcon(int life)
    {
        //UI Life Init Disable
        for (int index = 0; index < 3; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 0);
        }

        //UI Life Active
        for (int index = 0; index < life; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 1);
        }
    }
    */
    void SpawnEnemy()
    {
        int ranEnemy = 0;
        int ranPoint = Random.Range(0, 5);
        Instantiate(enemyObjects[ranEnemy], spawnPoints[ranPoint].position,
            spawnPoints[ranPoint].rotation);
        }

    void SpawnCitrus()
    {
        int ranCitrus = 0;
        int ranPoint = Random.Range(0, 5);
        Instantiate(citrusObjects[ranCitrus], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);

    }
    
}
