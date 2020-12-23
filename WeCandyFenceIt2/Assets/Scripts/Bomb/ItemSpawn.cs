using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public enum itemType {flareItem=0,NapalmItem=1,timeStopItem=2 }
    GameObject player;
    public GameObject itemBomb;
    bool itemSetDelay = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickFlareSpawn()
    {
        if (itemSetDelay == false)
        {
            StartCoroutine("ItemSetDelayCoroutine");
            itemBomb.GetComponent<ItemExplosion>().myType = (int)itemType.flareItem;
            Instantiate(itemBomb, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
        }
    }
    public void OnClickNapalmSpawn()
    {
        if (itemSetDelay == false)
        {
            StartCoroutine("ItemSetDelayCoroutine");
            itemBomb.GetComponent<ItemExplosion>().myType = (int)itemType.NapalmItem;
            Instantiate(itemBomb, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
        }
    }
    public void OnClickTimeSpawn()
    {
        if (itemSetDelay == false)
        {
            StartCoroutine("ItemSetDelayCoroutine");
            itemBomb.GetComponent<ItemExplosion>().myType = (int)itemType.timeStopItem;
            Instantiate(itemBomb, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
        }
    }
    IEnumerator ItemSetDelayCoroutine()
    {
        itemSetDelay = true;
        yield return new WaitForSeconds(1f);
        itemSetDelay = false;
    }
}
