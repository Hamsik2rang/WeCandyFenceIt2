using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    float BombWaitTime = 2f;
    float BombExplosionRadius = 2f;
    CircleCollider2D BombExplosionAreaCollider;
    // Start is called before the first frame update
    private void Start()
    {
        BombExplosionAreaCollider = GetComponent<CircleCollider2D>();
        BombExplosionAreaCollider.enabled=false;
        BombExplosionAreaCollider.radius = BombExplosionRadius;
        StartCoroutine("BombExplosionCoroutine");
        Debug.Log("bombset");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BombExplosionCoroutine()
    {
        yield return new WaitForSeconds(BombWaitTime);
        BombExplosionAreaCollider.enabled = true;
        Debug.Log("bomb");
        //TODO: 애니메이션 추가
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("input");

        if (collision.gameObject.tag == "Jelly")
        {
            Destroy(collision.gameObject);
            //TODO: 스코어 추가
        }
    }
}
