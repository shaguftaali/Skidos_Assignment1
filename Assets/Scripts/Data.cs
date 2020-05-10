using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum OperationType:int
{
    Addition=0,
    Geometry=1,
    MixedOperations=2,
    NumberSnese=3,
    Subtraction=4


}



[Serializable]
public class JsonData
{
    public Operation addtion;
    public Operation geometry;
    public Operation mix;
    public Operation numberSense;
    public Operation subtraction;

}




[Serializable]
public class Operation
{
    public string name;
    public OperationType operationType;
    public Level[] level;
    

}

[Serializable]
public class Level
{
    public SubTopics[] subTopics;
}

[Serializable]
public class SubTopics
{
    public string id;
    public string name;
}

