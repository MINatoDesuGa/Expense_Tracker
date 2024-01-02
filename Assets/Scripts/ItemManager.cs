using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Button EditButton, DeductButton, AddButton;
    [SerializeField] private TextMeshProUGUI _itemName, _itemValue;

    public int id;

    [SerializeField] private GameObject EditPanel, AddDeductPanel;

    private void OnEnable()
    {
        EditButton.onClick.AddListener(OnEditButtonPressed);
        DeductButton.onClick.AddListener(OnDeductButtonPressed);
        AddButton.onClick.AddListener(OnAddButtonPressed);
    }

    private void OnDisable()
    {
        EditButton.onClick.RemoveListener(OnEditButtonPressed);
        DeductButton.onClick.RemoveListener(OnDeductButtonPressed);
        AddButton.onClick.RemoveListener(OnAddButtonPressed);
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
        GlobalVariables.isAddAction = false;
        OnAddDeductPress();
    }

    public void OnAddButtonPressed()
    {
        GlobalVariables.isAddAction = true;
        OnAddDeductPress();
    }

    private void OnAddDeductPress()
    {
        AddDeductPanel.SetActive(true);

        GlobalVariables.currentItemValue = _itemValue;

        GlobalVariables.currentID = id;
    }
}
