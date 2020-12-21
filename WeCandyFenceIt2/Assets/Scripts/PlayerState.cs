using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerState : MonoBehaviour
{
    const int JOYSTICK_MOVING_RANGE = 50;
    const int POSITIVE = -1;
    const int NEGATIVE = 1;

    enum Direction { POSITIVE = -1, NONE = 0, NEGATIVE = 1 };

    GameObject joyStick;
    GameObject joyStickKnob;

    //움직임 구현 변수들
    private Vector2 originStickPosition;    //moveDirectionStart
    private Vector2 currentDirection;       //moveDirectionNow
    private Vector2 moveDirection;          

    [SerializeField]
    float rotateSpeed = 90;
    [SerializeField]
    float moveSpeed = 4;
    bool isAlive;

    public float rotateQuantity
    {
        get;
        private set;
    } = 0f;

    void Start()
    {
        joyStick = GameObject.Find("JoyStick");
        joyStickKnob = GameObject.Find("JoyStickKnob");
        isAlive = true;
    }

    void Update()
    {
        Move();

        if (!isAlive)
        {
            GameOver();
        }
    }

    // 게임오버 시 ResultScene 불러오기
    public void GameOver()
    {
        SceneManager.LoadScene("ResultScene");
    }

    //움직임 처리
    void Move()
    {
        Direction rotateDirection;

        float directionAngle = GetDirectionAngle();

        if (directionAngle > 2 && directionAngle < 180)
            rotateDirection = Direction.POSITIVE;
        else if (directionAngle >= -2 && directionAngle <= 2)
            rotateDirection = Direction.NONE;
        else
            rotateDirection = Direction.NEGATIVE;
        
        Rotate(rotateDirection);

        transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
    }

    void Rotate(Direction rotateDirection)
    {
        rotateQuantity = (int)rotateDirection * rotateSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, rotateQuantity));
    }

    float GetDirectionAngle()
    {
        currentDirection = transform.up;

        //움직임 방향처리(터치용)
        /*
        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                originPosition = GameObject.Find("Jstick").transform.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                originPosition = Vector2.zero;
                moveDirection = Vector2.zero;
                GameObject.Find("JstickNob").transform.localPosition = new Vector2(0, 0);
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                moveDirection = (touch.position - originPosition).normalized;

                moveDirection = (touch.position - originPosition);
                if (moveDirection.magnitude < 50)
                {
                    GameObject.Find("JstickNob").transform.position = touch.position;
                }
                else
                {
                    GameObject.Find("JstickNob").transform.localPosition = 50* (touch.position - originPosition).normalized;
                }
                    moveDirection = (touch.position - originPosition).normalized;
                }
        }
        */

        //마우스용
        if (Input.GetMouseButtonDown(0))
        {
            originStickPosition = joyStick.transform.position;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            originStickPosition = Vector2.zero;
            moveDirection = Vector2.zero;
            joyStickKnob.transform.localPosition = new Vector2(0, 0);
        }

        else if (Input.GetMouseButton(0))
        {
            moveDirection = ((Vector2)Input.mousePosition - originStickPosition);

            if (moveDirection.magnitude < JOYSTICK_MOVING_RANGE)
                joyStickKnob.transform.position = (Vector2)Input.mousePosition;
            else
                joyStickKnob.transform.localPosition = JOYSTICK_MOVING_RANGE * ((Vector2)Input.mousePosition - originStickPosition).normalized;
            
            moveDirection = moveDirection.normalized;
        }

        return Vector2.SignedAngle(moveDirection, currentDirection);
    }
}