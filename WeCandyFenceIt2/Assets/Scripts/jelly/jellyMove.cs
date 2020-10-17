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

        randomColor = new Color[4] { new Color(150 / 255f, 190 / 255f, 1f, 1f), new Color(1f, 185f / 255, 180f / 255, 1f), new Color(210f / 255, 1, 180f / 255, 1f), new Color(1, 225f / 255, 180f / 255, 1f) };
        //fallSpeed = UnityEngine.Random.Range(0.1f, 3);
        int index = Random.Range(0, 4);
        jellyRenderer.color = randomColor[index];
        Debug.Log(index + "  " + jellyRenderer.color);
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
