using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBadQs : MonoBehaviour
{
    public GameObject BadQ;
    public GameObject Enemy;
    private GameObject Player;
    private float time = 0;
    public float radius = 10;

    void spawnQ()
    {
        float spawnAngle = Random.Range(0, 2 * Mathf.PI);
        float spawnX = Mathf.Cos(spawnAngle) * radius;
        float spawnZ = Mathf.Sin(spawnAngle) * radius;
        Vector3 spawnPos = new Vector3(spawnX, 0, spawnZ);
        Vector3 dirVec = Player.transform.position - spawnPos;
        dirVec.x += Random.Range(-0.25f, 0.25f);
        dirVec.z += Random.Range(-0.25f, 0.25f);

        GameObject badQ = Instantiate(BadQ, spawnPos, Quaternion.LookRotation(dirVec));
        badQ.tag = "BadQ";
    }
    void spawnEnemy()
    {
        float spawnAngle = Random.Range(0, 2 * Mathf.PI);
        float spawnX = Mathf.Cos(spawnAngle) * radius;
        float spawnZ = Mathf.Sin(spawnAngle) * radius;
        Vector3 spawnPos = new Vector3(spawnX, 0.25f, spawnZ);
        Vector3 dirVec = Player.transform.position - spawnPos;
        dirVec.x += Random.Range(-1, 1);
        dirVec.z += Random.Range(-1, 1);

        GameObject enemy = Instantiate(Enemy, spawnPos, Quaternion.LookRotation(dirVec));
        enemy.tag = "Enemy";
    }

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 1)
        {
            time = 0;
            if (Player != null)
            {
                spawnQ();
                spawnEnemy();
            }
        } 
        else
        {
            time += Time.deltaTime;
        }
    }
}
