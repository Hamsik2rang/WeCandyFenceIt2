using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellyGen : MonoBehaviour
{

    public GameObject jelly;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("jellyGenCoroutine");
        StartCoroutine("jellyGenStopCoroutine");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator jellyGenCoroutine()
    {
        float[] genAreaX = { -8f, 8f };
        float genAreaY = 15f;
        float delayTimes = 0.99f;
        float genDelay = 2f;
        while (true)
        {
            Instantiate(jelly, new Vector2(UnityEngine.Random.Range(genAreaX[0], genAreaX[1]), genAreaY), Quaternion.identity);
            yield return new WaitForSeconds(genDelay);
            genDelay = genDelay * delayTimes;
        }
    }
    IEnumerable jellyGenStopCoroutine()
    {
        yield return new WaitForSeconds(3600f);
        StopCoroutine("jellyGenCoroutine");
        StopCoroutine("jellyGenStopCoroutine");
    }
}
