using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemGet : MonoBehaviour
{
    //0:네이팜,1:시간,2:플레어
    int itemType = 0;
    PlayerState playerState;
    // Start is called before the first frame update
    void Start()
    {
        itemType = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerState = collision.gameObject.GetComponent<PlayerState>();
            if (itemType == 0&&playerState.napalmBomb<2)
            {
                playerState.napalmBomb += 1;
                GameObject.Find("NapalmCount").GetComponent<Text>().text = (playerState.napalmBomb).ToString();
            }
            else if (itemType == 1 && playerState.timeBomb < 2)
            {
                playerState.timeBomb += 1;
                GameObject.Find("TimeCount").GetComponent<Text>().text = (playerState.timeBomb).ToString();
            }
            else if (itemType == 2 && playerState.flareBomb < 2)
            {
                playerState.flareBomb += 1;
                GameObject.Find("FlareCount").GetComponent<Text>().text = (playerState.flareBomb).ToString();
            }
            Destroy(this.gameObject);
        }
    }
}
