using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartImpulse : MonoBehaviour
{
    private GameObject ball;
    private float time = 0;
    private float enableTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ballPos = ball.transform.position;
        if (ballPos.y > this.transform.position.y)
        {
            time += Time.deltaTime;
            if (time >= enableTime)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
