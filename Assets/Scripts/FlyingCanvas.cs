using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FlyingCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float flyTime = 1f;

    private Color transparanColor;
    private Color normalColor;
    public float heightValue = 0.5f;

    private void Start()
    {
        normalColor = new Color(text.color.r, text.color.g, text.color.b, 1f);
        transparanColor = new Color(text.color.r, text.color.g, text.color.b, 0f);
    }
    public void SetText(float money)
    {
        text.text = money.ToString("0") + "$";
    }
    public void FlyText()
    {
        text.DOColor(transparanColor, flyTime).SetEase(Ease.InExpo);

       // transform.DOPunchScale(Helper.Help(0.01f, 0.01f, 0.01f), flyTime);
        heightValue = 1f;
        transform.DOMoveY(transform.position.y + heightValue, flyTime).OnComplete(() =>
        {
            //gameObject.SetActive(false);
            GetComponent<PoolObject>().Release();
            text.color = normalColor;
        });
    }
}
