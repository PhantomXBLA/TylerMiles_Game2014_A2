using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Full Name:        Tyler Miles
Student ID:       101251005
File:             AudioController.cs
Description:      This is the Audio controller. It contains references to all the sounds in the play scene, and functions to play them.
Date last modified: Dec 12, 2021
*/

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource LevelMusic;
    AudioSource EnemyDeath2;
    AudioSource PlayerShoot;
    AudioSource TurretShoot;
    AudioSource PlayerHit;
    void Start()
    {
        LevelMusic = this.gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        EnemyDeath2 = this.gameObject.transform.GetChild(1).GetComponent<AudioSource>();
        PlayerShoot = this.gameObject.transform.GetChild(2).GetComponent<AudioSource>();
        TurretShoot = this.gameObject.transform.GetChild(3).GetComponent<AudioSource>();
        PlayerHit = this.gameObject.transform.GetChild(4).GetComponent<AudioSource>();

        LevelMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEnemyDeath2()
    {
        EnemyDeath2.Play();
    }

    public void PlayPlayerShoot()
    {
        PlayerShoot.Play();
    }

    public void PlayTurretShoot()
    {
        TurretShoot.Play();
    }

    public void PlayPlayerHit()
    {
        PlayerHit.Play();
    }


}
