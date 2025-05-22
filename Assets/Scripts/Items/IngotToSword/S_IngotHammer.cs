using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class S_IngotHammer : MonoBehaviour
{
    public GameObject Node1;
    public GameObject Node2;
    public GameObject Node3;
    public GameObject Node4;
    public GameObject Anvil;
    public GameObject ironSword;
    public GameObject tinSword;
    public GameObject copperSword;
    public GameObject swordSelection;
    private S_BladeSelection selectionScript;
    private int hitCount = 0;
    private bool hammerOn = false;
    private bool onAnvil = false;
    private bool nodeStarted = false;
    private GameObject activeNode;
    private GameObject previousNode;
    public S_GetAnvilNodeHit nodescript1;
    public S_GetAnvilNodeHit nodescript2;
    public S_GetAnvilNodeHit nodescript3;
    public S_GetAnvilNodeHit nodescript4;
    private S_GetAnvilNodeHit activeNodescript;
    S_GetAnvilNodeHit[] scripts;
    GameObject[] nodes;
    MeshRenderer nodeRenderer;

    public string material;

    // Start is called before the first frame update
    void Start()
    {
        nodes = new GameObject[] { Node1, Node2, Node3, Node4 };
        scripts = new S_GetAnvilNodeHit[] { nodescript1, nodescript2, nodescript3, nodescript4 };

        for (int i = 0; i < nodes.Length; i++)
        {
            scripts[i] = nodes[i].GetComponent<S_GetAnvilNodeHit>();
        }
        selectionScript = swordSelection.GetComponent<S_BladeSelection>();
        
    }

    private void newNode()
    {
        if (nodeStarted) 
        {
            previousNode = activeNode;
            activeNode.GetComponent<MeshRenderer>().enabled = false;
        }
        nodeStarted = true;
        while (previousNode == activeNode || !nodeStarted)
        {
            int randomIndex = Random.Range(0, nodes.Length);
            activeNode = nodes[randomIndex];
            activeNodescript = scripts[randomIndex];
        }

        nodeRenderer = activeNode.GetComponent<MeshRenderer>();
        activeNode.GetComponent<MeshRenderer>().enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onAnvil && !nodeStarted)
        {
            newNode();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Anvil")) 
        {
            onAnvil = true;
        }
        if (other.gameObject.name.Contains("Hammer") && !hammerOn && onAnvil || onAnvil && !nodeStarted)
        {
            hammerOn = true;
            foreach (S_GetAnvilNodeHit node in scripts)
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
            hitCount++;
            newNode();
            if (hitCount == 4)
            {
                changeToSword();
  
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Anvil)
        {
            onAnvil = false;
        }
        if (other.gameObject.name.Contains("Hammer")) 
        {
            hammerOn = false;
        }
    }
    private void changeToSword()
    {
        if (gameObject.name.ToLower().Contains("iron"))
        {
            Instantiate(ironSword, transform.position, transform.rotation);
            Debug.Log("iron");
        }
        if (gameObject.name.ToLower().Contains("tin"))
        {
            Instantiate(tinSword, transform.position, transform.rotation);
            Debug.Log("tin");
        }
        if (gameObject.name.ToLower().Contains("copper"))
        {
            Instantiate(copperSword, transform.position, transform.rotation);
            Debug.Log("copper");
        }
        Destroy(gameObject);
    }
}
