using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesArea : MonoBehaviour
{
    [SerializeField] private float salesDelay = 1f;
    private bool startSale = false;
    private float delayCounter;

    private void Start()
    {
        ResetCounter();
    }

    private void Update()
    {
        delayCounter -= Time.deltaTime;
        if (delayCounter <= 0 && startSale)
        {
            // sell gem
            StackManager.Instance.RemoveGem(transform);
            ResetCounter();
        }
    }
    private void ResetCounter()
    {
        delayCounter = salesDelay;
    }
    private void OnTriggerEnter(Collider other)
    {
        startSale = true;
    }
    private void OnTriggerExit(Collider other)
    {
        startSale = false;
    }
}
