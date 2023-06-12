using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemInfoCanvas : MonoSingleton<GemInfoCanvas>
{
    [SerializeField] private GameObject gemInfoPanel;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private List<StandartGem> gems = new();
    [SerializeField] private GemInfoImage gemInfoImagePrefab;
    [SerializeField] private Transform contentTransform;

    private List<GemInfoImage> gemInfoImages = new();

    private void Start()
    {
        for (int i = 0; i < gems.Count; i++)
        {
            var newGemImage = Instantiate(gemInfoImagePrefab, contentTransform.position, Quaternion.identity, contentTransform);
            newGemImage.GetComponent<GemInfoImage>().SetValues(gems[i].gemIcon, gems[i].gemName);
            gemInfoImages.Add(newGemImage);
        }
    }
    public void SetCountTexts(string gemName)
    {
        int totalGemCount = PlayerPrefs.GetInt(gemName, 0);
        totalGemCount++;
        PlayerPrefs.SetInt(gemName, totalGemCount);

        for (int i = 0; i < gemInfoImages.Count; i++)
        {
            gemInfoImages[i].SetCountText();
        }
    }
    public void CloseInfoPanel()
    {
        gemInfoPanel.SetActive(false);
        joystick.enabled = true;
    }
    public void OpenInfoPanel()
    {
        gemInfoPanel.SetActive(true);
        joystick.enabled = false;
    }
}
