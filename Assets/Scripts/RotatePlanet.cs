using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public float xRotateSpeed;
    public float yRotateSpeed;
    public float zRotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spin();
    }

    public void spin()
    {
        transform.Rotate(xRotateSpeed, yRotateSpeed, zRotateSpeed * Time.deltaTime);
    }
}
