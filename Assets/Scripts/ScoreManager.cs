using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int totalGemsRequired = 6;
    private int gemsCollected = 0;

    private int playersAtFinish = 0; 

    [SerializeField] public GameObject winScreen;
    [SerializeField] public GameObject loseScreen;

    [SerializeField] public TextMeshProUGUI gemCounterText;

    void Start()
    {
        UpdateGemCounter();

        if (winScreen != null) winScreen.SetActive(false); 
        if (loseScreen != null) loseScreen.SetActive(false);
        UpdateGemCounter(); 
    }

    public void CollectGem()
    {
        gemsCollected++;
        UpdateGemCounter();

        Debug.Log($"Gem collected! {gemsCollected}/{totalGemsRequired}");
    }

    public void PlayerReachedFinish()
    {
        playersAtFinish++;
        CheckVictory();
    }

    public void PlayerLeftFinish()
    {
        playersAtFinish--;
    }

    public void PlayerDied()
    {
        Debug.Log("A player has died!");

        if (loseScreen != null)
            loseScreen.SetActive(true);
    }

    private void CheckVictory()
    {
        if (gemsCollected >= totalGemsRequired && playersAtFinish >= 2)
        {
            Debug.Log("Both players reached the finish with all gems collected!");
            if (winScreen != null)
                winScreen.SetActive(true);
        }
    }

    private void UpdateGemCounter()
    {
        int gemsLeft = totalGemsRequired - gemsCollected;
        Debug.Log($"Gems Left: {gemsLeft}");

        if (gemCounterText != null)
        {
            gemCounterText.text = "Gems Left: " + (totalGemsRequired - gemsCollected).ToString();
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
