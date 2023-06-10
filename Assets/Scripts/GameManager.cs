using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<TMP_Text> ItemValues, ItemNames;

    public TMP_Text Balance;

    [SerializeField] private Button ResetButton;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;

        Init();
    }

    private void OnEnable()
    {
        ResetButton.onClick.AddListener(OnResetClicked);
    }

    private void OnDisable()
    {
        ResetButton.onClick.RemoveListener(OnResetClicked);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void Init()
    {
        if(!PlayerPrefs.HasKey("Balance"))
        {
            PlayerPrefs.SetInt("Balance", 0);
        } else
        {
            Balance.text = PlayerPrefs.GetInt("Balance").ToString();
        }

        string temp = "";

        for(int i=0; i<ItemNames.Count; i++)
        {
            temp = "ItemName" + i.ToString();

            if (!PlayerPrefs.HasKey(temp))
            {
                PlayerPrefs.SetString(temp, "null");
            }
            else
            {
                ItemNames[i].text = PlayerPrefs.GetString(temp);
            }

            temp = "ItemValue" + i.ToString();

            if (!PlayerPrefs.HasKey(temp))
            {
                PlayerPrefs.SetInt(temp, 0);
            }
            else
            {
                ItemValues[i].text = PlayerPrefs.GetInt(temp).ToString();
            }
        }
    }
    public void UpdateBalance()
    {
        int balance=0;

        for(int i=0; i<ItemValues.Count; i++)
        {
            balance += int.Parse(ItemValues[i].text);
        }

        Balance.text = balance.ToString();
        PlayerPrefs.SetInt("Balance", balance);
    }

    public void OnResetClicked()
    {
        Balance.text = "0";

        for(int i=0; i<ItemValues.Count; i++)
        {
            ItemValues[i].text = "0";
        }

        for (int i = 0; i < ItemNames.Count; i++)
        {
            ItemNames[i].text = "null";
        }

        PlayerPrefs.DeleteAll();
    }
}
