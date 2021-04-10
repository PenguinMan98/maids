using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckMenu : MonoBehaviour
{
    [SerializeField] GameObject deckMenuParent;
    [SerializeField] CardMovement[] myMovementDraw;
    [SerializeField] CardMovement[] myMovementHand;
    [SerializeField] CardMovement[] myMovementDiscard;

    // Private vars
    int currentSceneIndex;
    DeckMovement myMovementDeck;

    // Cached refs
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();

        myMovementDeck = new DeckMovement();

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 1){
            renderDeck(deckMenuParent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        myMovementDraw = myMovementDeck.GetDraw().ToArray();
        myMovementHand = myMovementDeck.GetHand().ToArray();
        myMovementDiscard = myMovementDeck.GetDiscard().ToArray();
    }

    // my methods
    private Vector3 getParentTopLeft(){
        RectTransform rt = (RectTransform)deckMenuParent.transform;
        float height = rt.rect.height;
        float width = rt.rect.width;
        return new Vector3(-(width/2), (height/2), 0);
    }

    void renderDeck(GameObject renderParent){
        Vector3 parentTopLeft = getParentTopLeft();
        Vector3 cardDefaultPos = parentTopLeft + new Vector3(Card.cardWidth/2, Card.cardHeight/-2,0);

        // loop vars
        int rowPos = 0;
        int colPos = 0;
        int colMax = 6;
        GameObject prefab;
        GameObject newCard;
        foreach(CardMovement thisCard in myMovementDeck.GetMovementDeck()){
            Debug.Log("card " + thisCard.getType() + " of size " + thisCard.getValue());
            prefab = gameController.GetCardPrefab(thisCard.getType(), thisCard.getValue());
            newCard = Instantiate(prefab, cardDefaultPos, Quaternion.identity, deckMenuParent.transform);
            Vector3 cardPos = new Vector3(colPos * (Card.cardWidth + Card.cardGap), rowPos * (-Card.cardHeight - Card.cardGap) ,0) + cardDefaultPos;
            if(colPos == colMax -1){
                rowPos += 1;
                colPos = 0;
            } else {
                colPos += 1;
            }
            newCard.transform.localPosition = cardPos;
        }
    }
}
