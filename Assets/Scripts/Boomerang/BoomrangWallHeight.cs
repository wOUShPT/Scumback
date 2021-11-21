using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomrangWallHeight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x,Random.Range(300f, 750f),0f);
    }
}
