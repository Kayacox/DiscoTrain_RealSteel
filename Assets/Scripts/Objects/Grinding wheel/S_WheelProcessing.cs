using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_WheelProcessing : MonoBehaviour
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
        if (other.gameObject.name.ToLower().Contains("sword"))
        {
            Debug.Log("grinding");
        }
    }
}
