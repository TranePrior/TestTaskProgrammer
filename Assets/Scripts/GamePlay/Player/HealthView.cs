using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class HealthView : MonoBehaviour
{
    private Player player;
    private TMP_Text healthText;
    
    public void Init(Player player)
    {
        this.player = player;
        healthText = GetComponent<TMP_Text>();
        healthText.text = "Health: " + player.Health;
        player.OnPlayerHealthChanged += UpdateHealthView;
    }
    
    private void UpdateHealthView()
    {
        healthText.text = "Health: " + player.Health;
    }
    
    private void OnDestroy()
    {
        player.OnPlayerHealthChanged -= UpdateHealthView;
    }
}
