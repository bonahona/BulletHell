using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    public List<Image> PanelPart;
    public Text DeathcountText;

	public void SetHealth(int health)
    {
        for(int i = 1; i <= PanelPart.Count; i++) {
            if(health >= i) {
                PanelPart[i -1].enabled = true;
            } else {
                PanelPart[i -1].enabled = false;
            }
        }
    }

    public void SetDeathCount(int deathCount)
    {
        DeathcountText.text = deathCount.ToString("D3");
    }
}
