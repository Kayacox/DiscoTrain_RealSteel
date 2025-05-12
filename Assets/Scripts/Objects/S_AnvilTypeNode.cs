using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AnvilTypeNode : MonoBehaviour
{
    public bool hit = false;
    GameObject Blade;
    GameObject Manager;
    // Start is called before the first frame update
    void Start()
    {
        Blade = GameObject.Find("Hammer");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject target = GameObject.Find("Player");
        if (other.transform.IsChildOf(target.transform))
        {
            hitChange();
            hit = true;
        }
    }

    public void hitChange()
    {
        S_AnvilTypeNode[] allSelectors = FindObjectsOfType<S_AnvilTypeNode>();
        foreach (S_AnvilTypeNode selector in allSelectors)
        {
            selector.hit = false;
        }
    }
}
