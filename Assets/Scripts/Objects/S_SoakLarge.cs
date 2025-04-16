using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SoakLarge : MonoBehaviour
{
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
        S_SwordScript swordScript = other.gameObject.GetComponent<S_SwordScript>();
        Debug.Log(swordScript);
        if (other.gameObject.name.Contains("Sword")) 
        {
            Debug.Log("???????");
            other.gameObject.GetComponent<S_SwordScript>().soaked = true;
            Debug.Log("wet");
        }
    }
}
