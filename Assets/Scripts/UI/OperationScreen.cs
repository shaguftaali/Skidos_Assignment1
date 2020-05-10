using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationScreen : MonoBehaviour
{
    [SerializeField]
    LevelScreen levelScreen;

    JsonData data;

    

    private void Start()
    {
        data = DataManager.Instance.data;
    }

    public void OnOperationBtnClicked(int operationType)
    {
        //Debug.Log("Ope Typ :")
        Operation operation=data.addtion;
        switch (operationType)
        {
            case (int)OperationType.Addition:
                operation = data.addtion;
                break;

            case (int)OperationType.Geometry:
                operation = data.geometry;
                break;

            case (int)OperationType.MixedOperations:
                operation = data.mix;
                break;

            case (int)OperationType.NumberSnese:
                operation = data.numberSense;
                break;

            case (int)OperationType.Subtraction:
                operation = data.subtraction;
                break;
        }
        levelScreen.SetDataOnScreen(operation);
        gameObject.SetActive(false);
       

    }
}
