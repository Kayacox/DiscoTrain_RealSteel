using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class S_BladeSelection : MonoBehaviour
{
    public GameObject Node1;
    public GameObject Node2;
    public GameObject Node3;
    public GameObject hand;
    public GameObject otherHand;
    public char type = 'l';
    public S_AnvilTypeNode nodescript1;
    public S_AnvilTypeNode nodescript2;
    public S_AnvilTypeNode nodescript3;
    S_AnvilTypeNode[] scripts;
    GameObject[] nodes;
    MeshRenderer nodeRenderer;

    // Start is called before the first frame update
    void Start()
    {
        nodes = new GameObject[] { Node1, Node2, Node3 };
        scripts = new S_AnvilTypeNode[] { nodescript1, nodescript2, nodescript3 };
        for (int i = 0; i < nodes.Length; i++)
        {
            scripts[i] = nodes[i].GetComponent<S_AnvilTypeNode>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject target = GameObject.Find("Player");
        if (other.transform.IsChildOf(target.transform))
        {
            int i = 0;
            foreach (S_AnvilTypeNode node in scripts)
            {
                if (node.hit)
                {
                    if (node == Node1) 
                    {
                        type = 's';
                        Debug.Log("s");
                    }
                    if (node == Node2) 
                    {
                        type = 'm';
                        Debug.Log("m");
                    }
                    if (node == Node3) 
                    {
                        type = 'l';
                        Debug.Log("l");
                    }
                    GameObject[] ingots = GameObject.FindGameObjectsWithTag("ProcessedOre");
                    if (ingots.Length > 0)
                    {
                        foreach (GameObject ingot in ingots)
                        {
                            S_IngotHammer scrip = ingot.GetComponent<S_IngotHammer>();
                            scrip.bladeLength = type;
                        }
                    }
                }
                i++;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
