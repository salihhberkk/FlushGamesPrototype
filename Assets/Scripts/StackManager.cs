using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackManager : MonoSingleton<StackManager>
{
    [SerializeField] private Transform stackTransform;
    [SerializeField] private List<StandartGem> gems = new();
    private CameraFollower CameraFollower;
    private void Start()
    {
        CameraFollower = CameraFollower.Instance;
    }
    public void AddGem(StandartGem newGem)
    {
        CameraFollower.MoveUp();
        gems.Add(newGem);
        newGem.transform.SetParent(stackTransform.transform);
        newGem.transform.localRotation = Quaternion.Euler(Vector3.zero);
        newGem.transform.DOLocalJump(Helper.Help(0, gems.Count, 0), 0.1f, 1, 1f).SetEase(Ease.OutBounce);
    }
    public void RemoveGem(Transform removePoint)
    {
        if (gems.Count == 0)
            return;
        CameraFollower.MoveDown();
        gems[gems.Count - 1].RemoveGem(removePoint);
        gems.RemoveAt(gems.Count - 1);
    }
}
