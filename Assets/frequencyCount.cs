using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml; 
using System.IO; 

public class frequencyCount : MonoBehaviour {

	public Point DataPoint; //DataPoint: prefab to be used when creating nodes
	//public Link linkPrefab; //linkPrefab: prefab to be used when creating links. **Don't know if it's necessary yet. 

	private Hashtable nodeTable; //holds live instances of the prefab for nodes
	private Hashtable sourceCountT; //holds sourceId and sourceCnt for each source of an edge
	private int nodeCount = 0; //holds the numeric value for the count of nodes 
	private int sourceCnt = 0; //holds the numeric value for count of sources 

	public float x; 
	public float y; 
	public float z; 
	public float s; 
	public Vector3 pos; 


	// Use this for initialization
	void Start () {
		Debug.Log("Starting..."); 
		nodeTable = new Hashtable();
		sourceCountT = new Hashtable(); 
		StartCoroutine(Frequency()); 
		
	}

	// function to check if a random location is valid
	
	public void getPos(){
		x = UnityEngine.Random.Range(-5f, 5f);
		y = UnityEngine.Random.Range(-5f, 5f);
		z = UnityEngine.Random.Range(-5f, 5f);
		pos = new Vector3(x, y, z); 
	}
	
	
	// Update is called once per frame
	public IEnumerator Frequency() {
		string sourceFile = Application.dataPath + "/Data/bakingdata.xml";
		Debug.Log("sourceFile:" + sourceFile); 
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load(sourceFile);
		XmlElement root = xmlDoc.DocumentElement;

		for(int i = 0; i<root.ChildNodes.Count; i++)
		{
			Debug.Log("inside 1");
			XmlNode xmlGraph = root.ChildNodes[i];
			for(int j = 0; j < xmlGraph.ChildNodes.Count; j++)
			{
				Debug.Log("inside 2"); 
				XmlNode xmlNode = xmlGraph.ChildNodes[j];

				if(xmlNode.Name == "node")
				{

					if(xmlNode.Attributes["category"].Value == "ingredient")
					{
					getPos(); 
					Debug.Log("Position: " + pos); 
					Debug.Log("I found a node!"); 
                    //float x = float.Parse(xmlNode.Attributes["x"].Value);
                    //float y = float.Parse(xmlNode.Attributes["y"].Value);
                    //float z = float.Parse(xmlNode.Attributes["z"].Value);
                    //float x = UnityEngine.Random.Range(-5f, 5f);
                    //float y = UnityEngine.Random.Range(-5f, 5f);
                    //float z = UnityEngine.Random.Range(-5f, 5f); 
                    float s = float.Parse(xmlNode.Attributes["frequency"].Value); 
                    float scale = (float)(s*0.25);
                    Debug.Log("Scale: " + scale); 
                    if (!(Physics.CheckSphere(pos, scale))){
                    	Debug.Log("collision detected"); 
                    	Point nodeObject = Instantiate(DataPoint, pos, Quaternion.identity) as Point;
                    	Debug.Log("the nodeObject is: " + nodeObject); 
                    	nodeObject.GetComponent<Transform>().localScale = new Vector3(scale,scale,scale); 
						//nodeObject.GetComponent<MeshRenderer>().materials[0].color = Color.red; 
						if(xmlNode.Attributes["name"].Value == "flour"){
                        	nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(66, 232, 244, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "eggs"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(174, 110, 239, 255);
                    	}
					
						nodeObject.id = xmlNode.Attributes["id"].Value;
						nodeObject.name = xmlNode.Attributes["id"].Value;
                    }
                    else{
                    	Debug.Log("collision was not detected"); 
                    	Frequency(); 
                    }
                    //Point nodeObject = Instantiate(DataPoint, new Vector3(x, y, z), Quaternion.identity) as Point;
                    /*
                    if (Physics.CheckSphere(nodeObject.GetComponent<Transform>().position, s)){
                    	Debug.Log("collision detected"); 
                    }
                    */
                    //nodeObject.GetComponent<Transform>().localScale += new Vector3(s,s,s); 
					//nodeObject.GetComponent<MeshRenderer>().materials[0].color = Color.red; 
					
					//nodeObject.id = xmlNode.Attributes["id"].Value;
					//nodeObject.name = xmlNode.Attributes["id"].Value;
					//nodeTable.Add(nodeObject.id, nodeObject);
					//nodeCount++; 
				}

				}
			}
		}
		yield return null; 
	}
}
