using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tremblingsphere : MonoBehaviour
{
    public bool blinkstarted;
    public float xspeed;
    public float yspeed;
    public float wait;
    // Start is called before the first frame update
    void Start()
    {
        blinkstarted = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Die());
        }
    }
        IEnumerator Die()
        {
            GM.score++;
            GetComponent<Animator>().SetInteger("state", 2);
        yield return new WaitForSeconds(0.03f);
            Vector3 newRotation = new(0, 0, 400 * Time.deltaTime);
            Vector3 newScale = new(0.4f * Time.deltaTime, 0.4f * Time.deltaTime, 0);
            for (int i = 0; i < 30; i++)
                {
            Vector3 square = new(Movement.xpos, Movement.ypos, 0);
            transform.position = square;
            transform.eulerAngles += newRotation;
                    transform.localScale -= newScale;
            yield return new WaitForEndOfFrame();
        }
        GM.circnum--;
            Destroy(gameObject);
    
        }
    IEnumerator Blink()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 4));
        if (GetComponent<Animator>().GetInteger("state") != 2)
        {
            GetComponent<Animator>().SetInteger("state", 1);
        }
        blinkstarted = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!blinkstarted)
        {
            blinkstarted = true;
            StartCoroutine(Blink());
            if (GetComponent<Animator>().GetInteger("state") != 2)
            {
                GetComponent<Animator>().SetInteger("state", 0);
            }
        }
        if (GetComponent<Animator>().GetInteger("state") == 0 && wait >=70 && Movement.state != -1)
        {
            wait--;
            xspeed = Random.Range(10, -10) * Time.deltaTime;
            yspeed = Random.Range(10, -10) * Time.deltaTime;
            Vector3 newTranslate = new(xspeed, yspeed, 0);
            for (int i = 0; i < (Random.Range(1, 20)); i++)
            {
                if (GetComponent<Animator>().GetInteger("state") == 0 && Movement.state != 1)
                    transform.position += newTranslate;
                if (transform.position.x < -6)
                {
                    transform.position = new Vector3(6, transform.position.y, 0);
                }
                if (transform.position.x > 6)
                {
                    transform.position = new Vector3(-6, transform.position.y, 0);
                }
                if (transform.position.y < -6)
                {
                    transform.position = new Vector3(transform.position.x, 6, 0);
                }
                if (transform.position.y > 6)
                {
                    transform.position = new Vector3(transform.position.x, -6, 0);
                }
            }
        }
        wait--;
        if (wait < 0)
        {
            wait = (Random.Range(0, 100));
        }
  
    }
}
