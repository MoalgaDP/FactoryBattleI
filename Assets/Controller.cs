using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        const float speed = 1 / 60.0f;
    
        if (Input.GetKey(KeyCode.W)) {
            transform.position += transform.up * speed;
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position -= transform.up * speed;
        }
        
        if (Input.GetKey(KeyCode.A)) {
            transform.position -= transform.right * speed;
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position += transform.right * speed;
        }
    }
}
