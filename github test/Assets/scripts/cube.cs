using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotate = new Vector3(4 * Movement.state * ((GM.score/10)+1) * Time.deltaTime, 8 * Movement.state * ((GM.score / 10) + 1) * Time.deltaTime, 16 * Movement.state * ((GM.score / 10) + 1) * Time.deltaTime);
        transform.Rotate(rotate);
    }
}
