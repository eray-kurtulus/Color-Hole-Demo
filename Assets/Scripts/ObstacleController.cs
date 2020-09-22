using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private bool isColored;
    [SerializeField] private GameController _gameController;
    private void OnCollisionEnter(Collision other)
    {
        if (isColored && other.collider.tag == "DeathCollider")
        {
            _gameController.GameFailed();
        }
        
        if (!isColored && other.collider.tag == "DeathCollider")
        {
            gameObject.SetActive(false);
        }
    }
}
