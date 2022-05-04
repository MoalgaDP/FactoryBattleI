using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D playerRigidbody;

    float axisX, axisY;
    bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        axisX = Input.GetAxis("Horizontal");
        axisY = Input.GetAxis("Vertical");

        isMoving = (axisX != 0) || (axisY != 0);

        // Debug.Log(axisX);
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            isMoving = false;
            
            // playerRigidbody.velocity = transform.rotation * new Vector2(axisX * moveSpeed, axisY * moveSpeed) * Time.deltaTime * 100;
            playerRigidbody.velocity = new Vector2(axisX, axisY) * Time.deltaTime * moveSpeed * 100;
            Debug.Log(new Vector2(axisX, axisY) * Time.deltaTime * moveSpeed * 100);
        }
        else
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }
}
