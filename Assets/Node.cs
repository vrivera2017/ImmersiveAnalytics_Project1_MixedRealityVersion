using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Visualization{
public class Node : MonoBehaviour {

    public string id;
    public TextMesh nodeText;
    public Material colorOfNode; 
	
	// Update is called once per frame
	void Update () {
        //node text always facing camera 
        //nodeText.transform.LookAt(Camera.main.transform); 
		
	}
}
}