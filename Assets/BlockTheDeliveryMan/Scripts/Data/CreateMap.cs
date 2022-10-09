using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private string name_DataFileMap;
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

    private Vector3 pos;
    private Quaternion rot = Quaternion.identity;


    public GameObject start;
    public GameObject end;


    private void Awake()
    {
        pos = new Vector3(-node.transform.localScale.x, 0, 0);
        for (int i =0; i < RuntimeText.ReadString(name_DataFileMap).Length; i++)
        {
            
            switch (RuntimeText.ReadString(name_DataFileMap)[i])
            {
                case 'S': // Start
                    Instantiate(nodeStart, new Vector3(pos.x + node.transform.localScale.x, pos.y, pos.z), rot, Parent_NodeStart.transform);
                    start=Instantiate(node, pos = new Vector3(pos.x + node.transform.localScale.x, pos.y, pos.z), rot, Parent_NodeStart.transform);
                    break;
                case 'E': // End
                    Instantiate(nodeEnd, new Vector3(pos.x + node.transform.localScale.x, pos.y, pos.z), rot, Parent_NodeEnd.transform);
                    end=Instantiate(node, pos = new Vector3(pos.x + node.transform.localScale.x, pos.y, pos.z), rot, Parent_NodeEnd.transform);
                    break;
                case '.': // Node
                    CreateNode(node, Parent_Node);
                    break;
                case '/': // Retour à la ligne
                    pos = new Vector3(-node.transform.localScale.x, pos.y, pos.z - node.transform.localScale.z);
                    break;
                case 'X': // Obstacle 
                    CreateNode(building, Parent_Building);
                    break;

            }
        }
        
        if (start = null)
        {
            Debug.Log("start = null");
        }
        else
        {
            Debug.Log("start est OK");
        }
    }
    private void CreateNode(GameObject node, GameObject parent)
    {

        Instantiate(node, pos = new Vector3(pos.x + node.transform.localScale.x, pos.y, pos.z), rot, parent.transform);

  
        
    }

}
