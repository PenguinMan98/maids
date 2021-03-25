using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMenu : MonoBehaviour
{
    [SerializeField] CardMovement[] myMovementDraw;
    [SerializeField] CardMovement[] myMovementHand;
    [SerializeField] CardMovement[] myMovementDiscard;

    DeckMovement myMovementDeck;

    // Start is called before the first frame update
    void Start()
    {
        myMovementDeck = new DeckMovement();
        myMovementDeck.Draw(5);
        myMovementDeck.ClearHand();
        myMovementDeck.Draw(17);
    }

    // Update is called once per frame
    void Update()
    {
        myMovementDraw = myMovementDeck.GetDraw().ToArray();
        myMovementHand = myMovementDeck.GetHand().ToArray();
        myMovementDiscard = myMovementDeck.GetDiscard().ToArray();
    }
}
