using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static float state;
    public float speed = 10f;
    public static float xpos;
    public static float ypos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetInteger("state", 0);
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 4)
        {
            GetComponent<Animator>().SetInteger("state", 1);
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -4)
        {
            GetComponent<Animator>().SetInteger("state", 1);
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 4)
        {
            GetComponent<Animator>().SetInteger("state", 1);
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -4)
        {
            GetComponent<Animator>().SetInteger("state", 1);
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space) && GetComponent<Animator>().GetInteger("state") >= 1)
        {
            speed = 10;
            GetComponent<Animator>().SetInteger("state", 2);
        }
        else
        {
            speed = 4;
        }
        state = GetComponent<Animator>().GetInteger("state") + 1;
        if (GetComponent<Animator>().GetInteger("state") >= 1)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else { gameObject.GetComponent<BoxCollider2D>().enabled = false; }
        xpos = transform.position.x;
        ypos = transform.position.y;
    }
}
