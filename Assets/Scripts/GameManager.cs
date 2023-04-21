using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public int Points { get; private set; }



    public UnityEvent<int> OnPointsUpdate;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    private void Start()
    {
        ResetScore();
    }

    public void AddPoints(int points)
    {
        // Show & update points UI
        // callback for levls
        Points += points;
        OnPointsUpdate.Invoke(Points);
    }

    public void ResetScore()
    {
        Points = 0;
        OnPointsUpdate.Invoke(Points);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
