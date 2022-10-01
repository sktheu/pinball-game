using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool kickY = false, kickX = false;
    private float speedH = 15f, speedV = 15f;
    private float dx = 0, dy = 0;

    public GameObject points10;
    public GameObject points25;
    public GameObject points50;


    public int score;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Voltar para o menu
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void FixedUpdate()
    {
        // Aplicando Força/Impulso na bola
        if (kickY)
        {
            kickY = false;
            rb.AddForce(new Vector2(0, dy * speedV), ForceMode2D.Impulse);
        }
        
        if (kickX)
        {
            kickX = false;
            rb.AddForce(new Vector2(dx * speedH, 0), ForceMode2D.Impulse);
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flipper")
        {
            if (collision.gameObject.GetComponent<Flipper>().moved == true)
            {
                if (dy <= 0)
                {
                    dy = 1;
                }
                kickY = true;
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall Right" || collision.gameObject.tag == "Wall Left")
        {
            if (collision.gameObject.tag == "Wall Right")
            {
                dx = -1;
            }
            else
            {
                dx = 1;
            }
            kickX = true;
        }else if (collision.gameObject.tag == "Wall Up")
        {
            if (dy > 0)
            {
                dy = 0;
            }
            kickY = true;
        }else if (collision.gameObject.tag == "Wall Down")
        {
            // Game Over
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }else if (collision.gameObject.tag == "Circle")
        {
            changeDirX();
            changeDirY();
            kickX = true;
            kickY = true;
            if (Random.Range(0, 100) < 30)
            {
                setPoints(points50);
            }
            else
            {
                setPoints(points25);
            }
            
        }
    }



    void changeDirX()
    {
        if (dx > 0)
        {
            dx = -1;
        }else if (dx < 0)
        {
            dx = 1;
        }
        else
        {
            if (Random.Range(0, 100) < 50)
            {
                dx = 1;
            }
            else
            {
                dx= -1;
            }
        }
    }


    void changeDirY()
    {
        if (dy > 0)
        {
            dy = 0;
        }
        else
        {
            dy = 1;
        }
    }

    void setPoints(GameObject pointPrefab)
    {
        
        float offX = Random.Range(-2f, 2f);
        float offY = 0;

        Vector3 spawnPoint = transform.position;
        spawnPoint.x += offX;
        spawnPoint.y += offY;

        GameObject points = Instantiate(pointPrefab, spawnPoint, Quaternion.identity);
        float destroyTime = 1f;
        Destroy(points, destroyTime);


        // Aplicando pontos
        if (points.gameObject.tag == "10points")
        {
            score += 10;
        }
        else if (points.gameObject.tag == "25points")
        {
            score += 25;
        }else if (points.gameObject.tag == "50points")
        {
            score += 50;
        }

    }
}
