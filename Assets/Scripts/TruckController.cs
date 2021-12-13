using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{

    float horizontalSpeed = -2;
    bool playerColliding = false;
    bool hasSpawned = false;

    public GameObject truckPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerColliding == false)
        {
            Move();
        }
        else
        {
            Stop();
        }
        CheckBounds();
    }

    void Move()
    {


        if(transform.position.y < 1.5)
        {
            transform.position += new Vector3(0, -horizontalSpeed, 0.0f) * Time.deltaTime;
        }
        else
        {
            horizontalSpeed = -2;
            transform.position += new Vector3(horizontalSpeed, 0, 0.0f) * Time.deltaTime;
        }
    }

    void Stop()
    {
        horizontalSpeed = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerColliding = false;
        }
    }

    private void CheckBounds() 
    {
     if(this.gameObject.transform.position.x < -15)
        {
            transform.position = new Vector2(22.26f, -9.53f);
        }
    }
}
