using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SwordScript : MonoBehaviour
{
    public bool soaked = false;
    private HashSet<Collider> currentTriggers = new HashSet<Collider>();
    public int TriggerCount => currentTriggers.Count;
    public string[] parts;
    // Start is called before the first frame update
    void Start()
    {
        parts = new string[] {"Iron", "Round", "Cross", "Leather"};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            currentTriggers.Add(other);
        }
        if (other.gameObject.name.Contains("Soak"))
        {
            soaked = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        currentTriggers.Remove(other);
    }
}
