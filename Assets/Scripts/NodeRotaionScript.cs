using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeRotaionScript : MonoBehaviour {

    public Transform[] cubes;
    private float randNumX;
    private float randNumY;
    private float randNumZ;
    public float rotationSpeed;


    // Update is called once per frame
    void Update () {
        foreach(Transform cube in cubes){
            randNumX = Random.Range(0f, 60.0f);
            randNumY = Random.Range(0f, 60.0f);
            randNumZ = Random.Range(0f, 60.0f);
            cube.transform.Rotate(randNumX * rotationSpeed * Time.deltaTime, randNumY * rotationSpeed * Time.deltaTime, randNumZ * rotationSpeed * Time.deltaTime);
        }
        
    }
}
