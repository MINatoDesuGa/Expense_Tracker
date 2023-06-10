using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Button EditButton, DeductButton;
    [SerializeField] private TextMeshProUGUI _itemName, _itemValue;

    public int id;

    [SerializeField] private GameObject EditPanel, DeductPanel;

    private void OnEnable()
    {
        EditButton.onClick.AddListener(OnEditButtonPressed);
        DeductButton.onClick.AddListener(OnDeductButtonPressed);
    }

    private void OnDisable()
    {
        EditButton.onClick.RemoveListener(OnEditButtonPressed);
        DeductButton.onClick.RemoveListener(OnDeductButtonPressed);
    }

    public void OnEditButtonPressed()
    {
        EditPanel.SetActive(true);

        GlobalVariables.currentItemName = _itemName;
        GlobalVariables.currentItemValue = _itemValue;

        GlobalVariables.currentID = id;

        EditItem.Instance.newItemName.text = GlobalVariables.currentItemName.text;
        EditItem.Instance.newItemValue.text = GlobalVariables.currentItemValue.text;
    }

    public void OnDeductButtonPressed()
    {
        DeductPanel.SetActive(true);

        GlobalVariables.currentItemValue = _itemValue;

        GlobalVariables.currentID = id;
    }
}
