using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enums
enum tileType{
    Normal,
    PlayerStart,
    Materials,
    Scraps,
    Chasm,
    Recharger,
    Goal
};

public class Tile : MonoBehaviour
{

    // Editor vars
    [SerializeField] int gridX = 0;
    [SerializeField] int gridY = 0;
    [SerializeField] bool wallN = false;
    [SerializeField] bool wallS = false;
    [SerializeField] bool wallE = false;
    [SerializeField] bool wallW = false;
    [SerializeField] tileType myTileType = tileType.Normal;

    // Internal vars
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        int wallDistance = 30;
        Gizmos.color = Color.black;
        if(wallN){
            Gizmos.DrawCube(transform.position + new Vector3(0,wallDistance,0), new Vector3(50,3,1));
        }
        if(wallS){
            Gizmos.DrawCube(transform.position + new Vector3(0,-wallDistance,0), new Vector3(50,3,1));
        }
        if(wallE){
            Gizmos.DrawCube(transform.position + new Vector3(wallDistance,0,0), new Vector3(3,50,1));
        }
        if(wallW){
            Gizmos.DrawCube(transform.position + new Vector3(-wallDistance,0,0), new Vector3(3,50,1));
        }
        if(myTileType == tileType.PlayerStart){
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, 20);
        }
        if(myTileType == tileType.Materials){
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(transform.position, 20);
        }
    }

    // getters/setters
    public int GetGridX(){ return gridX; }
    public int GetGridY(){ return gridY; }
}
