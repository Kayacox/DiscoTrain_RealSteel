using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class S_IngotHammer : MonoBehaviour
{
    public GameObject Hammer;
    public GameObject Node1;
    public GameObject Node2;
    public GameObject Node3;
    public GameObject Node4;
    public GameObject Anvil;
    private Hand currentHand;
    private Interactable hammerInteractable;
    private int progress = 0;
    private bool nodeHit = false;
    private bool onAnvil = false;
    private GameObject activeNode;
    public S_GetAnvilNodeHit nodescript1;
    public S_GetAnvilNodeHit nodescript2;
    public S_GetAnvilNodeHit nodescript3;
    public S_GetAnvilNodeHit nodescript4;
    private S_GetAnvilNodeHit activeNodescript;
    S_GetAnvilNodeHit[] scripts;
    GameObject[] nodes;
    MeshRenderer nodeRenderer;

    // Start is called before the first frame update
    void Start()
    {
        nodes = new GameObject[] { Node1, Node2, Node3, Node4 };
        scripts = new S_GetAnvilNodeHit[] { nodescript1, nodescript2, nodescript3, nodescript4 };
        hammerInteractable = GetComponent<Interactable>();
        for (int i = 0; i < nodes.Length; i++)
        {
            scripts[i] = nodes[i].GetComponent<S_GetAnvilNodeHit>();
            Debug.Log(nodes[i].GetComponent<S_GetAnvilNodeHit>());
        }
        newNode();
    }

    private void newNode()
    {
        Debug.Log("Made it in");
        //MeshRenderer previousRenderer = activeNode.GetComponent<MeshRenderer>();
        Debug.Log("Post mesh");
        /*if (previousRenderer != null)
        {
            activeNode.GetComponent<MeshRenderer>().enabled = false;
            Debug.Log("active not null");
        }*/
        Debug.Log("Pre random");
        int randomIndex = Random.Range(0, nodes.Length);
        Debug.Log("Randoms assigned");
        activeNode = nodes[randomIndex];
        Debug.Log(activeNode);
        activeNodescript = scripts[randomIndex];

        nodeRenderer = activeNode.GetComponent<MeshRenderer>();
        activeNode.GetComponent<MeshRenderer>().enabled = true;

        Debug.Log("Visible");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(S_GetAnvilNodeHit node in scripts) 
        {
            if (node.hit)
            {
                if (node == activeNodescript)
                {
                    Debug.Log("Correct Node");
                }
                else { Debug.Log("Wrong Node"); }
            }    
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Anvil) 
        {
            onAnvil = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Anvil)
        {
            onAnvil = false;
        }
    }
}
