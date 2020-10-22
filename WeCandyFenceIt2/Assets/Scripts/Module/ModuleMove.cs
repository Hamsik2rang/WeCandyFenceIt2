using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleMove : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private PlayerState playerState;
    public float rotateSpeed = 200;

    void Start()
    {
        playerState = GetComponentInParent<PlayerState>();
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.RotateAround(target.transform.position, Vector3.back, rotateSpeed * Time.deltaTime + playerState.rotateQuantity);
    }
}