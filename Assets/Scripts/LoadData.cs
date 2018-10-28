/* This file handles loading the data from bakingdata.xml, creating nodes and edges, and other UI components
 * Adapted from Jason Graves: http://collaboradev.com/2014/03/12/visualizing-3d-network-topologies-using-unity/
 */
using UnityEngine;
using System; 
using System.Collections;
using System.Xml;
using System.IO;

namespace Visualization{
public class LoadData : MonoBehaviour
{
    
    public Node DataPoint; //DataPoint: prefab to be used when creating nodes
    public Link linkPrefab; //linkPrefab: prefab to be used when creating links

    private Hashtable nodetable; //holds live instances of the prefab for nodes
    private Hashtable linktable; //hold live instance of the prefab for links
   
    public float x;
    public float y;
    public float z;
    public Vector3 pos; 


    // Method for mapping links to nodes
    public void MapLinkNodes()
    {
        foreach(string key in linktable.Keys)
        {
            Link link = linktable[key] as Link;
            link.source = nodetable[link.sourceId] as Node;
            link.target = nodetable[link.targetId] as Node;
        }
    }

    void Start()
    {
          nodetable = new Hashtable();
          linktable = new Hashtable();
          StartCoroutine(LoadLayout()); 
    }

    public void getPos(){
        x = UnityEngine.Random.Range(-5f, 5f);
        y = UnityEngine.Random.Range(-5f, 5f);
        z = UnityEngine.Random.Range(-5f, 5f);
        pos = new Vector3(x, y, z); 
    }
    
    public IEnumerator LoadLayout() 
    {
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
                
                // Create nodes
                if(xmlNode.Name == "node")
                {
                    getPos();
                    float scale = (float)(0.25);
                    if (!(Physics.CheckSphere(pos, scale))){
                        Node nodeObject = Instantiate(DataPoint, pos, Quaternion.identity) as Node;
                        nodeObject.nodeText.text = xmlNode.Attributes["name"].Value;

                        if(xmlNode.Attributes["category"].Value == "ingredient"){
                        nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(66, 232, 244, 255);
                        }
                        else if(xmlNode.Attributes["category"].Value == "recipe"){
                        nodeObject.GetComponent<MeshRenderer>().materials[0].color = new Color32(174, 110, 239, 255); 
                        }

                        nodeObject.id = xmlNode.Attributes["id"].Value; 
                        nodeObject.name = xmlNode.Attributes["id"].Value; 
                        nodetable.Add(nodeObject.id, nodeObject); 

                    }
                    else{
                        LoadLayout(); 
                    }
                }
                
                if(xmlNode.Name == "edge")
                {
                    Link linkObject = Instantiate(linkPrefab, new Vector3(0, 0, 0), Quaternion.identity) as Link;
                    linkObject.id = xmlNode.Attributes["id"].Value;
                    linkObject.name = xmlNode.Attributes["id"].Value; 
                    linkObject.sourceId = xmlNode.Attributes["source"].Value;
                    linkObject.targetId = xmlNode.Attributes["target"].Value;
                    linktable.Add(linkObject.id, linkObject);
                }
                

                //map node edges
                MapLinkNodes();
                
            }  
           
        }
        yield return null; 
    }

    }
}




