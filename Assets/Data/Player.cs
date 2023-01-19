using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;

    public event Action<int> OnChangeScore;
    [SerializeField] private float addScore;
    [SerializeField] private AudioSource sfxPickEdge;
    [SerializeField] private SpawnerEdge spawn;

    private int score;
    private int currentScore;
    private int scoreLives;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Edge"))
        {

            Destroy(collision.gameObject);
            score += Convert.ToInt32(addScore);
            currentScore++;
            scoreLives++;

            OnChangeScore?.Invoke(score);
            if (score >= 999)
            {
                Application.OpenURL("https://www.youtube.com/watch?v=Ho6fLsINiHQ");
                score = 0;
            }
            if (scoreLives == 100 && Lives.lives <= 2)
            {
                scoreLives = 0;
                Lives.lives++;
                Lives.Damage();
            }

            sfxPickEdge.Play();
        }
    }
    public void RightUpposition()
    {
        animator.Play("RightUp");
    }
    public void RightDownposition()
    {

        animator.Play("RightDown");
    }
    public void LeftDownposition()
    {

        animator.Play("leftDown");
    }
    public void LeftUpposition()
    {

        animator.Play("LeftUp");
    }

    private void Update()
    {
        if (currentScore == 15 && SpawnerEdge.timeSpawn > 0.6f)
        {
            currentScore = 0;
            SpawnerEdge.timeSpawn -= 0.2f;
        }
    }
}
