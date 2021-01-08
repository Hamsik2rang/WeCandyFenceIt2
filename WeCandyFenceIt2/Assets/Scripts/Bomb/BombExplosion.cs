using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    float BombWaitTime = 2f;
    float BombExplosionRadius = 2f;
    CircleCollider2D BombExplosionAreaCollider;
    jellyMove jellyScript;
    // Start is called before the first frame update
    private void Start()
    {
        BombExplosionAreaCollider = GetComponent<CircleCollider2D>();
        BombExplosionAreaCollider.enabled=false;
        BombExplosionRadius = GameObject.Find("Player").GetComponent<PlayerState>().bombRadius;
        BombExplosionAreaCollider.radius = BombExplosionRadius;
        StartCoroutine("BombExplosionCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BombExplosionCoroutine()
    {
        yield return new WaitForSeconds(BombWaitTime);
        BombExplosionAreaCollider.enabled = true;
        //TODO: 애니메이션 추가
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jelly")
        {
            jellyScript = collision.gameObject.GetComponent<jellyMove>();

            if (jellyScript.jellyType == 3)
            {
                if (jellyScript.kingKongHit == false)
                {
                    jellyScript.kingKongHit = true;
                }
                else
                {
                    jellyScript.Explosion();
                    Destroy(collision.gameObject);
                }
            }
            else if (jellyScript.jellyType == 4)
            {
                if (jellyScript.kingHp > 1)
                {
                    jellyScript.kingHp -= 1;
                }
                else if (jellyScript.kingHp == 1)
                {
                    jellyScript.Explosion();
                    Destroy(collision.gameObject);
                }
            }
            else
            {
                jellyScript.Explosion();
                Destroy(collision.gameObject);
            }
            
        }
    }
}
