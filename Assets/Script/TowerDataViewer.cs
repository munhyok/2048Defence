using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDataViewer : MonoBehaviour
{
    private void Awake()
    {
        OffPanel();

    }

    private void update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OffPanel();
        }
    }

    public void OnPanel()
    {
        gameObject.SetActive(true);

    }

    public void OffPanel()
    {
        gameObject.SetActive(false);
    }
}
