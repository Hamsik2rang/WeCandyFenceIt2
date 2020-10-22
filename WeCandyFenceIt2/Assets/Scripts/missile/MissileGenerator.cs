using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour
{
    public GameObject missile;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine("missileGenCoroutine");
        StartCoroutine("missileGenStopCoroutine");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator missileGenCoroutine()
    {
        float GenDelay = 20f;
        float GenDelayTimes = 0.9f;
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

            yield return new WaitForSeconds(GenDelay);
            GenDelay = GenDelay * GenDelayTimes;
        }
    }
    IEnumerator missileGenStopCoroutine()
    {
        yield return new WaitForSeconds(60f);
        StopAllCoroutines();

    }
}