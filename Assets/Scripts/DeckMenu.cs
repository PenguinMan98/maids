using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMenu : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject cardPrefabM1;
    public GameObject cardPrefabM2;
    public GameObject cardPrefabM3;
    public GameObject cardPrefabMR;
    public GameObject cardPrefabML;
    public GameObject cardPrefabMB;
    public GameObject cardPrefabMU;
    public GameObject deckMenuParent;
    [SerializeField] CardMovement[] myMovementDraw;
    [SerializeField] CardMovement[] myMovementHand;
    [SerializeField] CardMovement[] myMovementDiscard;

    DeckMovement myMovementDeck;
    // card size vars
    int cardWidth = 150;
    int cardHeight = 210;
    int cardGap = 10;

    // Start is called before the first frame update
    void Start()
    {
        myMovementDeck = new DeckMovement();
        GameObject newCard;

        Vector3 parentTopLeft = getParentTopLeft();
        Debug.Log("parentTopLeft position: " + parentTopLeft);

        Vector3 cardDefaultPos = parentTopLeft + new Vector3(cardWidth/2, cardHeight/-2,0);

        // card ui position vars
        int rowPos = 0;
        int colPos = 0;
        int colMax = 6;
        foreach(CardMovement thisCard in myMovementDeck.GetMovementDeck()){
            switch (thisCard.ToString())
            {
                case "Forward 2":
                    newCard = Instantiate(cardPrefabM2, cardDefaultPos, Quaternion.identity, deckMenuParent.transform);
                    break;
                case "Forward 3":
                    newCard = Instantiate(cardPrefabM3, cardDefaultPos, Quaternion.identity, deckMenuParent.transform);
                    break;
                case "Right 1":
                    newCard = Instantiate(cardPrefabMR, cardDefaultPos, Quaternion.identity, deckMenuParent.transform);
                    break;
                case "Left 1":
                    newCard = Instantiate(cardPrefabML, cardDefaultPos, Quaternion.identity, deckMenuParent.transform);
                    break;
                case "Reverse 1":
                    newCard = Instantiate(cardPrefabMB, cardDefaultPos, Quaternion.identity, deckMenuParent.transform);
                    break;
                case "UTurn 1":
                    newCard = Instantiate(cardPrefabMU, cardDefaultPos, Quaternion.identity, deckMenuParent.transform);
                    break;
                default:
                    newCard = Instantiate(cardPrefabM1, cardDefaultPos, Quaternion.identity, deckMenuParent.transform);
                    break;
            }
            Vector3 cardPos = new Vector3(colPos * (cardWidth + cardGap), rowPos * (-cardHeight - cardGap) ,0) + cardDefaultPos;
            if(colPos == colMax -1){
                rowPos += 1;
                colPos = 0;
            } else {
                colPos += 1;
            }
            newCard.transform.localPosition = cardPos;
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
}
