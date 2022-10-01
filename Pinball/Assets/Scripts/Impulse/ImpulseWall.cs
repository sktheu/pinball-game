using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseWall : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            spr.enabled = true;
            boxCollider.isTrigger = false;
        }
    }

}
