using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    Color[] randomColor;
    GameObject player;
    SpriteRenderer missileRenderer;
    Vector2 nowDir;
    Vector2 targetDir;
    [SerializeField]
    float rotateSpeed = 100;
    [SerializeField]
    float moveSpeed = 6.5f;
    // Start is called before the first frame update
    void Start()
    {
        missileRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");

        randomColor = new Color[4] { Color.red, Color.cyan, Color.blue, Color.white };

        missileRenderer.color = randomColor[Random.Range(0, 4)];

        Invoke("DestroyMissile", 15);
    }

    // Update is called once per frame
    void Update()
    {

        //회전 
        nowDir = transform.up;
        targetDir = player.transform.position - transform.position;


        //float ang = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);

        float rotateDir = Vector2.SignedAngle(targetDir, nowDir);
        if (rotateDir > 2 && rotateDir < 180)
        {
            this.transform.Rotate(new Vector3(0, 0, -rotateSpeed) * Time.deltaTime);
        }
        else if (rotateDir >= -2 && rotateDir <= 2)
        {
            //보정
        }
        else
        {
            this.transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
        }
        this.transform.Translate(new Vector2(0, 1) * Time.deltaTime * moveSpeed);

    }

    void DestroyMissile()
    {
        //TODO:추후 폭발애니메이션 삽입할것
        Destroy(this.gameObject);
    }


}
