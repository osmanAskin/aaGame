using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.EditorUtilities;
using UnityEngine;

public class Pin : MonoBehaviour
{ 
    [SerializeField] private float speed = 50.0f;
    [SerializeField] private Rigidbody2D rb;

    private bool isPinned = false;

    UIManager _uiManager;
    Rotator _rotator;
    Spawner _spawner;

    private void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _rotator = FindObjectOfType<Rotator>();
        _spawner = FindObjectOfType<Spawner>();
    }

    private void Update()
    {
        if (!isPinned)
        {
            rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RotatorTag")
        {
            //other
            _rotator.speed += 10.0f;
            _uiManager.ScoreSet();
            _uiManager.GoalSet();
            _uiManager.CheckFinish();
            transform.SetParent(collision.transform);
            isPinned = true;
        }

        if(collision.tag == "PinTag") 
        {
            _uiManager.ScoreSet();
            _spawner.isContinuous = false;
            _rotator.speed = 30.0f;
            _rotator.SetRotate();
            _uiManager.GameOver();
            Camera.main.backgroundColor = Color.red;
        }
    }
}
