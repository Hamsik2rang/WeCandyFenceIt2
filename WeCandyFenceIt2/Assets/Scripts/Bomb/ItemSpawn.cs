using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSpawn : MonoBehaviour
{
    public enum itemType {flareItem=0,NapalmItem=1,timeStopItem=2 }
    GameObject player;
    public GameObject itemBomb;
    bool itemSetDelay = false;
    PlayerState playerState;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerState = player.GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickFlareSpawn()
    {
        if (itemSetDelay == false&&playerState.flareBomb>0)
        {
            playerState.flareBomb -= 1;
            StartCoroutine("ItemSetDelayCoroutine");
            itemBomb.GetComponent<ItemExplosion>().myType = (int)itemType.flareItem;
            Instantiate(itemBomb, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
            GameObject.Find("FlareCount").GetComponent<Text>().text = (playerState.flareBomb).ToString();
        }
    }
    public void OnClickNapalmSpawn()
    {
        if (itemSetDelay == false&&playerState.napalmBomb>0)
        {
            playerState.napalmBomb -= 1;
            StartCoroutine("ItemSetDelayCoroutine");
            itemBomb.GetComponent<ItemExplosion>().myType = (int)itemType.NapalmItem;
            Instantiate(itemBomb, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
            GameObject.Find("NapalmCount").GetComponent<Text>().text = (playerState.napalmBomb).ToString();
        }
    }
    public void OnClickTimeSpawn()
    {
        if (itemSetDelay == false&&playerState.timeBomb>0)
        {
            playerState.timeBomb -= 1;
            StartCoroutine("ItemSetDelayCoroutine");
            itemBomb.GetComponent<ItemExplosion>().myType = (int)itemType.timeStopItem;
            Instantiate(itemBomb, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
            GameObject.Find("TimeCount").GetComponent<Text>().text = (playerState.timeBomb).ToString();
        }
    }
    IEnumerator ItemSetDelayCoroutine()
    {
        itemSetDelay = true;
        yield return new WaitForSeconds(1f);
        itemSetDelay = false;
    }
}
