using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    float moveSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector2(0, 1) * Time.deltaTime * moveSpeed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
