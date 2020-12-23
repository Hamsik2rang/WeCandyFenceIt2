using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCollision : MonoBehaviour
{
    MissileGenerator missileGenScript;
    // Start is called before the first frame update
    void Start()
    {
        missileGenScript = GameObject.Find("Missile Spawner").GetComponent<MissileGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D targetCollider)
    {
        GameObject targetObject = targetCollider.gameObject;
        if (targetObject.tag == "Player")
        {
            //TODO: 플레이어 격추시 모듈 감소 처리 및 게임오버 연결
            PlayerState PlayerStateScript = targetObject.GetComponent<PlayerState>();
            PlayerStateScript.GameOver();
            Destroy(this.gameObject);
        }
        if (targetObject.tag == "Missile")
        {
            Destroy(targetObject);
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        //TODO:스코어와 연결
        missileGenScript.MissileGenController();
        //각각의 미사일이 파괴될때 작동한다.
        //score += 20;
    }
}
