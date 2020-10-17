using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerState : MonoBehaviour
{
    private float timer;
    private int waitingTime;
    bool isAlive;

    //움직임 구현 변수들
    private Vector2 moveDirectionStart;
    private Vector2 moveDirectionNow;
    private Vector2 moveDirection;
    Rigidbody2D playerRigidbody;
    [SerializeField]
    float rotateSpeed = 90;
    [SerializeField]
    float moveSpeed = 4;

    void Start()
    {
        isAlive = true;
        timer = 0.0f;
        waitingTime = 5;

        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        Movement();

        /*
        // 5초 뒤 Player 사망
        if (timer > waitingTime)
        {
            isAlive = false;
            timer = 0.0f;
        }
        */

        if (!isAlive)
        {
            GameOver();
        }
    }

    // 게임오버 시 ResultScene 불러오기
    void GameOver()
    {
        SceneManager.LoadScene("ResultScene");
    }

    //움직임 처리
    void Movement()
    {


        //움직임 방향처리(터치용)
        /*
        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                moveDirectionStart = GameObject.Find("Jstick").transform.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                moveDirectionStart = Vector2.zero;
                moveDirection = Vector2.zero;
                GameObject.Find("JstickNob").transform.localPosition = new Vector2(0, 0);
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                moveDirection = (touch.position - moveDirectionStart).normalized;

                moveDirection = (touch.position - moveDirectionStart);
                if (moveDirection.magnitude < 50)
                {
                    GameObject.Find("JstickNob").transform.position = touch.position;
                }
                else
                {
                    GameObject.Find("JstickNob").transform.localPosition = 50* (touch.position - moveDirectionStart).normalized;
                }
                    moveDirection = (touch.position - moveDirectionStart).normalized;
                }
        }
        */
        //마우스용
        if (Input.GetMouseButtonDown(0))
        {
            moveDirectionStart = GameObject.Find("Jstick").transform.position;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveDirectionStart = Vector2.zero;
            moveDirection = Vector2.zero;
            GameObject.Find("JstickNob").transform.localPosition = new Vector2(0, 0);
        }
        else if (Input.GetMouseButton(0))
        {
            moveDirection = ((Vector2)Input.mousePosition - moveDirectionStart);
            if (moveDirection.magnitude < 50)
            {
                GameObject.Find("JstickNob").transform.position = (Vector2)Input.mousePosition;
            }
            else
            {
                GameObject.Find("JstickNob").transform.localPosition = 50 * ((Vector2)Input.mousePosition - moveDirectionStart).normalized;
            }
            moveDirection = ((Vector2)Input.mousePosition - moveDirectionStart).normalized;
            //UnityEngine.Debug.Log("방향 : " + moveDirection);
        }

        //아래부터는 공용
        moveDirectionNow = transform.up;
        float directSelect = Vector2.SignedAngle(moveDirection, moveDirectionNow);



        if (directSelect > 2 && directSelect < 180)
        {
            this.transform.Rotate(new Vector3(0, 0, -rotateSpeed) * Time.deltaTime);
        }
        else if (directSelect >= -2 && directSelect <= 2)
        {
            //보정
        }
        else
        {
            this.transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
        }
        //playerRigidbody.velocity = moveDirectionNow.normalized * Time.deltaTime * moveSpeed;
        this.transform.Translate(new Vector2(0, 1) * Time.deltaTime * moveSpeed);
    }
}
