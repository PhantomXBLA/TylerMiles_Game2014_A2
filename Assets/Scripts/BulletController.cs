using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float horizontalSpeed = 10;
    int damage = 10;
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

    public int ApplyDamage()
    {
        return damage;
    }
}
