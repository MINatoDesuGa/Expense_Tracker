using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditItem : MonoBehaviour
{
    [SerializeField] private TMP_InputField newItemName, newItemValue;
    [SerializeField] private GameObject Overlay, EditPanel;

    public void OnConfirmClicked()
    {
        GlobalVariables.currentItemName.text = newItemName.text;
        GlobalVariables.currentItemValue.text = newItemValue.text;

        GameManager.instance.UpdateBalance();

        string temp = "ItemValue" + GlobalVariables.currentID.ToString();

        PlayerPrefs.SetInt(temp, int.Parse(newItemValue.text));

        temp = "ItemName" + GlobalVariables.currentID.ToString();

        PlayerPrefs.SetString(temp, newItemName.text);

        Overlay.SetActive(false);
        EditPanel.SetActive(false); 
    }
}
