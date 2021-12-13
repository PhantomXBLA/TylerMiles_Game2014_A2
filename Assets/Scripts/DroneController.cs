using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Full Name:        Tyler Miles
Student ID:       101251005
File:             DroneController.cs
Description:      This controls how the drone behaves when it spawns in and/or spots the player
Date last modified: Dec 12, 2021
*/
public class DroneController : MonoBehaviour
{
    GameObject DroneEyesight;
    public LayerMask playerLayerMask;
    bool playerDetected;
    bool droneCharging;

    float horizontalSpeed = -10;
    float health = 50;

    Animator animator;
    AudioController audioController;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        DroneEyesight = this.gameObject.transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        checkForPlayer();

        if(droneCharging == true)
        {
            transform.position += new Vector3(horizontalSpeed, 0, 0.0f) * Time.deltaTime;
        }
    }

    private void checkForPlayer()
    {
        RaycastHit2D raycastHit = Physics2D.Linecast(DroneEyesight.transform.position, new Vector2(DroneEyesight.transform.position.x - 8, DroneEyesight.transform.position.y), playerLayerMask);
        playerDetected = raycastHit;


        if (playerDetected == true)
        {
            droneCharging = true;
            Debug.Log("PlayerSighted");
        }
    }

    IEnumerator destroyTurret()
    {
        droneCharging = false;
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
            if (health <= 0)
            {
                playerController.score += 500;
                StartCoroutine(destroyTurret());
            }
        }
    }

}
