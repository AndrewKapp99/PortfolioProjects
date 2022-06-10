using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private GameObject Effect;

    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
        GameObject _effect = Instantiate(Effect, transform.position, transform.rotation);
    }
}
