using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCircle : MonoBehaviour
{
    public GameObject points10;
    public GameObject points25;
    public GameObject points50;

    private GameObject ball;
    private BallMove ballScript;

    private bool bonusTime = false;
    private float bonusTimeFrames = 0, bonusTimeMaxFrames = 2.5f;

    private bool canBonus = true;
    private float canBonusFrames = 0, canBonusMaxFrames = 20f;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballScript = ball.GetComponent<BallMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bonusTime)
        {
            if (bonusTimeFrames <= bonusTimeMaxFrames)
            {
                bonusTimeFrames += Time.deltaTime;
                ball.transform.position = this.transform.position;
                if (Random.Range(0, 100) < 40)
                {
                    setRandomPoints();
                }
                
            }
            else
            {
                bonusTimeFrames = 0;
                bonusTime = false;
                canBonus = false;
            }
            
        }

        if (!canBonus)
        {
            canBonusFrames += Time.deltaTime;
            if (canBonusFrames >= canBonusMaxFrames)
            {
                canBonusFrames = 0;
                canBonus = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (canBonus)
            {
                bonusTime = true;
            }
        }
    }

    void setRandomPoints()
    {

        float offX = Random.Range(-8f, 8f);
        float offY = Random.Range(-8f, 8f);

        Vector3 spawnPos = ball.transform.position;
        spawnPos.x += offX;
        spawnPos.y += offY;

        int rand = Random.Range(0, 100);
        float destroyTime = 1f;

        if (rand < 20)
        {
            // 50
            GameObject point = Instantiate(points50, spawnPos, Quaternion.identity);
            Destroy(point, destroyTime);
            ballScript.score += 50;
        }
        else if (rand < 40)
        {
            // 25
            GameObject point = Instantiate(points25, spawnPos, Quaternion.identity);
            Destroy(point, destroyTime);
            ballScript.score += 25;
        }
        else
        {
            // 10
            GameObject point = Instantiate(points10, spawnPos, Quaternion.identity);
            Destroy(point, destroyTime);
            ballScript.score += 10;
        }
    }
}
