using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    Vector3 toLocation;
    public float moveSpeed = 5;
    public GameObject q;

    private Vector3 move(Vector3 pos)
    {
        toLocation = pos;
        return pos;
    }

    private void Start()
    {
        toLocation = gameObject.transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.transform.gameObject.name != "Player")
            {
                Vector3 point = hitInfo.point;
                move(point);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            toLocation = gameObject.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.transform.gameObject.name != "Player")
            {
                Vector3 qDir = hitInfo.point - transform.position;
                qDir.y = 0;
                Instantiate(q, gameObject.transform.position, Quaternion.LookRotation(qDir, Vector3.up));
            }
        }

        if (Vector3.Distance(toLocation, gameObject.transform.position) > 0.01)
        {
            Vector3 moveVector = Time.deltaTime * moveSpeed * Vector3.Normalize(toLocation - gameObject.transform.position);
            moveVector.y = 0;
            gameObject.transform.position += moveVector;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "BadQ")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("StartUI");
        }
    }
}
