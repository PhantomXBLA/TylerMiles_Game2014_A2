using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
Full Name:        Tyler Miles
Student ID:       101251005
File:             PlayerController.cs
Description:      This is the player controller. This controls how the player reacts to touch screen inputs, damage, shooting, animation, etc
Date last modified: Dec 12, 2021
*/

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rigidbody;

    GameObject MoveRightButton, MoveLeftButton, ShootButton, JumpButton;

    public GameObject bulletPrefab;
    GameObject circleCast;

    Animator animator;

    bool isGrounded = true;

    float playerSpeed = 3;

    bool MoveRightDown = false, MoveLeftDown = false;

    public LayerMask layerMask;

    AudioController audioController;

    public int score = 0;
    public int lives = 3;

    public Text scoreText;
    public Text LivesText;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        circleCast = this.gameObject.transform.GetChild(1).gameObject;

        GameObject[] allButtons = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allButtons)
        {
            if (go.name == "MoveRightButton")
            {
                MoveRightButton = go;
            }
            else if (go.name == "MoveLeftButton")
            {
                MoveLeftButton = go;
            }
            else if (go.name == "ShootButton")
            {
                ShootButton = go;
            }
            else if (go.name == "JumpButton")
            {
                JumpButton = go;
            }
        }

        //MoveRightButton.GetComponent<Button>().onClick.AddListener(OnMoveRightButtonPressed);
        //MoveLeftButton.GetComponent<Button>().onClick.AddListener(OnMoveLeftButtonPressed);
        ShootButton.GetComponent<Button>().onClick.AddListener(OnShootButtonPressed);
        JumpButton.GetComponent<Button>().onClick.AddListener(OnJumpButtonPressed);

        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
        LivesText.text = ("x" + lives);
    }

    // Update is called once per frame
    void Update()
    {

        if(rigidbody.velocity.x > 0)
        {
            animator.SetBool("isMoving", true);
        }

        else if (rigidbody.velocity.x < 0)
        {
            animator.SetBool("isMoving", true);
        }

        else if(rigidbody.velocity.x == 0)
        {
            animator.SetBool("isMoving", false);
        }

        Move();
        CheckGrounded();

        scoreText.text = ("Score: " + score.ToString("D5"));

        if(transform.position.y < -15)
        {
            LoseLife();
        }

    }

    public void Move()
    {
        if (MoveRightDown)
        {
            rigidbody.velocity = new Vector2(playerSpeed, rigidbody.velocity.y);
            transform.localScale = new Vector2(4, 4);
        }
        if (MoveLeftDown)
        {
            rigidbody.velocity = new Vector2(-playerSpeed, rigidbody.velocity.y);
            transform.localScale = new Vector2(-4, 4);

        }
    }
    void SpawnBullet()
    {
        bulletPrefab.GetComponent<BulletController>().transformX = this.gameObject.transform.GetChild(0).transform.position.x;
        bulletPrefab.GetComponent<BulletController>().transformY = this.gameObject.transform.GetChild(0).transform.position.y;
        Instantiate(bulletPrefab);
    }

    private void CheckGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.CircleCast(circleCast.transform.position, circleCast.GetComponent<CircleCollider2D>().radius, Vector2.down, this.gameObject.GetComponent<BoxCollider2D>().bounds.extents.y, layerMask);
        isGrounded = raycastHit;

        if(isGrounded == true)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }
    }

    private void onPlayerHit()
    {
        
    }


    public void OnMoveRightButtonPressed()
    {
        Debug.Log("MoveRight");
        MoveRightDown = true;
    }
    public void OnMoveRightButtonReleased()
    {
        Debug.Log("NotMoveRight");
        MoveRightDown = false;
    }

    public void OnMoveLeftButtonPressed()
    {
        Debug.Log("MoveRight");
        MoveLeftDown = true;
    }
    public void OnMoveLeftButtonReleased()
    {
        Debug.Log("NotMoveRight");
        MoveLeftDown = false;
    }

    void OnJumpButtonPressed()
    {
        if (isGrounded)
        {
            animator.SetTrigger("JumpTrigger");
            Debug.Log("Jump");
            rigidbody.AddForce(new Vector2(0, 350f));
        }

    }

   public void LoseLife()
    {
        audioController.PlayPlayerHit();
        lives--;
        transform.position = new Vector2(-10f, -1.6f);
        LivesText.text = ("x" + lives);
        if(lives == 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    void OnShootButtonPressed()
    {
        animator.SetTrigger("ShootTrigger");
        Debug.Log("Shoot");
        audioController.PlayPlayerShoot();
        SpawnBullet();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            LoseLife();
        }
    }

}
