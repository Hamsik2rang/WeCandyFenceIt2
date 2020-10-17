using System;
using System.Collections;
using UnityEngine;

public class missileGen : MonoBehaviour
{
    public GameObject missile;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator missileGenCoroutine()
    {
        float randFloatX = UnityEngine.Random.Range(-9,9);
        float randFloatY = Mathf.Sqrt(81 - Mathf.Pow(randFloatX, 2));
        if (UnityEngine.Random.Range(-1, 1) < 0)
        {
            randFloatY = -randFloatY;
        }
        Vector2 targetDir = player.transform.position - transform.position;


        float ang = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
        //Instantiate(missile,new Vector2(randFloatX,randFloatY),)
        yield return null;
    }
}

