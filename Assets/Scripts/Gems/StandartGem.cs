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
        SetCollider(false);
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
    public void GrowUp(Grid _baseGrid)
    {
        baseGrid = _baseGrid;
        transform.DOScale(Vector3.one, 5f).SetEase(Ease.Linear).OnUpdate(() =>
     {
         if (transform.localScale.x >= 0.25f)
         {
             isCollect = false;
             SetCollider(true);
         }
     });
    }
    public void RemoveGem(Transform removePoint)
    {
        transform.SetParent(null);
        transform.DOJump(removePoint.position, 1f, 1, 1f).OnComplete(() =>
        {
            UIManager.Instance.AddMoney(gemStartSellMoney + transform.localScale.x * 100f);
            SetCollider(false);

            GetComponent<PoolObject>().Release();

            //gameObject.SetActive(false);
        });
    }
    private void SetCollider(bool value)
    {
        col.enabled = value;
    }
}
