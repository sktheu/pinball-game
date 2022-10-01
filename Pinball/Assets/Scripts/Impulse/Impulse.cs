using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{

    private float speed = 2f;
    private float ballForceX = 10f, ballForceY = 100f;
    private float impulseFrames = 0;

    private float startY = 0;
    private float minY = 0;

    private bool canImpulse = false;

    // Start is called before the first frame update
    void Start()
    {
        startY = gameObject.transform.position.y;
        minY = GameObject.FindGameObjectWithTag("Wall Down").transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && !canImpulse)
        {
            if (transform.position.y > minY)
            {
                transform.position -= (transform.up * speed) * Time.deltaTime;
                impulseFrames++;
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            canImpulse = true;
            transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && canImpulse)
        {
            Rigidbody2D rbBall = collision.gameObject.GetComponent<Rigidbody2D>();
            rbBall.AddForce(new Vector2((impulseFrames * ballForceX )* Time.deltaTime, (impulseFrames * ballForceY) * Time.deltaTime), ForceMode2D.Impulse);
        }   
    }
}
