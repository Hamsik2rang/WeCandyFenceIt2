using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour
{
    public GameObject missile;
    GameObject player;
    //TODO: 스코어와 연결, 테스트를 위해 임시로 100으로 지정
    int gameScore=99;
    float missileGenDelay = 10f;
    bool missileGenCoroutineBool = false;

    void Start()
    {
        player = GameObject.Find("Player");

        //TODO: 스코어 트리거와 연결시 삭제할것
        MissileGenController();
    }

    void Update()
    {

    }
    IEnumerator MissileGenCoroutine()
    {
        missileGenCoroutineBool = true;
        while (true)
        {
            float randFloatX = UnityEngine.Random.Range(-9, 9);
            float randFloatY = Mathf.Sqrt(81 - Mathf.Pow(randFloatX, 2));
            if (UnityEngine.Random.Range(-1, 1) < 0)
            {
                randFloatY = -randFloatY;
            }
            Vector2 targetDir = player.transform.position - transform.position;


            float ang = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            Instantiate(missile, new Vector2(randFloatX, randFloatY), Quaternion.AngleAxis(ang, Vector3.forward));
            

            yield return new WaitForSeconds(missileGenDelay);
        }
    }

    //TODO:스코어 획득 트리거와 연결할것
    public void MissileGenController()
    {
        if (50<=gameScore && gameScore<100)
        {
            missileGenDelay = 10;
            if (missileGenCoroutineBool == false)
            {
                StartCoroutine("MissileGenCoroutine");
            }
        }
        else if(100<=gameScore && gameScore < 300)
        {
            missileGenDelay = 8;

        }
        else if (300 <= gameScore && gameScore < 500)
        {
            missileGenDelay = 6;
        }
        else if (500 <= gameScore)
        {
            missileGenDelay = 4;
        }
    }
    IEnumerator MissileGenStopCoroutine()
    {
        missileGenCoroutineBool = false;
        yield return new WaitForSeconds(60f);
        StopAllCoroutines();
    }
}