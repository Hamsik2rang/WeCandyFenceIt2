using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jellyMove : MonoBehaviour
{
    Color[] jellyColor;
    [SerializeField]
    float fallSpeed = 2f;
    SpriteRenderer jellyRenderer;
    public int jellyType;

    Text score;
    int[] jellyScore = { 1, 5, 10, 30, 50 };

    bool rabbitCoroutineBool = false;
    public bool kingKongHit = false;
    public int kingHp = 10;
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
        jellyLogic();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        score.text = (int.Parse(score.text) + jellyScore[jellyType]).ToString();
    }
    void jellyLogic()
    {
        if (jellyType == 0)
        {
            transform.Translate(new Vector2(0, -fallSpeed) * Time.deltaTime);
        }
        else if (jellyType == 1)
        {
            transform.Translate(new Vector2(0, -fallSpeed*2) * Time.deltaTime);
        }
        else if (jellyType == 2)
        {
            if (rabbitCoroutineBool == false)
            {
                //StartCoroutine("rabbitCoroutine");
            }
        }
        else if (jellyType == 3)
        {
            if (kingKongHit == true)
            {
                transform.Translate(new Vector2(0, -fallSpeed*3) * Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector2(0, -fallSpeed) * Time.deltaTime);
            }
        }
        else if (jellyType == 4)
        {
            transform.Translate(new Vector2(0, -fallSpeed*0.3f) * Time.deltaTime);
        }
    }
    IEnumerator rabbitCoroutine()
    {
        //TODO: 토끼 젤리 구현하기
        while (true)
        {
            transform.Translate(new Vector2(0, 0) * Time.deltaTime);
            yield return new WaitForSeconds(1);
            Debug.Log("jump");
            transform.Translate(new Vector2(0, -fallSpeed * 2) * Time.deltaTime);
            yield return new WaitForSeconds(1);
        }
    }
}
