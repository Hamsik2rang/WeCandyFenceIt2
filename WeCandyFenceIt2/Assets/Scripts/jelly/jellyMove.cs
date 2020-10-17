using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellyMove : MonoBehaviour
{
    Color[] randomColor;
    [SerializeField]
    float fallSpeed = 2f;
    SpriteRenderer jellyRenderer;
    // Start is called before the first frame update
    void Start()
    {
        jellyRenderer = GetComponent<SpriteRenderer>();

        randomColor = new Color[4] { Color.red, Color.cyan, Color.blue, Color.white };
        //fallSpeed = UnityEngine.Random.Range(0.1f, 3);
        jellyRenderer.color = randomColor[Random.Range(0, 4)];
        Debug.Log(jellyRenderer.color);
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
