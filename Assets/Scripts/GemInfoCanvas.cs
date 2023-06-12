using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemInfoCanvas : MonoSingleton<GemInfoCanvas>
{
    [SerializeField] private GameObject gemInfoPanel;
    [SerializeField] private FloatingJoystick joystick;

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
