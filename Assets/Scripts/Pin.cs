using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private float speed = 50.0f;
    [SerializeField] private Rigidbody2D rb;

    private bool isPinned = false;

    private AudioManager _audioManager;
    private UIManager _uiManager;
    private Rotator _rotator;
    private Spawner _spawner;

    private void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<AudioManager>();
        _uiManager = FindObjectOfType<UIManager>();
        _rotator = FindObjectOfType<Rotator>();
        _spawner = FindObjectOfType<Spawner>();
    }

    private void Update()
    {
        if (!isPinned)
        {
            MovePin();
        }
    }

    private void MovePin()
    {
        rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RotatorTag")
        {
            HandleRotatorCollision(collision);
        }
        else if (collision.tag == "PinTag")
        {
            HandlePinCollision();
        }
    }

    private void HandleRotatorCollision(Collider2D collision)
    {
        PlaySoundEffect(_audioManager.clickSound);
        SaveAudioState();
        UpdateGameOnRotatorCollision();
        SetParentAndPin(collision.transform);
    }

    private void HandlePinCollision()
    {
        LoadAudioState();
        PlaySoundEffect(_audioManager.failSound);
        GameOver();
    }

    private void PlaySoundEffect(AudioClip clip)
    {
        _audioManager.PlaySFX(clip);
    }

    private void SaveAudioState()
    {
        _audioManager.SaveAudioState();
    }

    private void LoadAudioState()
    {
        _audioManager.LoadAudioState();
    }

    private void UpdateGameOnRotatorCollision()
    {
        _rotator.speed += 10.0f;
        _uiManager.ScoreSet();
        _uiManager.GoalSet();
        _uiManager.CheckFinish();
    }

    private void SetParentAndPin(Transform parent)
    {
        transform.SetParent(parent);
        isPinned = true;
    }

    private void GameOver()
    {
        _uiManager.ScoreSet();
        _spawner.isContinuous = false;
        _rotator.speed = 30.0f;
        _rotator.SetRotate();
        _uiManager.GameOver();
        Camera.main.backgroundColor = Color.red;
    }

  
}

