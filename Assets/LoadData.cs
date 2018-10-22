/* This file handles loading the data from bakingdata.xml, creating nodes and edges, and other UI components
 * From Jason Graves: http://collaboradev.com/2014/03/12/visualizing-3d-network-topologies-using-unity/
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

    //public GameObject DataPoint; 
    //public GameObject linkPrefab; 

    private Hashtable nodetable; //holds live instances of the prefab for nodes
    private Hashtable linktable; //hold live instance of the prefab for links
    //private GUIText statusText;
    private int nodeCount = 0; //holds the numeric value for the count of nodes
    private int linkCount = 0; //holds the numeric value for the count of links
    //private GUIText nodeCountText;
    //private GUIText linkCountText;
    //public LineRenderer lineRenderer; 


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


    //method for loading the GraphML Layout file


    void Start()
    {

          nodetable = new Hashtable();
          linktable = new Hashtable(); 
          StartCoroutine(LoadLayout()); 

    }
    
    public IEnumerator LoadLayout() 
    {
        string sourceFile = Application.dataPath + "/Data/bakingdata.xml";
        //statusText.text = "Loading file: " + sourceFile;

        // determine which platform to Load for
        //string xml = null;
        //StreamReader reader = new StreamReader(sourceFile);
        //Debug.Log("reader: " + reader); 
        //xml = reader.ReadToEnd();
        //Debug.Log("xml: " + xml); 
        //reader.Close();

        XmlDocument xmlDoc = new XmlDocument();
        //xmlDoc.LoadXml(xml);
        xmlDoc.Load(sourceFile);
        Debug.Log("xmlDoc: " + xmlDoc); 

        //statusText.text = "Loading...";
        
        //int scale = 2;
        //XmlElement root = xmlDoc.FirstChild as XmlElement;
        XmlElement root = xmlDoc.DocumentElement;
        Debug.Log("root: " + root); 
        Debug.Log("Got here");
        for(int i = 0; i<root.ChildNodes.Count; i++)
        {
            Debug.Log(root.ChildNodes[i]);
            XmlNode xmlGraph = root.ChildNodes[i];
            for(int j = 0; j < xmlGraph.ChildNodes.Count; j++)
            {
                XmlNode xmlNode = xmlGraph.ChildNodes[j];
                
                // Create nodes
                if(xmlNode.Name == "node")
                {
                    Debug.Log("found a node"); 
                    float x = float.Parse(xmlNode.Attributes["x"].Value);
                    Debug.Log("x: " + x);
                    float y = float.Parse(xmlNode.Attributes["y"].Value);
                    Debug.Log("y: " + y);
                    float z = float.Parse(xmlNode.Attributes["z"].Value);
                    Debug.Log("z: " + z); 
                    Node nodeObject = Instantiate(DataPoint, new Vector3(x, y, z), Quaternion.identity) as Node;
                    //GameObject nodeObject = Instantiate(DataPoint, new Vector3(x, y, z), Quaternion.identity); 
                    //nodeObject.nodeText.text
                    //nodeObject.id = xmlNode.Attributes[0].Value;
                    nodeObject.id = xmlNode.Attributes["id"].Value; 
                    nodeObject.name = xmlNode.Attributes["id"].Value; 
                    //nodetable.Add(nodeObject.id, nodeObject);
                    nodetable.Add(nodeObject.id, nodeObject); 
                    //statusText.text = "Loading Node" + nodeObject.id;
                    nodeCount++;
                    //nodeCountText.text = "Nodes: " + nodeCount; 
                }
                // Create edges
                /*
                if(xmlNode.Name == "edge")
                {
                    Debug.Log("found an edge");
                    GameObject linkObject = Instantiate(linkPrefab, new Vector3(0,0,0), Quaternion.identity); 
                    linkObject.name = xmlNode.Attributes[0].Value; 
                    linkObject.sourceId = xmlNode.Attributes[1].Value;
                    linkObject.targetId = xmlNode.Attributes[2].Value; 
                    linktable.Add(linkObject.name, linkObject); 
                    linkCount++; 
                }
                */

                
                if(xmlNode.Name == "edge")
                {
                    Debug.Log("found an edge"); 
                    Link linkObject = Instantiate(linkPrefab, new Vector3(0, 0, 0), Quaternion.identity) as Link;
                    Debug.Log("linkObject: " + linkObject); 
                    linkObject.id = xmlNode.Attributes["id"].Value;
                    linkObject.name = xmlNode.Attributes["id"].Value; 
                    Debug.Log("linkObject id: " + linkObject.id); 
                    //linkObject.id = xmlNode.Attributes[0].Value; 
                    Debug.Log("id: " + linkObject.id); 
                    linkObject.sourceId = xmlNode.Attributes["source"].Value;
                    linkObject.targetId = xmlNode.Attributes["target"].Value;
                    //linkObject.status = xmlNode.Attributes["status"].Value;

                    //linkObject.sourceId = xmlNode.Attributes[1].Value;
                    //linkObject.targetId = xmlNode.Attributes[2].Value;
                    linktable.Add(linkObject.id, linkObject);
                    //statusText.text = "Loading edge: " + linkObject.id;
                    linkCount++;
                    //linkCountText.text = "Edges: " + linkCount; 
                }
                

                

                //map node edges
                MapLinkNodes();
                

                //statusText.text = "";
                
            }  
             

            //every 100 cycles return control to unity
                    //if(j % 100 == 0)
                        //yield return true;    
           
        }
        //yield return StartCoroutine(LoadLayout());
        yield return null; 
    }

 

    





        
        //linktable = new Hashtable();

        //initial stats
        //nodeCountText = GameObject.Find("NodeCount").guiText;

    }
}




