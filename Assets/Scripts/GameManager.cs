using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
    #region Panels
    [Header("Panels")]
    [SerializeField] private GameObject succesPanel;
    [SerializeField] private GameObject losePanel;
    #endregion
    #region Level Progress
    [Header("Level Progress")]
    [SerializeField] private Image gameSlider;
    [SerializeField] private int chunkPoolSize;
    #endregion
    [SerializeField] private GameObject mainPlayer;
    [SerializeField] private TextMeshProUGUI levelTextMP;
    [SerializeField] private int levelCount;

    private void Start()
    {
        levelCount = PlayerPrefs.GetInt("levelCount", levelCount);
        levelTextMP.text ="Level " + levelCount.ToString();
    }
    void Update()
    {
        LevelProgress();
    }
    public void Win()
    {
        succesPanel.SetActive(true);
        levelCount++;
        PlayerPrefs.SetInt("levelCount", levelCount);
        levelTextMP.text = "Level " + levelCount.ToString();
    }
    public void Lose()
    {
        losePanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        succesPanel.SetActive(false);
        losePanel.SetActive(false);

    }
    private void LevelProgress()
    {
        gameSlider.fillAmount = (float)mainPlayer.transform.position.z / (10 * chunkPoolSize);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);// yeni leveller gelince düzelecek burası.
        succesPanel.SetActive(false);
        losePanel.SetActive(false);
        
    }
}
