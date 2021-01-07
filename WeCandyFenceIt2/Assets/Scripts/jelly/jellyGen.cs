using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jellyGen : MonoBehaviour
{
    const float START_GEN_POINT = -8f;
    const float END_GEN_POINT = 8f;
    public GameObject jelly;
    GameObject jellyIns;
    Text score;
    int genTypeRange = 1;
    void Start()
    {
        StartCoroutine("jellyGenCoroutine");
        StartCoroutine("jellyGenStopCoroutine");
        StartCoroutine("jellyGenTypeRangeCoroutine");
        score = GameObject.Find("ScoreValue").GetComponent<Text>();
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
            jellyIns = Instantiate(jelly, new Vector2(UnityEngine.Random.Range(genPosX[0], genPosX[1]), genPosY), Quaternion.identity);
            //jellyIns.GetComponent<jellyMove>().jellyType = UnityEngine.Random.Range(0, genTypeRange);
            jellyIns.GetComponent<jellyMove>().jellyType = UnityEngine.Random.Range(4, 4);

            yield return new WaitForSeconds(genDelay);
            genDelay = genDelay * genDelayTime;
        }
    }
    IEnumerable jellyGenStopCoroutine()
    {
        yield return new WaitForSeconds(3600f);
        StopAllCoroutines();
    }
    IEnumerator jellyGenTypeRangeCoroutine()
    {
        if (int.Parse(score.text) >= 500)
        {
            genTypeRange = 5;
        }
        else if(int.Parse(score.text) >= 300)
        {
            genTypeRange = 4;
        }
        else if(int.Parse(score.text) >= 100)
        {
            genTypeRange = 3;
        }
        else if(int.Parse(score.text) >= 50)
        {
            genTypeRange = 2;
        }
        else
        {
            genTypeRange = 1;
        }
        yield return new WaitForSeconds(1000f);
    }
}
