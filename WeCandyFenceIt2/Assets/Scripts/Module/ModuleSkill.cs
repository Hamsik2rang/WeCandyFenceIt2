using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleSkill : MonoBehaviour
{
    public GameObject bullet;
    enum moduleMode {interceptorModule=0,bombDelayDown=1, bombAreaUP=2 }
    // Start is called before the first frame update
    public int modeInput = -1;
    moduleMode mode;
    void Awake()
    {
        
    }
    public void MyAwake()
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
        }
        else if (mode == moduleMode.bombDelayDown)
        {
            float bombDelay = this.GetComponentInParent<PlayerState>().bombRadius;
            bombDelay = bombDelay * 0.5f;
        }
        else if (mode == moduleMode.bombAreaUP)
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
            distance = 0;
            shotVecter = Vector2.zero;
            GameObject[] missile = GameObject.FindGameObjectsWithTag("Missile");
            
            if (missile.Length > 0)
            {
                for (int i = 0; i < missile.Length; i++)
                {
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

                float ang = Vector3.SignedAngle(Vector3.up,shotVecter,Vector3.forward);

                Instantiate(bullet, this.transform.position, Quaternion.Euler(new Vector3(0,0,180+ang)));


            }
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnDestroy()
    {
        if (mode == moduleMode.interceptorModule)
        {
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
