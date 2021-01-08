using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileCollision : MonoBehaviour
{
    MissileGenerator missileGenScript;
    int hp;
    public GameObject moduleItemPrefab;
    public GameObject itemBombPrefab;
    //0~100
    float moduleDropPersent=50;
    float itemDropPersent = 50;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        missileGenScript = GameObject.Find("Missile Spawner").GetComponent<MissileGenerator>();
        hp = 3;
        score = GameObject.Find("ScoreValue").GetComponent<Text>();
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
            DropItem();
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
                DropItem();
                Destroy(this.gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        
        
        //score += 20;
        score.text = (int.Parse(score.text) + 20).ToString();
        missileGenScript.MissileGenController();
    }
    void DropModule()
    {
        if (moduleDropPersent > Random.Range(0, 100))
        {
            Instantiate(moduleItemPrefab, this.transform.position, Quaternion.identity);
        }
    }
    void DropItem()
    {
        if (itemDropPersent > Random.Range(0, 100))
        {
            Instantiate(itemBombPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
