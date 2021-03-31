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

    // getters/setters
    public int GetGridX(){ return gridX; }
    public int GetGridY(){ return gridY; }
}
