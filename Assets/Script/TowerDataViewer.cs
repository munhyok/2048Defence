using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerDataViewer : MonoBehaviour
{
    [SerializeField]
    private Image       imageTower;
    [SerializeField]
    private TextMeshProUGUI textDamage;
    [SerializeField]
    private TextMeshProUGUI textRate;
    [SerializeField]
    private TextMeshProUGUI textRange;
    [SerializeField]
    private TextMeshProUGUI textLevel;
    [SerializeField]
    private TextMeshProUGUI towerAttackRange;
    

    [SerializeField]
    private Button      buttonUpgrade;

    private TowerWeapons currentTower;

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

    private void UpdateTowerData()
    {
        imageTower.sprite = currentTower.TowerSprite;
    }

    public void OnClickEventTowerUpgrade()
    {
        bool isSuccess = currentTower.Upgrade();

        if (isSuccess == true)
        {
            UpdateTowerData();
            Debug.Log("test");
        }
    }
    
}
