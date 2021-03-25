using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardMovementType {Forward, Left, Right, Reverse, UTurn};

[Serializable]
public class CardMovement
{
    // Editor vars
    [SerializeField] int value = 1;
    [SerializeField] CardMovementType type = CardMovementType.Forward;

    // Private vars

    public CardMovement(CardMovementType _type, int _value){
        setValue(_value);
        setType(_type);
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

    override public string ToString() {
        return type + " " + value;
    }
}
