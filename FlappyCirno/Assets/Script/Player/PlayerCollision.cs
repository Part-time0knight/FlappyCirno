using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour, ICollision
{
    private IController controller;
    public void Init(IController controller)
    {
        this.controller = controller;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller.Hit();
    }
}
