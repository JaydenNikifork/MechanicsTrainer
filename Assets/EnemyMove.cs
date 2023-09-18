using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private GameObject Player;
    public int moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null) return;

        Vector3 moveVector = moveSpeed * Time.deltaTime * Vector3.Normalize(Player.transform.position - transform.position);
        moveVector.y = 0;
        transform.position += moveVector;
    }
}
