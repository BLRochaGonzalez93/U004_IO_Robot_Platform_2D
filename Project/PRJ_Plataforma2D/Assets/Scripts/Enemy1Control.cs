using UnityEngine;
using UnityEngine.UI;

public class Enemy1Control : MonoBehaviour
{
    public float speed;
    public int direction;
    Rigidbody2D rb;
    public LayerMask colMask;

    //Determinara el tipo de enemigo
    public bool canShoot;

    public Transform shootRotate;
    public GameObject enemyBullet;
    public float fireRate;

    private SpriteRenderer spriteRender;
    public Sprite sprite;
    public string spriteName;

    public Image enemyLifeBar;
    public float lives;

    public AudioClip[] clipsAudioEnemies;
    public float spatialBlend;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 2f;

        direction = 1;
        if (direction >= 0)
        {
            shootRotate.localEulerAngles += new Vector3(0, 0, 0);
        }
        else
        {
            shootRotate.localEulerAngles += new Vector3(0, 180, 0);
        }

        spriteRender = GetComponent<SpriteRenderer>();
        sprite = spriteRender.sprite;
        spriteName = sprite.name;

        clipsAudioEnemies = Resources.LoadAll<AudioClip>("EnemiesClips");
    }

    // Update is called once per frame
    void Update()
    {
        enemyLifeBar.fillAmount = GetComponent<DestructibleItem>().enemy1Lifes / 8f;
        lives = GetComponent<DestructibleItem>().enemy1Lifes / 8f;

        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        Vector2 detectPosition = transform.position;
        detectPosition.x += 0.2f * direction;
        Collider2D detector = Physics2D.OverlapCircle(detectPosition, 0.3f, colMask);
        float distancia = Vector3.Distance(transform.position, player.transform.position);

        if (direction >= 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (detector != null)
        {
            direction *= -1;
            shootRotate.localEulerAngles += new Vector3(0, 180, 0);
        }

        if (canShoot == true)
        {
            fireRate += Time.deltaTime;
            if (fireRate >= 2)
            {
                GameObject newSound = new GameObject("LasertSound");
                AudioSource audioSource = newSound.AddComponent<AudioSource>();
                audioSource.clip = clipsAudioEnemies[2];
                float spatialBlend = Mathf.Clamp01(1 - distancia / 50);
                audioSource.volume = spatialBlend;
                //audioSource.volume = 0.25f;
                audioSource.Play();
                Destroy(newSound, 1);
                GameObject newBullet = Instantiate(enemyBullet, shootRotate.GetChild(0).position, shootRotate.GetChild(0).rotation);
                Destroy(newBullet, 2);
                fireRate = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            if (canShoot == true)
            {
                GameObject newSound2 = new GameObject("LasertSound");
                AudioSource audioSource2 = newSound2.AddComponent<AudioSource>();
                audioSource2.clip = clipsAudioEnemies[3];
                audioSource2.volume = 0.25f;
                audioSource2.Play();
                Destroy(newSound2, 1);
                GameObject newSound = new GameObject("LasertSoundss");
                AudioSource audioSource = newSound.AddComponent<AudioSource>();
                audioSource.clip = clipsAudioEnemies[0];
                audioSource.volume = 0.5f;
                audioSource.Play();
                Destroy(newSound, 1);
            }
            else
            {
                GameObject newSound2 = new GameObject("LasertSound");
                AudioSource audioSource2 = newSound2.AddComponent<AudioSource>();
                audioSource2.clip = clipsAudioEnemies[3];
                audioSource2.volume = 0.25f;
                audioSource2.Play();
                Destroy(newSound2, 1);
                GameObject newSound = new GameObject("LasertSoundss");
                AudioSource audioSource = newSound.AddComponent<AudioSource>();
                audioSource.clip = clipsAudioEnemies[1];
                audioSource.spatialBlend = 1;
                audioSource.Play();
                Destroy(newSound, 1);
            }
        }
    }
}
