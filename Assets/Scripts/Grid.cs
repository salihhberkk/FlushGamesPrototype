using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private GameObject gem;
    public void CreateGem(PoolInfoWithPool gemType)
    {
        gem = gemType.Fetch();
        gem.transform.position = transform.position + Helper.Help(0, 0.5f, 0);
        gem.transform.localScale = Vector3.zero;
        gem.SetActive(true);
        gem.GetComponent<StandartGem>().GrowUp(this);
    }
    public void RecreateGem(PoolInfoWithPool createGemType)
    {
        StartCoroutine(WaitToCreateGem(createGemType));
    }
    IEnumerator WaitToCreateGem(PoolInfoWithPool createGemType)
    {
        yield return new WaitForSeconds(1f);
        CreateGem(createGemType);
    }
}
