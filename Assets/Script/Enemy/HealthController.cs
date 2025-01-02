using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private Character _character;
    private void Awake()
    {
        _character = GetComponent<Character>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Weapon weapon))
        {
            _character.ClaimDamage(weapon.Damage);
        }
    }
}
