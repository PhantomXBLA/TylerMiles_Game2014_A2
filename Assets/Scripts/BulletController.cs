using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Full Name:        Tyler Miles
Student ID:       101251005
File:             BulletController.cs
Description:      This is the bullet controller. This controls how the bullets move when they are spawned in.
Date last modified: Dec 12, 2021
*/

public class BulletController : MonoBehaviour
{
    float horizontalSpeed = 10;
    public float transformX;
    public float transformY;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transformX, transformY);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(horizontalSpeed, 0, 0.0f) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
