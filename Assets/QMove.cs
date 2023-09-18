using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QMove : MonoBehaviour
{
    public float MoveSpeed = 20;
    private Vector3 startPos;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        if (Vector3.Distance(transform.position, startPos) > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            ScoreKeeper.Increment();
        }
    }
}
