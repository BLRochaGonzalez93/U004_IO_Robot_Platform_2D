using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    // La velocidad de movimiento del personaje
    public float movementSpeed = 12f;
    // La fuerza del salto del personaje
    public float jumpForce;
    // La cantidad de saltos extra del personaje
    public int extraJumps = 1;
    // La cantidad de saltos que lleva el personaje
    public int currentJumps;
    // Una referencia al componente Rigidbody del personaje
    public Rigidbody2D rb;
    // La forma inicial del personaje (cuadrado o c�rculo)
    public string initialShape = "square";
    // La forma final del personaje (cuadrado o c�rculo)
    public string finalShape = "circle";
    // La forma actual del personaje (cuadrado o c�rculo)
    public string currentShape;
    // Una referencia al componente SpriteRenderer del personaje
    public SpriteRenderer spriteRenderer;
    // Las dos im�genes que se utilizar�n para dibujar al personaje (cuadrado y c�rculo)
    public Sprite squareSprite;
    public Sprite circleSprite;
    // Una bandera para indicar si el personaje est� tocando el suelo
    public bool isGrounded;
    // Una bandera para indicar si el personaje est� tocando las escaleras
    public bool isOnStairs;

    public Transform shootRotate;

    public GameObject bullet;

    public GameObject grabbedObject;

    public LayerMask grabMask;

    public int playerLifes;

    public float lifesTimer;

    bool isDead;

    public int tries;

    public Vector2 respawnPoint;

    public Transform firstRespawn;

    public float fireRate;
    public int totalBullets;
    private float timeRate;
    private float reloadBullet;

    public Image ammoBar;
    public Image triesBar;
    public Image lifesBar;

    private Animator animator;
    public AudioClip[] clipsAudioPlayer;
    AudioSource AudioPlayer;


    // Start is called before the first frame update
    void Start()
    {
        tries = 3;
        isDead = false;
        playerLifes = 10;
        jumpForce = 600f;

        respawnPoint = firstRespawn.position;
        fireRate = 0.5f;
        totalBullets = 5;

        animator = GetComponent<Animator>();

        // Obtenemos la referencia al componente Rigidbody del personaje
        rb = GetComponent<Rigidbody2D>();

        // Obtenemos la referencia al componente SpriteRenderer del personaje
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Establecemos la forma inicial del personaje
        currentShape = initialShape;

        // Cambiamos el sprite del personaje seg�n su forma inicial
        if (currentShape == "square")
        {
            spriteRenderer.sprite = squareSprite;
        }
        else if (currentShape == "circle")
        {
            spriteRenderer.sprite = circleSprite;
        }

        clipsAudioPlayer = Resources.LoadAll<AudioClip>("PlayerClips");
        AudioPlayer = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        ScoreController.SetLifes(playerLifes, tries);

        if (isDead == false)
        {
            //Creamos un comprobador, si el player esta en forma de movilidad, tendr� mas velocidad y un salto extra (2 en total), pero si esta en modo combate, solo dispondr� de un salto, y tendr� una velocidad reducida
            if (currentShape == "square")
            {
                movementSpeed = 8f;
                extraJumps = 0;
            }
            else if (currentShape == "circle")
            {
                movementSpeed = 12f;
                extraJumps = 1;
            }

            // Obtenemos la entrada del usuario para moverse a la derecha o izquierda
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            // Movemos al personaje en la direcci�n de la entrada del usuario
            rb.linearVelocity = new Vector2(horizontalInput * movementSpeed, rb.linearVelocity.y);
            animator.SetBool("walking", rb.linearVelocity.x != 0);
            animator.SetBool("isGround", isGrounded);
            animator.SetBool("Stairs", isOnStairs);


            // Si el usuario presiona el bot�n de salto, hacemos que el personaje salte. Dependiendo si estaba en el suelo o en el aire tendr� saltos extra o no
            if (isGrounded)
            {
                if (currentJumps != 0)
                {
                    currentJumps = 0;
                }

                if (Input.GetButtonDown("Jump"))
                {
                    animator.Play("jump");
                    currentJumps++;
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                    rb.AddForce(Vector2.up * jumpForce);
                }
            }
            else
            {
                if (Input.GetButtonDown("Jump") && currentJumps < extraJumps)
                {
                    animator.Play("secondJump");
                    currentJumps++;
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                    rb.AddForce(Vector2.up * jumpForce);
                }
            }
            // Si el usuario presiona el bot�n de subir, hacemos que el personaje suba o baje. Dependiendo si estaba en la escalera o no
            if (isOnStairs)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, verticalInput * 2);
                rb.gravityScale = 0;

            }

            // Si el usuario presiona el bot�n de cambio de forma y la forma actual del personaje es diferente de la forma final, cambiamos la forma del personaje
            if (Input.GetKeyDown(KeyCode.E) && currentShape != finalShape)
            {
                // Cambiamos la forma actual del personaje
                currentShape = finalShape;

                // Cambiamos el sprite del personaje seg�n su forma actual
                if (currentShape == "square")
                {
                    spriteRenderer.sprite = squareSprite;
                }
                else if (currentShape == "circle")
                {
                    spriteRenderer.sprite = circleSprite;
                }
                finalShape = initialShape;
                initialShape = currentShape;
            }

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                float shootDirection;

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    shootDirection = 0;
                    transform.GetComponent<SpriteRenderer>().flipX = false;
                    shootRotate.localEulerAngles = new Vector2(0, shootDirection);
                }
                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    shootDirection = 180;
                    transform.GetComponent<SpriteRenderer>().flipX = true;
                    shootRotate.localEulerAngles = new Vector2(0, shootDirection);
                }
            }

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (AudioPlayer.isPlaying == false)
                {
                    AudioPlayer.volume = 0.25f;
                    AudioPlayer.Play();
                    
                }
            }
            else
            {
                AudioPlayer.Stop();
            }

            if (totalBullets >= 5)
            {
                reloadBullet = 0;
            }
            else
            {
                reloadBullet += Time.deltaTime;
                if (reloadBullet > 3 && totalBullets < 5)
                {
                    reloadBullet = 0;
                    totalBullets++;
                }
            }

            timeRate += Time.deltaTime;

            if (Input.GetButtonDown("Fire1") && timeRate > fireRate && totalBullets > 0 && currentShape == "square")
            {
                //Hacemos que el player solo pueda disparar en su forma de combate
                totalBullets--;
                timeRate = 0;
                //Creamos nuevo objeto, indicamos que es del tipo (Bala), donde se instancia y con que rotacion
                animator.Play("shoot");
                GameObject newBullet = Instantiate(bullet, shootRotate.GetChild(0).position, shootRotate.GetChild(0).rotation);
                Destroy(newBullet, 2);
                GameObject newSound = new GameObject("Wav_RocketLaunch");
                AudioSource audioSource = newSound.AddComponent<AudioSource>();
                audioSource.clip = clipsAudioPlayer[1];
                audioSource.volume = 0.25f;
                audioSource.Play();
                Destroy(newSound, 1);
            }

            //Hacemos que el player pueda agarrar un objeto con el click derecho del raton
            if (Input.GetButtonDown("Fire2"))
            {
                if (grabbedObject != null)
                {
                    grabbedObject.transform.SetParent(null);
                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    grabbedObject.GetComponent<Collider2D>().enabled = true;
                    grabbedObject = null;
                    return;
                }
                else
                {
                    Collider2D tempObj = Physics2D.OverlapCircle(shootRotate.GetChild(0).position, 0.3f, grabMask);
                    if (tempObj != null)
                    {
                        grabbedObject = tempObj.gameObject;
                    }

                    if (grabbedObject != null)
                    {
                        grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                        grabbedObject.GetComponent<Collider2D>().enabled = false;
                        grabbedObject.transform.SetParent(shootRotate.GetChild(0));
                    }
                }
            }

            ammoBar.fillAmount = totalBullets / 5f;
            lifesBar.fillAmount = playerLifes / 10f;

            if (playerLifes <= 0)
            {
                tries--;
                triesBar.fillAmount = tries / 3f;
                if (tries <= 0)
                {
                    isDead = true;
                    horizontalInput = 0;
                    animator.Play("finalDeath");
                    Invoke("PlayerDead", 2);
                }
                else
                {
                    transform.position = new Vector2(respawnPoint.x, respawnPoint.y);
                    playerLifes = 10;
                    lifesTimer = 0;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Si el personaje colisiona con el suelo, establecemos la bandera isGrounded en verdadero
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (other.gameObject.tag == "Stairs")
        {
            isOnStairs = true;
        }

        if (other.gameObject.tag == "Enemy1")
        {
            playerLifes--;
            GameObject newSound = new GameObject("Wav_RocketLaunch");
            AudioSource audioSource = newSound.AddComponent<AudioSource>();
            audioSource.clip = clipsAudioPlayer[3];
            audioSource.volume = 0.5f;
            audioSource.Play();
            animator.Play("damage");
        }

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy1")
        {
            lifesTimer += Time.deltaTime;
            if (lifesTimer >= 1)
            {
                playerLifes--;
                GameObject newSound = new GameObject("Wav_RocketLaunch");
                AudioSource audioSource = newSound.AddComponent<AudioSource>();
                audioSource.clip = clipsAudioPlayer[3];
                audioSource.volume = 0.5f;
                audioSource.Play();
                animator.Play("damage");
                lifesTimer = 0;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // Si el personaje deja de colisionar con el suelo, establecemos la bandera isGrounded en falso
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }

        if (other.gameObject.tag == "Stairs")
        {
            isOnStairs = false;
            rb.gravityScale = 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlatformCollider")
        {
            transform.SetParent(other.transform);
        }

        if (isDead == false)
        {
            if (other.tag == "Trap")
            {
                playerLifes = 0;
            }

            if (other.tag == "ElectricWall")
            {
                playerLifes -= 2;
                GameObject newSound = new GameObject("Wav_RocketLaunch");
                AudioSource audioSource = newSound.AddComponent<AudioSource>();
                audioSource.clip = clipsAudioPlayer[3];
                audioSource.volume = 0.5f;
                audioSource.Play();
                animator.Play("damage");
            }

            if (other.tag == "EnemyBullet")
            {
                playerLifes--;
                GameObject newSound = new GameObject("LaseImpactSound");
                AudioSource audioSource = newSound.AddComponent<AudioSource>();
                audioSource.clip = clipsAudioPlayer[2];
                audioSource.Play();
                Destroy(newSound, 1);
                GameObject newSound2 = new GameObject("LaseImpactSoundss");
                AudioSource audioSource2 = newSound2.AddComponent<AudioSource>();
                audioSource2.clip = clipsAudioPlayer[3];
                audioSource2.Play();
                Destroy(newSound2, 1);
                animator.Play("damage");
            }

            if (other.tag == "Coin")
            {
                ScoreController.SetScore(1);
                Destroy(other.gameObject);
            }

            if (other.tag == "FinishLevel")
            {
                ScoreController.SetScore(TimerControl.getFloatTime());
                PlayerPrefs.SetString("Time", TimerControl.getTime());
                PlayerPrefs.SetFloat("Score", ScoreController.GetScore());
                SceneManager.LoadScene(3);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isDead == false)
        {
            if (other.tag == "ElectricWall")
            {
                lifesTimer += Time.deltaTime;
                if (lifesTimer >= 1)
                {
                    playerLifes--;
                    GameObject newSound2 = new GameObject("LaseImpactSoundss");
                    AudioSource audioSource2 = newSound2.AddComponent<AudioSource>();
                    audioSource2.clip = clipsAudioPlayer[3];
                    audioSource2.Play();
                    Destroy(newSound2, 1);
                    animator.Play("damage");
                    lifesTimer = 0;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlatformCollider")
        {
            transform.SetParent(null);
        }
    }

    public void PlayerDead()
    {
        SceneManager.LoadScene(4);
    }
}