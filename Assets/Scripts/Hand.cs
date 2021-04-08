using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // internal vars
    DeckMovement myMovementDeck;

    // cached refs
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        myMovementDeck = gameController.GetMovementDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
