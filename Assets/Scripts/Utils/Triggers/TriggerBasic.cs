using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerBasic : MonoBehaviour
{
    [Header("Quando Entra na Colisão")]
    [Tooltip("Marca se deverá destruir o objeto assm que entra em colisão")]
    [SerializeField] bool destroyOnTrigger;
    public UnityEvent OnTrigger;

    [Space(10)]
    [Header("Quando Sai da Colisão")]
    [Tooltip("Marca se deverá destruir o objeto quando sai da colisão.")]
    [SerializeField] bool destroyExitTrigger;
    public UnityEvent ExitTrigger;

    [Space(10)]
    [Header("Setup")]
    [Tooltip("Selecionar a Tag que será validada na colisão.")]
    [SerializeField] string tagName;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tagName))
        {
            OnTrigger?.Invoke();

            if (destroyOnTrigger)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tagName))
        {
            ExitTrigger?.Invoke();

            if (destroyExitTrigger)
            {
                Destroy(gameObject);
            }
        }
    }
}
