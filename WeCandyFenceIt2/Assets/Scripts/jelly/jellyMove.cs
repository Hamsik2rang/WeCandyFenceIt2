using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellyMove : MonoBehaviour
{
    float fallSpeed;
    // Start is called before the first frame update
    void Start()
    {
        fallSpeed = UnityEngine.Random.Range(0.1f, 3);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -fallSpeed) * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
