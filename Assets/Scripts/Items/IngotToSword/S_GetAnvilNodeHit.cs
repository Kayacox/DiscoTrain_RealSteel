using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GetAnvilNodeHit : MonoBehaviour
{
    public bool hit = false;
    public GameObject Hammer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Hammer)
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
