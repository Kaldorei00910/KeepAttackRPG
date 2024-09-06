using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanelUI : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.WinPanel = this.gameObject;
        this.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
