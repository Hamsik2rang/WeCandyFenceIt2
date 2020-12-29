using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCollision : MonoBehaviour
{
    MissileGenerator missileGenScript;
    int hp;
    public GameObject moduleItemPrefab;
    //0~100
    float moduleDropPersent=50;
    // Start is called before the first frame update
    void Start()
    {
        missileGenScript = GameObject.Find("Missile Spawner").GetComponent<MissileGenerator>();
        hp = 3;
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
            if (PlayerStateScript.ModuleCount() == 0)
            {
                PlayerStateScript.GameOver();
            }
            else
            {
                while (true)
                {
                    int index = ((int)Random.Range(0, 100))%3;
                    GameObject target;
                    if (PlayerStateScript.moduleList[index] != null)
                    {
                        target = PlayerStateScript.moduleList[index];
                        PlayerStateScript.moduleList[index] = null;
                        Destroy(target);
                        break;
                    }
                }
            }
            Destroy(this.gameObject);
        }
        if (targetObject.tag == "Missile")
        {
            DropModule();
            Destroy(targetObject);
            Destroy(this.gameObject);
        }
        if (targetObject.tag == "Bullet")
        {
            Destroy(targetObject);
            hp--;
            if (hp == 0)
            {
                DropModule();
                Destroy(this.gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        
        //TODO:스코어와 연결
        missileGenScript.MissileGenController();
        //각각의 미사일이 파괴될때 작동한다.
        //score += 20;
    }
    void DropModule()
    {
        if (moduleDropPersent > Random.Range(0, 100))
        {
            Instantiate(moduleItemPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
