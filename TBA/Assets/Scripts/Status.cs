using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Status : MonoBehaviour
{
    public StatusData statusData;
    public string statusName;
    public Sprite statusSprite;

    [TextArea(5, 10)]
    public string statusDesc;
    public float statusStrength;
    public StatusType statusType;

    public int turnsLeft;

    public TextMeshProUGUI statusText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;

    private void Start()
    {
        
    }

    private void LoadEnchantmentData()
    {
        statusName = statusData.statusName;
        statusSprite = statusData.statusSprite;
        statusDesc = statusData.statusDesc;
        statusType = statusData.statusType;
        statusStrength = statusData.statusStrength;

        GetComponent<Image>().sprite = statusSprite;

        statusText.text = statusName;
        titleText.text = statusType.ToString();
        descText.text = statusDesc;
        
    }

}
