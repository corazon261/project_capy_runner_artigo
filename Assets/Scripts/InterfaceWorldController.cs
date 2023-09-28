using Player;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceWorldController : MonoBehaviour
{
    public Slider sliderVida;
    private PlayerStatus player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        sliderVida.maxValue = player.MaxHealth;
        Atualiza();
    }
    
    public void Atualiza()
    {
        sliderVida.value = player.Health;
    }
}
