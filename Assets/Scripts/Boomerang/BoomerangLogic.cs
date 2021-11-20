using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomerangLogic : MonoBehaviour
{
    public Vector3 Direction;
    public float BoomerangSpeed = 25f;
    public float BoomerangTimer = 1.25f;
    public bool HitAWall = false;
    public bool returning = false;
    public bool HasLoot = false;
    public bool HitABoomerang = false;
    public List<Sprite> LootList;
    // Start is called before the first frame update
    void Start()
    {
        returning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (HitABoomerang)
        {
            this.transform.position -= (Vector3.up) * BoomerangSpeed;
            return;
        }


        Debug.Log(returning && !HitAWall && !HasLoot);
        if (returning && !HitAWall && !HasLoot)
        {
            SelectLoot();
        }

        if (BoomerangTimer >= 0)
        {
            this.transform.position += Direction * BoomerangSpeed;
            BoomerangTimer -= Time.deltaTime;
        }
        else
        {
            if (!returning) returning = true;
            this.transform.position -= Direction * BoomerangSpeed;
        }


        //this.transform.GetChild(0).rotation
    }

    void SelectLoot()
    {
        GameObject go = Instantiate(new GameObject(),transform);
        Image x = go.AddComponent<Image>();
        x.sprite = LootList[Random.Range(0,LootList.Count)];
        x.SetNativeSize();
        HasLoot = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Boom-Seagull"))
        {
            Debug.Log("Seagull");
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Boomerang"))
            HitABoomerang = true;
    }
}
