using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    enum Direction { NEGATIVE = -1, NONE, POSITIVE };
    Color[] randomColor;

    GameObject player;
    SpriteRenderer missileRenderer;

    Vector2 currentDirection, targetDirection;

    [SerializeField]
    float rotateSpeed = 100;
    [SerializeField]
    float moveSpeed = 6.5f;

    void Start()
    {
        missileRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");

        randomColor = new Color[4] { Color.red, Color.cyan, Color.blue, Color.white };

        missileRenderer.color = randomColor[Random.Range(0, 4)];
    }


    void Update()
    {
        Rotate();
        this.transform.Translate(new Vector2(0, 1) * Time.deltaTime * moveSpeed);
    }

    void Rotate()
    {
        Direction rotateDirection;

        float directionAngle = GetDirectionAngle();

        if (directionAngle > 2 && directionAngle < 180)
            rotateDirection = Direction.NEGATIVE;
        else if (directionAngle >= -2 && directionAngle <= 2)
            rotateDirection = Direction.NONE;
        else
            rotateDirection = Direction.POSITIVE;

        float rotateQuantity = (int)rotateDirection * rotateSpeed * Time.deltaTime;

        this.transform.Rotate(new Vector3(0, 0, rotateQuantity));
    }

    float GetDirectionAngle()
    {
        currentDirection = transform.up;
        targetDirection = player.transform.position - transform.position;

        return Vector2.SignedAngle(targetDirection, currentDirection);
    }
}
