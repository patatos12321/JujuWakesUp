using Assets;
using Assets.Scripts;
using Assets.Scripts.Fighters;
using Assets.Scripts.FightingMoves;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private int currentWalkingIndex = 0;
    public Sprite[] walkingSprites;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        if (Flags.IsPaused)
            return;

        float x = 0;
        float y = 0;

        if (Application.platform == RuntimePlatform.Android)
        {
            GetAndroidMovements(ref x, ref y);
        }
        else 
        {
            x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            y = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        }

        if (x != 0 || y != 0)
        {
            currentWalkingIndex++;
            if (currentWalkingIndex > walkingSprites.Length * 7 - 1)
            {
                currentWalkingIndex = 0;
            }
            spriteRenderer.sprite = walkingSprites[currentWalkingIndex / 7];
        }
        else
        {
            currentWalkingIndex = 0;
            spriteRenderer.sprite = walkingSprites[currentWalkingIndex];
        }

        var moveDelta = new Vector3(x, y, 0);

        var hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }

    private void GetAndroidMovements(ref float x, ref float y)
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            double halfScreenWidth = Screen.width / 2.0;
            double halfScreenHeigth = Screen.height / 2.0;

            if (touchPosition.x < halfScreenWidth / 2 )
            {
                x = -speed * Time.deltaTime;
            }
            else if (touchPosition.x > halfScreenWidth + halfScreenWidth / 2)
            {
                x = speed * Time.deltaTime;
            }

            if (touchPosition.y < halfScreenHeigth / 2)
            {
                y = -speed * Time.deltaTime;
            }
            else if (touchPosition.y > halfScreenHeigth + halfScreenHeigth / 2)
            {
                y = speed * Time.deltaTime;
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Enemy")
    //    {
    //        CombatManager.EnemySprite = collision.GetComponent<SpriteRenderer>().sprite;
    //        CombatManager.EnemyFighter = collision.GetComponent<FighterFactory>().GetFighter();


    //        CombatManager.PlayerSprite = walkingSprites[0];
    //        CombatManager.PlayerFighter = new FighterJuju()
    //        {
    //            KnownMoves = new List<IFightingMove>() { new MoveOya() }.ToArray()
    //        };

    //        CombatManager.SceneToLoadAfterCombat = SceneManager.GetActiveScene().name;
    //        CombatManager.playerPosition = this.transform.position;
    //        Flags.FirstEnemyDefeated = true;

    //        SceneManager.LoadScene("Combat");
    //    }
    //}
}
