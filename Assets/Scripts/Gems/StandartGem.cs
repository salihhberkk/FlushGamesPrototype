using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StandartGem : MonoBehaviour
{
    public string gemName;
    public float gemStartSellMoney;
    public Sprite gemIcon;
    public PoolInfoWithPool gemPool;

    private bool isCollect = true;
    private Grid baseGrid;
    private Collider col;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }
    private void Start()
    {
        col.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isCollect)
            return;
        isCollect = true;

        DOTween.Kill(transform);
        other.GetComponent<StackManager>().AddGem(this);
        baseGrid.RecreateGem(gemPool);
    }
    public void SetCollect()
    {
        isCollect = false;
    }
    public void GrowUp(Grid _baseGrid)
    {
        baseGrid = _baseGrid;
        transform.DOScale(Vector3.one, 5f).SetEase(Ease.Linear).OnUpdate(() =>
     {
         if (transform.localScale.x >= 0.25f)
         {
             isCollect = false;
             col.enabled = true;
         }
     });
    }
}
