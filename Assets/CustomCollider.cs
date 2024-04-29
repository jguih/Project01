using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomCollider : MonoBehaviour
{
    private readonly List<Action<Collider2D>> Listeners = new();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NotifyListeners(collision);
    }

    private void NotifyListeners(Collider2D collision)
    {
        Listeners.ForEach((listener) =>
        {
            listener.Invoke(collision);
        });
    }

    public void AddListener(Action<Collider2D> action)
    {
        Listeners.Add(action);
    }
}
