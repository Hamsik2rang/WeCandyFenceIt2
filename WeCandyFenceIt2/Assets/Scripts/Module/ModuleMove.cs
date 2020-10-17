using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleMove : MonoBehaviour
{
    public GameObject target;
    public GameObject module;
    public float spd = 200;

    void Start()
    {

    }

    void Update()
    {
        ModuleRotation();
    }

    void ModuleRotation()
    {
        transform.RotateAround(target.transform.position, new Vector3(0.0f, 0.0f, -1.0f), spd * Time.deltaTime);
    }
}