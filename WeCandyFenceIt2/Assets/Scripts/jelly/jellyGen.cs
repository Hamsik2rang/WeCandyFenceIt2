using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellyGen : MonoBehaviour
{
    const float START_GEN_POINT = -8f;
    const float END_GEN_POINT = 8f;
    public GameObject jelly;

    void Start()
    {
        StartCoroutine("jellyGenCoroutine");
        StartCoroutine("jellyGenStopCoroutine");
    }

    void Update()
    {

    }
    IEnumerator jellyGenCoroutine()
    {
        float[] genPosX = { START_GEN_POINT, END_GEN_POINT };
        float genPosY = 15f;
        float genDelayTime = 0.99f;
        float genDelay = 2f;
        while (true)
        {
            Instantiate(jelly, new Vector2(UnityEngine.Random.Range(genPosX[0], genPosX[1]), genPosY), Quaternion.identity);
            yield return new WaitForSeconds(genDelay);
            genDelay = genDelay * genDelayTime;
        }
    }
    IEnumerable jellyGenStopCoroutine()
    {
        yield return new WaitForSeconds(3600f);
        StopAllCoroutines();
    }
}
