using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // internal vars
    DeckMovement myMovementDeck;

    // editor vars
    [SerializeField] GameObject HandContainer;

    // cached refs
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        myMovementDeck = gameController.GetMovementDeck();
        Debug.Log("My Movement Deck " + myMovementDeck.GetType());

        List<CardMovement> myHand = myMovementDeck.Draw(8);
        renderHand(myHand, HandContainer, gameController);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // my methods
    void renderHand(List<CardMovement> hand, GameObject renderParent, GameController _gameController){
        // sort the hand
        if (hand.Count > 0) {
            hand.Sort(delegate(CardMovement a, CardMovement b) {
                return (a.ToString()).CompareTo(b.ToString());
            });
        }
    
        // loop vars
        GameObject prefab;
        GameObject newCard;
        foreach(CardMovement thisCard in hand){
            Debug.Log("card " + thisCard.getType() + " of size " + thisCard.getValue());
            prefab = _gameController.GetCardPrefab(thisCard.getType(), thisCard.getValue());
            newCard = Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity, renderParent.transform);
            // newCard.transform.localPosition = cardPos;
        }
    }
}
