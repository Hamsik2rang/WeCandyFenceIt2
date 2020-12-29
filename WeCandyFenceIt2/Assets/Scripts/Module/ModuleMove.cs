using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleMove : MonoBehaviour
{
    [SerializeField]
    private PlayerState playerState;
    public float rotateSpeed = 200;

    GameObject target;
    //TODO: 모듈위치 배정 함수 검증 필요
    void Start()
    {
        target = this.transform.parent.gameObject;
        playerState = GetComponentInParent<PlayerState>();
        for(int i = 0; i < playerState.moduleList.Length; i++)
        {
            if (playerState.moduleList[i] == null)
            {
                playerState.moduleList[i] = this.gameObject;
                break;
            }
        }
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        //TODO: 공전 반지름 조절 방법 마련
        transform.RotateAround(target.transform.position, Vector3.back, (rotateSpeed * Time.deltaTime + playerState.rotateQuantity));
    }
}