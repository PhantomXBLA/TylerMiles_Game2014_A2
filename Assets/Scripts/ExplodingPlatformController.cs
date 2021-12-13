using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Full Name:        Tyler Miles
Student ID:       101251005
File:             ExplodingPlatformController
Description:      This determines what happens when a player touches this platform
Date last modified: Dec 12, 2021
*/

public class ExplodingPlatformController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator explosionTimer()
    {
        yield return new WaitForSeconds(3.5f);
        animator.SetTrigger("TurretDeath");
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(explosionTimer());
        }
    }
}
