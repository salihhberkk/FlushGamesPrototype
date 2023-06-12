using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GemInfoImage : MonoBehaviour
{
    [SerializeField] private Image gemIconImage;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI gemTypeText;

    public void SetValues(Sprite newGemIconImage , string newGemTypeString)
    {
        gemIconImage.sprite = newGemIconImage;
        gemTypeText.text = newGemTypeString;

        SetCountText();
    }
    public void SetCountText()
    {
        countText.text = PlayerPrefs.GetInt(gemTypeText.text, 0).ToString();
    }
}
