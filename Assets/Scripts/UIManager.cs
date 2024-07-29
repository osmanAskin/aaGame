using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro.EditorUtilities;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI goalText;
    [SerializeField] private GameObject taptobuttonObject;
    [SerializeField] private GameObject pinSpawnPointObject;
   
    public int score = 0;
    public bool isOver = false;

    private decimal goal;

    AudioManager _audioManager;
    Rotator _rotator;
    Spawner _spawner;
    DoTweenScale _doTweenScale;

    private void Awake()
    {
        goal = Random.Range(3, 21);
    }

    private void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioTag").GetComponent<AudioManager>();
        _spawner = FindObjectOfType<Spawner>();
        _rotator = FindObjectOfType<Rotator>();
        _doTweenScale = FindObjectOfType<DoTweenScale>();
    }

    public void CheckFinish() 
    {
        if (goal == 0)
        {
            //sound
            _audioManager.PlaySFX(_audioManager.winSound);
            //other
            _spawner.isContinuous = false;
            pinSpawnPointObject.SetActive(false);

            isOver = true;
            taptobuttonObject.SetActive(true);

            Camera.main.backgroundColor = Color.green;
            _rotator.speed = 70.0f;
            _doTweenScale.RotatorScaleIncrease();
        }
    }
    
    public void ScoreSet() 
    {
        if(!isOver) 
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    public void GoalSet() 
    {
        goal--;
        goalText.text = goal.ToString();
    }

    public void GameOver() 
    {
        isOver = true;
        pinSpawnPointObject.SetActive(false);
        taptobuttonObject.SetActive(true);
        scoreText.text = "!".ToString();
    }

    public void TapToButton() 
    {
        SceneManager.LoadScene("Level1");
    }


}
