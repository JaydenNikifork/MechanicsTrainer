using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadQMove : MonoBehaviour
{
    public float MoveSpeed = 30;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        if (Vector3.Distance(transform.position, startPos) > 50)
        {
            Destroy(gameObject);
        }
    }
}
