using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackManager : MonoSingleton<StackManager>
{
    [SerializeField] private Transform stackTransform;
    [SerializeField] private List<StandartGem> gems = new();
    private CameraFollower CameraFollower;
    public float totalGemsYHeight = 0f;
    private void Start()
    {
        CameraFollower = CameraFollower.Instance;
    }
    public void AddGem(StandartGem newGem)
    {
        float newGemSize = newGem.GetComponent<Renderer>().bounds.size.y;

        CameraFollower.MoveUp(newGemSize);
        gems.Add(newGem);
        newGem.transform.SetParent(stackTransform.transform);
        newGem.transform.localRotation = Quaternion.Euler(Vector3.zero);
        newGem.transform.DOLocalJump(Helper.Help(0, totalGemsYHeight + (newGemSize /2f), 0), 0.1f, 1, 1f).SetEase(Ease.OutBounce);

        totalGemsYHeight += newGemSize;
    }
    public void RemoveGem(Transform removePoint)
    {
        if (gems.Count == 0)
            return;
        float gemSize = gems[gems.Count - 1].transform.localScale.y * 0.6f; //0.6 modelin bounds y si

        totalGemsYHeight -= gemSize;
        CameraFollower.MoveDown(gemSize);
        gems[gems.Count - 1].RemoveGem(removePoint);
        gems.RemoveAt(gems.Count - 1);
    }
}
