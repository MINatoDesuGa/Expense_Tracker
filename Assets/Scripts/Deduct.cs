using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Deduct : MonoBehaviour
{
    [SerializeField] private TMP_InputField deductValueInput;
    [SerializeField] private GameObject DeductPanel;

    public void OnConfirmClicked()
    {
        int currentValue = int.Parse( GlobalVariables.currentItemValue.text);

        if (GlobalVariables.isAddAction) {
            currentValue += int.Parse(deductValueInput.text);
        } else
        {
            currentValue -= int.Parse(deductValueInput.text);
        }

        GlobalVariables.currentItemValue.text = currentValue.ToString();

        GameManager.instance.UpdateBalance();

        string temp = "ItemValue" + GlobalVariables.currentID.ToString();

        PlayerPrefs.SetInt(temp, currentValue);

        DeductPanel.SetActive(false); 
    }
}
