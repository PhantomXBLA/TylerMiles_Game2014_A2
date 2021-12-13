using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Full Name:        Tyler Miles
Student ID:       101251005
File:             TurretController.cs
Description:      This controls how the turret reacts when it's idle vs when it sees the player
Date last modified: Dec 12, 2021
*/
public class TurretController : MonoBehaviour
{
    float health = 30;
    GameObject turretBarrel;
    public LayerMask playerLayerMask;
    bool playerDetected;
    bool canFire = true;
    bool dead = false;

    Animator animator;
    PlayerController playerController;
    public GameObject turretBullet;

    AudioController audioController;
    // Start is called before the first frame update
    void Start()
    {
        turretBarrel = this.gameObject.transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        checkForPlayer();
    }

    private void checkForPlayer()
    {
        RaycastHit2D raycastHit = Physics2D.Linecast(turretBarrel.transform.position, new Vector2(turretBarrel.transform.position.x - 5, turretBarrel.transform.position.y), playerLayerMask);
        playerDetected = raycastHit;


        if (playerDetected == true)
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        if (canFire)
        {
            turretBullet.GetComponent<TurretBulletController>().transformX = turretBarrel.transform.position.x - 1;
            turretBullet.GetComponent<TurretBulletController>().transformY = turretBarrel.transform.position.y;
            Instantiate(turretBullet);
            audioController.PlayTurretShoot();
            canFire = false;
            StartCoroutine(fireTimer());
        }

    }

    IEnumerator fireTimer()
    {
        yield return new  WaitForSeconds(3);
        canFire = true;
    }

    IEnumerator destroyTurret()
    {
        dead = true;
        canFire = false;
        animator.SetTrigger("TurretDeath");
        audioController.PlayEnemyDeath2();
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            health -= 10;
            playerController.score += 50;
            if (health <= 0 && dead == false)
            {
                playerController.score += 250;
                StartCoroutine(destroyTurret());
            }
        }
    }
}
