using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rigidbody;

    GameObject MoveRightButton, MoveLeftButton, ShootButton, JumpButton;

    public GameObject bulletPrefab;

    Animator animator;

    bool isGrounded = true;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

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

        MoveRightButton.GetComponent<Button>().onClick.AddListener(OnMoveRightButtonPressed);
        MoveLeftButton.GetComponent<Button>().onClick.AddListener(OnMoveLeftButtonPressed);
        ShootButton.GetComponent<Button>().onClick.AddListener(OnShootButtonPressed);
        JumpButton.GetComponent<Button>().onClick.AddListener(OnJumpButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidbody.velocity.y == 0)
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
        else
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);

        }

        if(rigidbody.velocity.x > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void FixedUpdate()
    {
        
    }

    void SpawnBullet()
    {
        bulletPrefab.GetComponent<BulletController>().transformX = this.gameObject.transform.GetChild(0).transform.position.x;
        bulletPrefab.GetComponent<BulletController>().transformY = this.gameObject.transform.GetChild(0).transform.position.y;
        Instantiate(bulletPrefab);
    }

    void OnMoveLeftButtonPressed()
    {
        Debug.Log("MoveLeft");
    }

    void OnMoveRightButtonPressed()
    {
        Debug.Log("MoveRight");
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

    void OnShootButtonPressed()
    {
        animator.SetTrigger("ShootTrigger");
        Debug.Log("Shoot");
        SpawnBullet();
        
    }

}