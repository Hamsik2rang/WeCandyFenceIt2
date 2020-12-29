using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleItem : MonoBehaviour
{
    
    enum moduleMode { interceptorModule = 0, bombDelayDown = 1, bombAreaUP = 2 }
    moduleMode moduleType;
    SpriteRenderer renderer;
    PlayerState playerState;
    Color[] color = new Color[3] { Color.red, Color.cyan, Color.blue};
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        moduleType = (moduleMode)Random.Range(0,3);
        renderer.color = color[(int)moduleType];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerState = collision.transform.GetComponent<PlayerState>();
            playerState.GetModule((int)moduleType);
            Destroy(this.gameObject);
        }
    }
}
