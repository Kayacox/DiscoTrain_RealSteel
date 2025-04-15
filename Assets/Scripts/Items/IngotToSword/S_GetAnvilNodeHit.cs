using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GetAnvilNodeHit : MonoBehaviour
{
    public bool hit = false;
    GameObject Hammer;
    // Start is called before the first frame update
    void Start()
    {
        Hammer = GameObject.Find("Hammer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject == Hammer)
        {
            hit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Hammer) 
        {
            hit = false;
        }
    }
}
