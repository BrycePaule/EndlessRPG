using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]
public class UpgradeSlot : MonoBehaviour
{
    public Upgrade Upgrade;

    [SerializeField] private TMP_Text uiText;
    [SerializeField] private Image uiIcon;

    private UpgradeMenu menu;

    private void OnEnable()
    {
        menu = GetComponentInParent<UpgradeMenu>();
    }

    private void Update()
    {
        uiText.text = Upgrade.UpgradeText;   
        uiIcon.sprite = Upgrade.Sprite;
    }

    public void ApplyUpgrade()
    {
        Upgrade.Apply(
            menu.Player.StatsAsset,
            menu.Player.GetComponentInChildren<PlayerWeapon>().currWeapon
        );

        menu.DisableMenu();
    }
}
