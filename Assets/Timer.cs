using UnityEngine;


public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;


    private void Update()
    {
        if (health == 0)
        {
            Debug.Log("nextLetter");
        }
        else
        {
            health -= Time.deltaTime;
        }
    }
}
