using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Full Name:        Tyler Miles
Student ID:       101251005
File:             TurretBulletController
Description:      This is the turret bullet controller which is the same as the player bullet controller, but it's for the turrets... remarkable
Date last modified: Dec 12, 2021
*/

public class TurretBulletController : MonoBehaviour
{
    float horizontalSpeed = -8;
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
