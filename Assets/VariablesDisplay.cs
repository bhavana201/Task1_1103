using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Random = UnityEngine.Random;
public class VariablesDisplay : MonoBehaviour
{
    public int score;

    public TextMeshProUGUI highScore;
    public TextMeshProUGUI textD;
    public TextMeshProUGUI textD2;
    public TextMeshProUGUI keyboard;


    void Start()
    {
        User();
        InvokeRepeating("User", 2.0f, 2.0f);
        UpdateHighScoreText();

    }
    void CheckHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            UpdateHighScoreText();
        }
    }
    void UpdateHighScoreText()
    {

        highScore.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
    public void Update()
    {
        if (Input.anyKeyDown)
        {
            UpdateHighScoreText();
            //timer = GetComponent<Timer>();
            if (Input.inputString == textD.text)
            {
                score = score + 2;
                textD2.text = "Score :" + score;
                CheckHighScore();
                User();
                keyboard.text = Input.inputString;

            }
            else
            {
                score -= 1;
                textD2.text = "Score : " + score;
                keyboard.text = Input.inputString;
                CheckHighScore();
                if (score <= 0)
                {
                    string currentSceneName = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(currentSceneName);
                }

            }

        }
    }
    public void User()
    {
        char a = (char)(Random.Range('a', 'z'));
        textD.text = char.ToString(a);
        // keyboard.text = Input.inputString;
    }
}
