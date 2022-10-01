using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperMove : MonoBehaviour
{
    public GameObject flipperRight;
    public GameObject flipperLeft;

    private float startAngleR, startAngleL;
    private float moveAngle = 90.0f;

    private Flipper fRightScript;
    private Flipper fLeftScript;
    // Start is called before the first frame update
    void Start()
    {
        startAngleR = flipperRight.transform.eulerAngles.z;
        startAngleL = flipperLeft.transform.eulerAngles.z;

        fRightScript = flipperRight.GetComponent<Flipper>();
        fLeftScript = flipperLeft.GetComponent<Flipper>();
    }

    // Update is called once per frame
    void Update()
    {
        // Flipper Right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            flipperRight.transform.eulerAngles = new Vector3(0, 0, startAngleR + moveAngle);
            fRightScript.moved = true;
        }
        else
        {
            flipperRight.transform.eulerAngles = new Vector3(0, 0, startAngleR);
            fRightScript.moved = false;
        }

        // Flipper Left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            flipperLeft.transform.eulerAngles = new Vector3(0, 0, startAngleL - moveAngle);
            fLeftScript.moved = true;
        }
        else
        {
            flipperLeft.transform.eulerAngles = new Vector3(0, 0, startAngleL);
            fLeftScript.moved = false;
        }

    }

}
