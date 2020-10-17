using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileMove : MonoBehaviour
{

    GameObject player;
    public GameObject frontPointer;
    Vector2 nowDir;
    Vector2 targetDir;
    float rotateSpeed = 40;
    float moveSpeed = 2.2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        //회전 
        nowDir = frontPointer.transform.position - transform.position;
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
}
