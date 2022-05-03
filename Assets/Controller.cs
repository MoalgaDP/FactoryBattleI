using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D playerRigidbody;

    Vector2 axisMove;       // 実際にプレイヤーの移動角度に反映される「入力値」
    bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float axisInputX = Input.GetAxis("Horizontal");
        float axisInputY = Input.GetAxis("Vertical");
        Vector2 axisInput = new Vector2(axisInputX, axisInputY);        // キーボードなどから受け取る入力値

        bool isJoystickConnected = Input.GetJoystickNames().Length != 0;

        if (isJoystickConnected)
        {
            axisMove = axisInput;
        }
        else
        {
            float axisInputR, axisInputTheta;
            float axisMoveR, axisMoveTheta;

            axisInputR = axisInput.magnitude;
            axisMoveR = axisInputR;

            axisInputTheta = Mathf.Atan2(axisInput.y, axisInput.x);
            axisMoveTheta = axisInputTheta - Mathf.Sin(2 * axisInputTheta) * 15 * Mathf.Deg2Rad;        // 斜め入力が ±30°, ±150° のいずれかになるように調整

            axisMove = new Vector2(Mathf.Cos(axisMoveTheta), Mathf.Sin(axisMoveTheta)) * axisMoveR;
        }

        isMoving = !axisMove.Equals(Vector2.zero);
        // Debug.Log(axisMove);
        // Debug.Log(isMoving);
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            isMoving = false;
            
            playerRigidbody.velocity = axisMove * Time.deltaTime * moveSpeed * 100;
        }
        else
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }
}
