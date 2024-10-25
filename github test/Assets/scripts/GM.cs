using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static int score;
    public static int circnum;
    public GameObject circ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (circnum < 10)
        {
            Vector3 random = new Vector3(Random.Range(4, -4), Random.Range(4, -4),0);
            Quaternion zero = Quaternion.identity;
            circnum++;
            Instantiate(circ, random, transform.rotation);
        }
    }
}
