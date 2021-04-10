using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // internal vars
    DeckMovement myMovementDeck = new DeckMovement();

    // editor vars
    [SerializeField] GameObject cardPrefabM1;
    [SerializeField] GameObject cardPrefabM2;
    [SerializeField] GameObject cardPrefabM3;
    [SerializeField] GameObject cardPrefabMR;
    [SerializeField] GameObject cardPrefabML;
    [SerializeField] GameObject cardPrefabMB;
    [SerializeField] GameObject cardPrefabMU;


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

    // methods
    public DeckMovement GetMovementDeck(){
        return myMovementDeck;
    }

    public GameObject GetCardPrefab(CardMovementType myMovementType, int value){
        Debug.Log("GetCardPrefab " + myMovementType + " of size " + value);
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
