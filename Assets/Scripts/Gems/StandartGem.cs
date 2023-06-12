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
    public PoolInfoWithPool flyingCanvasPool;
    public PoolInfoWithPool destroyParticlePool;

    private bool isCollect = true;
    private Grid baseGrid;
    private Collider col;
    private GameObject flyingCanvas;
    private GameObject destroyParticle;


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
     }).OnComplete(() =>
     {
         transform.DOPunchScale(Helper.Help(0.35f, 0.35f, 0.35f), 0.35f);
     });
    }

    private float totalMoney = 0f;
    public void RemoveGem(Transform removePoint)
    {
        GemInfoCanvas.Instance.SetCountTexts(gemName);
 
        totalMoney = gemStartSellMoney + transform.localScale.x * 100f;

        transform.SetParent(null);
        transform.DOJump(removePoint.position, 1f, 1, 1f).OnComplete(() =>
        {
            DestroyGem();

            UIManager.Instance.AddMoney(totalMoney);
            SetCollider(false);
        });
    }
    private void DestroyGem()
    {
        flyingCanvas = flyingCanvasPool.Fetch();
        flyingCanvas.transform.position = transform.position + Helper.Help(Random.Range(-1.5f, 1.5f), 0.5f, Random.Range(-1.5f, 1.5f));
        flyingCanvas.SetActive(true);
        flyingCanvas.GetComponent<FlyingCanvas>().SetText(totalMoney);
        flyingCanvas.GetComponent<FlyingCanvas>().FlyText();

        destroyParticle = destroyParticlePool.Fetch();
        destroyParticle.transform.position = transform.position + Helper.Help(0, 0.5f, 0);
        destroyParticle.SetActive(true);
        destroyParticle.GetComponent<ParticleSystemRenderer>().material = GetComponent<Renderer>().material;
        GetComponent<PoolObject>().Release();
    }
    private void SetCollider(bool value)
    {
        col.enabled = value;
    }
}
