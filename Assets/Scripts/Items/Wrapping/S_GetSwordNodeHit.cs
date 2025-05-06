using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class S_GetSwordNodeHit : MonoBehaviour
{
    public bool hit = false;
    GameObject sword;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        sword = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        target = GameObject.Find("Player");
        if (other.transform.IsChildOf(target.transform))
        {
            hit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.IsChildOf(target.transform)) 
        {
            hit = false;
        }
    }
}
