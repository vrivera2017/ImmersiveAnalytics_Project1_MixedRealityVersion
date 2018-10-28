using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml; 
using System.IO; 

public class frequencyCount : MonoBehaviour {

	public Point DataPoint; //DataPoint: prefab to be used when creating nodes
	public float x; //x position of node
	public float y; //y position of node
	public float z; //z position of node
	public float s; //frequency value of node  
	public Vector3 pos; //position of node


	// Use this for initialization
	void Start () {
		StartCoroutine(Frequency()); 
	}

	// function to get the random position of a node 
	public void getPos(){
		x = UnityEngine.Random.Range(-3f, 3f);
		y = UnityEngine.Random.Range(-3f, 3f);
		z = UnityEngine.Random.Range(-3f, 3f);
		pos = new Vector3(x, y, z); 
	}
	
	// Handles reading of data from xml file and instantiating nodes 
	public IEnumerator Frequency() {
		string sourceFile = Application.dataPath + "/Data/bakingdata.xml";
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load(sourceFile);
		XmlElement root = xmlDoc.DocumentElement;

		for(int i = 0; i<root.ChildNodes.Count; i++)
		{
			XmlNode xmlGraph = root.ChildNodes[i];
			for(int j = 0; j < xmlGraph.ChildNodes.Count; j++)
			{
				XmlNode xmlNode = xmlGraph.ChildNodes[j];

				if(xmlNode.Name == "node")
				{

					if(xmlNode.Attributes["category"].Value == "ingredient")
					{
					getPos(); 
                    float s = float.Parse(xmlNode.Attributes["frequency"].Value); 
                    float scale = (float)(s*0.15); //scale of node 
                    if (!(Physics.CheckSphere(pos, scale))){ //check for collisions between node positions before instantiating 
                    	Point nodeObject = Instantiate(DataPoint, pos, Quaternion.identity) as Point;
                    	nodeObject.GetComponent<Transform>().localScale = new Vector3(scale,scale,scale); 
						if(xmlNode.Attributes["name"].Value == "flour"){
                        	nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 131, 66, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "eggs"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 65, 241, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "coconut sugar"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(65, 100, 244, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "brown sugar"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(65, 100, 244, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "white sugar"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(65, 100, 244, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "vanilla extract"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 65, 241, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "baking soda"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 131, 66, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "baking powder"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 131, 66, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "chocolate chips"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(65, 244, 199, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "canned pumpkin"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 65, 241, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "bananas"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 205, 65, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "walnuts"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(65, 244, 199, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "cinnamon"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 131, 66, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "ground cloves"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 131, 66, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "ground ginger"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 131, 66, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "nutmeg"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 131, 66, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "cocoa powder"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 131, 66, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "butter"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 65, 241, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "coconut oil"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 65, 241, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "salt"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 131, 66, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "molasses"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 65, 241, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "apples"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 205, 65, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "pecans"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(65, 244, 199, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "lemons"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 205, 65, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "cranberries"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(65, 244, 199, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "oatmeal"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 131, 66, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "peanut butter"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 65, 241, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "blueberries"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 205, 65, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "peaches"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 205, 65, 255);
                    	}
                    	else if(xmlNode.Attributes["name"].Value == "zucchini"){
                    		nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(244, 205, 65, 255);
                    	}
					
						nodeObject.id = xmlNode.Attributes["id"].Value;
						nodeObject.name = xmlNode.Attributes["id"].Value;
                    }
                    else{ 
                    	Frequency(); 
                    }
				}

				}
			}
		}
		yield return null; 
	}
}