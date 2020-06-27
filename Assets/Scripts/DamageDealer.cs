using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] float damage;

    public float GetDamageAmount()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
