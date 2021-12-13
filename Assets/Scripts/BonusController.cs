using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Full Name:        Tyler Miles
Student ID:       101251005
File:             BonusController.cs
Description:      This is the bonus controller. It determines what happens when the player collides with the bonus.
Date last modified: Dec 12, 2021
*/

public class BonusController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().score += 5000;
            Destroy(this.gameObject);
        }
    }
}
