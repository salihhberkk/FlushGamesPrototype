using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackManager : MonoBehaviour
{
    [SerializeField] private Transform stackTransform;
    [SerializeField] private List<StandartGem> gems = new();
    public void AddGem(StandartGem newGem)
    {
        gems.Add(newGem);
        newGem.transform.SetParent(stackTransform.transform);
        newGem.transform.DOLocalJump(Helper.Help(0, gems.Count, 0), 0.1f, 1, 1f).SetEase(Ease.OutBounce);
        //newGem.transform.position = stackTransform.position + Helper.Help(0, gems.Count, 0);
    }
    public void RemoveGem(Transform removePoint)
    {
        StartCoroutine(StartRemoveGem(removePoint));
    }
    IEnumerator StartRemoveGem(Transform removePoint)
    {
        while (true)
        {
            gems[gems.Count - 1].transform.DOMove(removePoint.position, 1f).OnComplete(() =>
           {

           });
            gems.RemoveAt(gems.Count - 1);
        }
    }
}
