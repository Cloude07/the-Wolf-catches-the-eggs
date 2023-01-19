using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    static public int lives = 3;
    static public GameObject[] livesPic;

    private void Awake()
    {
        lives = 3;
        livesPic = GameObject.FindGameObjectsWithTag("Lives");
    }
    public static void Damage()
    {
        if (lives == livesPic.Length)
        {
            foreach (GameObject livePic in livesPic)
            {
                livePic.SetActive(true);
            }
            
        }

         if (lives < livesPic.Length)
        {
            livesPic[lives].SetActive(false);

        }

        if (lives <= 0)
        {
            SceneManager.LoadScene(0);
        }

    }
}
