using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visualization{

public class Link : MonoBehaviour {

    public string id;
    public Node source;
    public Node target;
    public string sourceId;
    public string targetId;
    public bool loaded = false;
    public LineRenderer lineRenderer;
    
	void Start () {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        
        //draw line
        lineRenderer.material = new Material(Shader.Find("Self-Illumin/Diffuse"));
        lineRenderer.material.color = new Color32(193, 180, 185, 50);  
        lineRenderer.SetWidth(0.01f, 0.01f);
		
	}
	
	// Update is called once per frame
	void Update () {
        if(source && target && !loaded)
        {
            lineRenderer.SetPosition(0, source.transform.position);

            lineRenderer.SetPosition(1, target.transform.position);
            loaded = true; 
        }
	}
    
}
}