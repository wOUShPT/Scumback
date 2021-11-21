using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangSummonSeagull : MonoBehaviour
{
    public float OddsIn1000 = 1f;
    public GameObject SeagullPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 1000) <= OddsIn1000)
        {
            GameObject go = GameObject.Instantiate(SeagullPrefab, transform);
            go.transform.position = new Vector3(Random.Range(610, 1310), go.transform.position.y, go.transform.position.z);
        }
    }
}
