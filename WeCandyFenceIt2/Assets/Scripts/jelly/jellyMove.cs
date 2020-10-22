using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellyMove : MonoBehaviour
{
    Color[] jellyColor;
    [SerializeField]
    float fallSpeed = 2f;
    SpriteRenderer jellyRenderer;
    // Start is called before the first frame update
    void Start()
    {
        jellyRenderer = GetComponent<SpriteRenderer>();
        jellyRenderer.color = GetRandomColor();

    }

    Color GetRandomColor()
    {
        jellyColor = new Color[4] { new Color(150 / 255f, 190 / 255f, 1f, 1f), 
                    new Color(1f, 185f / 255, 180f / 255, 1f), 
                    new Color(210f / 255, 1, 180f / 255, 1f), 
                    new Color(1, 225f / 255, 180f / 255, 1f) };
        int index = Random.Range(0, 4);

        return jellyColor[index];
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
