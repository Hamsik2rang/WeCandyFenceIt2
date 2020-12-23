using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    public GameObject BombOrigin;
    float BombSpawnDelay = 10f;
    public bool BombSpawnCoroutineBool = false;
    GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        BombSpawnDelay = GameObject.Find("Player").GetComponent<PlayerState>().bombDelay;

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
        yield return new WaitForSeconds(BombSpawnDelay);
        BombSpawnCoroutineBool = false;
    }
}
