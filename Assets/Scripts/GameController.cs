using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // internal vars
    DeckMovement myMovementDeck;

    // editor vars
    public GameObject cardPrefabM1;
    public GameObject cardPrefabM2;
    public GameObject cardPrefabM3;
    public GameObject cardPrefabMR;
    public GameObject cardPrefabML;
    public GameObject cardPrefabMB;
    public GameObject cardPrefabMU;


    private void Awake()
    {
        int gameControllerCount = FindObjectsOfType<GameController>().Length;
        if (gameControllerCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        myMovementDeck = new DeckMovement();
    }

    void Update()
    {
        
    }

    // methods
    public DeckMovement GetMovementDeck(){
        return myMovementDeck;
    }

    public GameObject GetCardPrefab(CardMovementType myMovementType, int value){
        if(myMovementType == CardMovementType.Forward && value == 1){
            return cardPrefabM1;
        }else if(myMovementType == CardMovementType.Forward && value == 2){
            return cardPrefabM2;
        }else if(myMovementType == CardMovementType.Forward && value == 3){
            return cardPrefabM3;
        }else if(myMovementType == CardMovementType.Reverse){
            return cardPrefabMB;
        }else if(myMovementType == CardMovementType.Left){
            return cardPrefabML;
        }else if(myMovementType == CardMovementType.Right){
            return cardPrefabMR;
        }else if(myMovementType == CardMovementType.UTurn){
            return cardPrefabMU;
        }
        return cardPrefabM1;
    }
}
