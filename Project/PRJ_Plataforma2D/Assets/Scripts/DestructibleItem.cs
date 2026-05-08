using UnityEngine;

public class DestructibleItem : MonoBehaviour
{
    public int lifes = 4;
    public int enemy1Lifes;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        enemy1Lifes = lifes * 2;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            if (transform.tag == "Enemy1")
            {
                bool isDestroyed = true;
                enemy1Lifes--;
                if (enemy1Lifes <= 0)
                {
                    if (isDestroyed == true)
                    {
                        ScoreController.SetScore(5);
                    }
                    GetComponent<Enemy1Control>().speed = 0;
                    animator.Play("death");
                    Destroy(gameObject,1);
                    isDestroyed = false;
                }
            }
            else
            {
                lifes--;
                if (lifes <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
