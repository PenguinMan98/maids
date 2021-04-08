using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardMovementType {Forward, Left, Right, Reverse, UTurn};

[Serializable]
public class CardMovement : Card
{
    // Editor vars


    // Private vars
    int value = 1;
    CardMovementType type = CardMovementType.Forward;

    public CardMovement(CardMovementType _type, int _value){
        setValue(_value);
        setType(_type);
    }

    // methods
    override public string ToString() {
        return type + " " + value;
    }

    // Getters/Setters
    public void setValue( int _value ){
        value = _value;
    }

    public int getValue(){
        return value;
    }

    public void setType( CardMovementType _type ){
        type = _type;
    }

    public CardMovementType getType(){
        return type;
    }
}
