using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obstacle;
    //TO DO Faire un object pooling pour les obstacles
    public void ObstacleCreation(GameObject node,float duree)
    {
        node.SetActive(false);
        GameObject Obstacle = Instantiate(obstacle, node.transform);

        StartCoroutine(ObstacleLifetime(duree,Obstacle,node));
    }
    private IEnumerator ObstacleLifetime(float duree, GameObject Obstacle, GameObject node)
    {
        yield return new WaitForSeconds(duree);
        Destroy(Obstacle);
        node.SetActive(true);
        
    }
}
