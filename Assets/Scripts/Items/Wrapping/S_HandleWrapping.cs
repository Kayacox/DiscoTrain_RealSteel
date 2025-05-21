using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_HandleWrapping : MonoBehaviour
{
    private int hitCount = 0;
    public GameObject Node1;
    public GameObject Node2;
    public GameObject Node3;
    public GameObject Node4;
    public GameObject wrappingStation;
    public GameObject handleWrap;
    private GameObject wrapInstance;
    private bool onStation = false;
    private bool nodeStarted = false;
    private GameObject activeNode;
    private GameObject previousNode;
    public S_GetSwordNodeHit nodescript1;
    public S_GetSwordNodeHit nodescript2;
    public S_GetSwordNodeHit nodescript3;
    public S_GetSwordNodeHit nodescript4;
    private S_GetSwordNodeHit activeNodescript;
    S_GetSwordNodeHit[] scripts;
    GameObject[] nodes;
    MeshRenderer nodeRenderer;
    // Start is called before the first frame update
    void Start()
    {
        nodes = new GameObject[] { Node1, Node2, Node3, Node4 };
        scripts = new S_GetSwordNodeHit[] { nodescript1, nodescript2, nodescript3, nodescript4 };
    }

    // Update is called once per frame
    void Update()
    {
        if (!nodeStarted && onStation)
        {
            newNode();
        }
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
    private void OnTriggerStay(Collider other) 
    {
        GameObject target = GameObject.Find("Player");    
        if (other.transform.IsChildOf(target.transform) && onStation)
        {
            foreach (S_GetSwordNodeHit node in scripts)
            {
                if (node.hit)
                {
                    if (node == activeNodescript)
                    {
                        Debug.Log("Correct Node");
                    }
                }
            }
            hitCount++;
            if (hitCount < 4)
            {
                newNode();
            }
            if (hitCount == 4)
            {
                wrapInstance = Instantiate(handleWrap, transform);
                Vector3 currentPos = wrapInstance.transform.localPosition;

                wrapInstance.transform.localPosition = new Vector3(currentPos.x, currentPos.y, 0.05f);
                wrapInstance.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
                wrapInstance.transform.localScale = new Vector3(60f, 90f, 120f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == wrappingStation)
        {
            onStation = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WrappingCounter")
        {
            onStation = true;
        }
    }
}
