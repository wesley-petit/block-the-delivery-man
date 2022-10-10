using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private PathController pathController;
    
    [Header ("Prefabs")]
    [SerializeField] private GameObject node;
    [SerializeField] private GameObject nodeStart;
    [SerializeField] private GameObject nodeEnd;
    [SerializeField] private GameObject building;

    [Header("Parents")]
    [SerializeField] private GameObject Parent_NodeStart;
    [SerializeField] private GameObject Parent_NodeEnd;
    [SerializeField] private GameObject Parent_Building;
    [SerializeField] private GameObject Parent_Node;

    [Header("Config")]
    [SerializeField] private float nodeSpacing = 4;
    [SerializeField] private string name_DataFileMap;

    private Vector3 pos;
    private Quaternion rot = Quaternion.identity;


    [HideInInspector]
    public GameObject Start;
    [HideInInspector]
    public GameObject End;

    


    private void Awake()
    {
        Graph.GAP_BETWEEN_EDGE = nodeSpacing;
        Start = null;
        End = null;
        pos = new Vector3(-nodeSpacing, 0, 0);

        RuntimeText.ReadString(name_DataFileMap);
        for (int i =0; i < RuntimeText.textFromData.Length; i++)
        {
            
            switch (RuntimeText.textFromData[i])
            {
                case 'S': // Start
                    Instantiate(nodeStart, new Vector3(pos.x + nodeSpacing, pos.y, pos.z), rot, Parent_NodeStart.transform);
                    Start=Instantiate(node, pos = new Vector3(pos.x + nodeSpacing, pos.y, pos.z), rot, Parent_Node.transform);
                    break;
                case 'E': // End
                    Instantiate(nodeEnd, new Vector3(pos.x + nodeSpacing, pos.y, pos.z), rot, Parent_NodeEnd.transform);
                    End=Instantiate(node, pos = new Vector3(pos.x + nodeSpacing, pos.y, pos.z), rot, Parent_Node.transform);
                    break;
                case '.': // Node
                    CreateNode(node, Parent_Node);
                    break;
                case '/': // Retour à la ligne
                    pos = new Vector3(-nodeSpacing, pos.y, pos.z - nodeSpacing);
                    break;
                case 'X': // Obstacle 
                    CreateNode(building, Parent_Building);
                    break;

            }
        }
        CreateGraph();


    }
    private void CreateNode(GameObject node, GameObject parent)
    {
        Instantiate(node, pos = new Vector3(pos.x + nodeSpacing, pos.y, pos.z), rot, parent.transform);
    }

    /// <summary>
    /// Store all edges of the scene
    /// </summary>
    private void CreateGraph()
    {
        Dictionary<Vector3, Edge> edges = new();
        if (FindObjectsOfType(typeof(Edge)) is Edge[] temp)
            foreach (var n in temp)
                edges.Add(n.GetPosition, n);
        pathController.Graph = new Graph(edges); 
    }

}
