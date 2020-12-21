using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemExplosion : MonoBehaviour
{
    /*
        0: flare
        1: Napalm
        2: TimeStop
    */
    public int myType;
    float explosionRadius = 2f;
    CircleCollider2D explosionArea;
    
    // Start is called before the first frame update
    void Start()
    {
        explosionArea = GetComponent<CircleCollider2D>();
        explosionArea.enabled = false;
        explosionArea.radius = explosionRadius;
        switch (myType)
        {
            case 0:
                StartCoroutine("FlareSetCoroutineStart");
                break;
            case 1:
                StartCoroutine("NapalmSetCoroutineStart");
                break;
            case 2:
                StartCoroutine("TimeStopSetCoroutineStart");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FlareSetCoroutineStart()
    {
        yield return new WaitForSeconds(1f);
        explosionArea.enabled = true;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
    IEnumerator NapalmSetCoroutineStart()
    {
        yield return new WaitForSeconds(1f);
        for(int i = 0; i < 10; i++)
        {
            explosionArea.enabled = true;
            yield return new WaitForSeconds(0.1f);
            explosionArea.enabled = false;
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }
    IEnumerator TimeStopSetCoroutineStart()
    {
        yield return new WaitForSeconds(1f);
        //TODO: 시간정지 폭탄 만들기
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D targetCollider)
    {
        GameObject targetObject = targetCollider.gameObject;
        if (myType == 0)
        {
            if (targetObject.tag == "Missile")
            {
                Debug.Log("flare!");
                Destroy(targetObject);
            }
        }
        else if (myType == 1)
        {
            if (targetObject.tag == "Jelly")
            {
                Debug.Log("napalm");
                Destroy(targetObject);
            }
        }
    }
}
