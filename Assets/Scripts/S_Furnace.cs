using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Furnace : MonoBehaviour
{

    public GameObject Processed_Ore;

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
        if (other.gameObject.tag == "RawOre")
        {
            Instantiate(Processed_Ore, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            }

    }
}
