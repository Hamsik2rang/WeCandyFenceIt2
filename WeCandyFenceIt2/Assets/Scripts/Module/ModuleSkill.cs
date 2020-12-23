using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleSkill : MonoBehaviour
{
    public GameObject bullet;
    enum moduleMode {interceptorModule=0,bombDelayDown=1, bombAreaUP=2 }
    // Start is called before the first frame update
    int modeInput = 0;
    moduleMode mode;
    void Awake()
    {
        switch (modeInput)
        {
            case 0:
                mode = moduleMode.interceptorModule;
                break;
            case 1:
                mode = moduleMode.bombDelayDown;
                break;
            case 2:
                mode = moduleMode.bombAreaUP;
                break;
        }
        if (mode == moduleMode.interceptorModule)
        {
            StartCoroutine("InterceptorCorroutine");
            Debug.Log("start");
        }
        else if (mode == moduleMode.bombDelayDown)
        {
            float bombDelay = this.GetComponentInParent<PlayerState>().bombRadius;
            bombDelay = bombDelay * 0.5f;
        }
        else if(mode == moduleMode.bombAreaUP)
        {
            float bombRadius = this.GetComponentInParent<PlayerState>().bombRadius;
            bombRadius = bombRadius * 1.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float distance = 0;
    int missileNumber = 0;
    Vector2 shotVecter;
    Vector2 missileVector;
    Vector2 playerVector;
    Vector2 missileVectorFOR;
    Vector2 playerVectorFOR;
    IEnumerator InterceptorCorroutine()
    {
        while (true)
        {
            Debug.Log("now");
            distance = 0;
            shotVecter = Vector2.zero;
            GameObject[] missile = GameObject.FindGameObjectsWithTag("Missile");
            
            if (missile.Length > 0)
            {
                for (int i = 0; i < missile.Length; i++)
                {
                    Debug.Log(missile[i].name);
                    missileVectorFOR = missile[i].transform.position;
                    playerVectorFOR = this.transform.parent.transform.position;
                    if (distance == 0 || distance > Vector2.Distance(missileVectorFOR, playerVectorFOR))
                    {
                        missileNumber = i;
                        
                    }
                }
                missileVector = missile[missileNumber].transform.transform.position;
                playerVector = this.transform.parent.transform.position;
                shotVecter = playerVector-missileVector;
                Debug.Log("missile : " + missileVector);
                Debug.Log("player : " + playerVector);
            }
            float ang = Mathf.Atan2(shotVecter.y, shotVecter.x) * Mathf.Rad2Deg;
            Instantiate(bullet, this.transform.position, Quaternion.AngleAxis(ang, Vector3.forward));
            
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnDestroy()
    {
        if (mode == moduleMode.interceptorModule)
        {
            Debug.Log("stop");
            StopAllCoroutines();
        }
        else if (mode == moduleMode.bombDelayDown)
        {
            float bombDelay = this.GetComponentInParent<PlayerState>().bombRadius;
            bombDelay = bombDelay * 2f;
        }
        else if (mode == moduleMode.bombAreaUP)
        {
            float bombRadius = this.GetComponentInParent<PlayerState>().bombRadius;
            bombRadius = (bombRadius * 10) / 12;
        }
    }
}
