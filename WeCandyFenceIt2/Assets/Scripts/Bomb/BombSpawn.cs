using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    public GameObject BombOrigin;
    float BombSpawnDelay = 10f;
    bool BombSpawnCoroutineBool = false;
    GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        
    }

    public void OnClickBombSpawn()
    {
        if (BombSpawnCoroutineBool == false)
        {
            StartCoroutine("BombSpawnCoroutine");
        }
    }
    IEnumerator BombSpawnCoroutine()
    {
        BombSpawnCoroutineBool = true;
        Instantiate(BombOrigin, new Vector2(Player.transform.position.x, Player.transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(10f);
        BombSpawnCoroutineBool = false;
    }
}
