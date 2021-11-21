using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangSeagullLogic : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime*200f;
        if (transform.position.y >= 2500)
            GameObject.Destroy(gameObject);
    }
}
