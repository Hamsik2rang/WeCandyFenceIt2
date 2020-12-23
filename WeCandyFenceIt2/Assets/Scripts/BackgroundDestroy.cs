using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDestroy : MonoBehaviour
{
    static float BG_SIZE = 30.0f;

    BackgroundGen backgroundGen;
    GameObject player;
    Vector2 bgPos;
    float xDiff, yDiff;
 
    // Start is called before the first frame update
    void Start()
    {
        backgroundGen = GameObject.Find("BackgroundGenerator").GetComponent<BackgroundGen>();
        player = GameObject.Find("Player");
        bgPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(BgDestroyCoroutine());
    }

    IEnumerator BgDestroyCoroutine()
    {
        xDiff = Mathf.Abs(player.transform.position.x - gameObject.transform.position.x);
        yDiff = Mathf.Abs(player.transform.position.y - gameObject.transform.position.y);

        if (xDiff >= 2 * BG_SIZE || yDiff >= 2 * BG_SIZE)
        {
            backgroundGen.bgList.Remove(new Vector2(bgPos.x / BG_SIZE, bgPos.y / BG_SIZE));
            Destroy(gameObject);
        }

        yield return new WaitForSeconds(0.2f);
    }
}
