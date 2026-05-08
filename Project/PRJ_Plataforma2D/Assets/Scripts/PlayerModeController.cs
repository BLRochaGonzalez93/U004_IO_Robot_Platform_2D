using UnityEngine;

public class PlayerModeController : MonoBehaviour
{

    public GameObject speed, battle;
    SpriteRenderer speedRenderer;
    SpriteRenderer battleRenderer;
    public bool isBattleMode;

    // Start is called before the first frame update
    void Start()
    {
        isBattleMode = true;
        speedRenderer = speed.GetComponent<SpriteRenderer>();
        speedRenderer.color = new Color(255, 255, 255, 0);
        battleRenderer = battle.GetComponent<SpriteRenderer>();
        battleRenderer.color = new Color(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isBattleMode == true)
        {
            isBattleMode = false;
            speedRenderer.color = new Color(255, 255, 255, 255);
            battleRenderer.color = new Color(255, 255, 255, 0);
        }
        else if (Input.GetKeyDown(KeyCode.E) && isBattleMode == false)
        {
            isBattleMode = true;
            speedRenderer.color = new Color(255, 255, 255, 0);
            battleRenderer.color = new Color(255, 255, 255, 255);
        }

    }
}
