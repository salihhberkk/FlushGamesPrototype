using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartGem : MonoBehaviour
{
    private bool isCollect = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isCollect)
            return;
        isCollect = true;
        other.GetComponent<StackManager>().AddGem(this);
    }
    public void SetCollect()
    {
        isCollect = false;
    }
}
