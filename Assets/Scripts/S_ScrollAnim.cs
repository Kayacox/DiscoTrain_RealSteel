using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class S_ScrollAnim : MonoBehaviour
{
    private Animator animatorComponent;
    private Renderer rendererComponent;

    public Transform scrollRoot;
    public Transform pullPoint;

    public float maxDistance = 0.5f;



    private const string ROLL = "Roll";
    private const string UNROLL = "Unroll";    
    // Start is called before the first frame update
    void Awake()
    {
        animatorComponent = GetComponent<Animator>();
        rendererComponent = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animatorComponent.enabled = false;
        float distance = Vector3.Distance(scrollRoot.position, pullPoint.position);
        float normalizedTime = Mathf.Clamp01(distance / maxDistance);

        animatorComponent.Play(UNROLL, 0, normalizedTime);
        animatorComponent.speed = 0f;

        transform.localScale = Vector3.one * 2f;
    }
}
