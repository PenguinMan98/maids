using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMovement
{
    // Editor vars
    // Private vars
    List<CardMovement> movementDeck = new List<CardMovement>();
    List<CardMovement> defaultMovementDeck = new List<CardMovement>();
    List<CardMovement> hand = new List<CardMovement>(); // Cards available to play
    List<CardMovement> discard = new List<CardMovement>(); // Cards I've used
    List<CardMovement> draw = new List<CardMovement>(); // Cards available to draw from

    // Getters/Setters
    public DeckMovement(){
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Forward, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Forward, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Forward, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Forward, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Forward, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Forward, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Forward, 2));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Forward, 2));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Forward, 3));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Right, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Right, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Right, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Left, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Left, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Left, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Reverse, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Reverse, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.Reverse, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.UTurn, 1));
        defaultMovementDeck.Add(new CardMovement(CardMovementType.UTurn, 1));

        movementDeck = defaultMovementDeck;
        draw = movementDeck;
    }

    public void SetHand( List<CardMovement> _hand ){
        hand = _hand;
    }

    public List<CardMovement> GetHand(){
        return hand;
    }

    public void SetDiscard( List<CardMovement> _discard ){
        discard = _discard;
    }

    public List<CardMovement> GetDiscard(){
        return discard;
    }

    public void SetDraw( List<CardMovement> _draw ){
        draw = _draw;
    }

    public List<CardMovement> GetDraw(){
        return draw;
    }

    public void SetMovementDeck( List<CardMovement> _movementDeck ){
        movementDeck = _movementDeck;
    }

    public List<CardMovement> GetMovementDeck(){
        return movementDeck;
    }

    // Methods
    public void recycleDiscard() {
        while(discard.Count > 0){
            draw.Add(discard[0]);
            discard.RemoveAt(0);
        }
    }

    public List<CardMovement> Draw(int numToDraw ){
        List<CardMovement> drawnCards = new List<CardMovement>();
        int cardIndex;
        CardMovement drawnCard;
        Debug.Log("Drawing " + numToDraw + " items. Draw has " + draw.Count + ". Discard has " + discard.Count);
        for(int i = 0; i < numToDraw; i++) {
            // if the draw is empty, put the discard back in.
            if(draw.Count == 0 && discard.Count == 0){
                throw new DeckExhaustedException("I ran out of cards to draw!");
            }
            if(draw.Count == 0){
                recycleDiscard();
            }
            // pick a random card from draw
            cardIndex = UnityEngine.Random.Range(0, draw.Count);
            Debug.Log("Card Index: " + cardIndex + ". Draw count: " + draw.Count);
            // remove it from draw
            drawnCard = draw[cardIndex];
            draw.RemoveAt(cardIndex);
            // add it to hand
            hand.Add(drawnCard);
            // add it to drawnCards
            drawnCards.Add(drawnCard);
        }
        Debug.Log("Finished. Draw has " + draw.Count + ". Drawn cards: " + drawnCards.Count);
        foreach(CardMovement m_card in drawnCards){
            Debug.Log(m_card.ToString());
        }
        return drawnCards;
    }

    public void UseCard( CardMovement card ){
        Debug.Log("Use Card " + card.ToString() + ". Draw has " + draw.Count + ". Discard has " + discard.Count + ". Hand has " + hand.Count);
        // hand may have more than one matching card. Find the first.
        bool foundIt = false;
        for(int i = 0; i < hand.Count; i++){
            if(hand[i].ToString() == card.ToString()){
                // found one
                discard.Add(hand[i]); // add it to the discard
                hand.RemoveAt(i); // remove it from hand
                foundIt = true;
                break;
            }
        }
        if( !foundIt ){
            throw new CardNotFoundException("Card " + card.ToString() + " not in hand!");
        }
        Debug.Log("Finished. Draw has " + draw.Count + ". Discard has " + discard.Count + ". Hand has " + hand.Count);
        foreach(CardMovement m_card in hand){
            Debug.Log("hand: " + m_card.ToString());
        }
        foreach(CardMovement m_card in discard){
            Debug.Log("discard: " + m_card.ToString());
        }
    }

    public void ClearHand(){
        while(hand.Count > 0){
            discard.Add(hand[0]);
            hand.RemoveAt(0);
        }
    }
}

[System.Serializable]
public class CardNotFoundException : System.Exception
{
    public CardNotFoundException() { }
    public CardNotFoundException(string message) : base(message) { }
    public CardNotFoundException(string message, System.Exception inner) : base(message, inner) { }
    protected CardNotFoundException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

[System.Serializable]
public class DeckExhaustedException : System.Exception
{
    public DeckExhaustedException() { }
    public DeckExhaustedException(string message) : base(message) { }
    public DeckExhaustedException(string message, System.Exception inner) : base(message, inner) { }
    protected DeckExhaustedException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}