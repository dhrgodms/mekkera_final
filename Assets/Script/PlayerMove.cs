using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    public bool isTouchLeft;
    public bool isTouchRight;
    public int life;
    public int point;
    public float maxSpeed;
    public GameObject life1, life2, life3;
    public GameObject player;
    public GameObject gameOverSet;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    GameManager manager;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        manager = GetComponent<GameManager>();
        
    }

    void Update()
    {
        //미끄러지지 않고 움직임
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1)||(isTouchLeft&&h==-1))
            h = 0;
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, 0, 0) * maxSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "left":
                    isTouchLeft = true;
                    break;
                case "right":
                    isTouchRight = true;
                    break;
            }
        }

        //지렁이에 닿으면 목숨 -1
        if (collision.gameObject.tag == "Enemy")
        {
            //Point

            //Deactive Item
            OnDamaged();
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }

        //귤 닿으면 점수 +1
        if (collision.gameObject.tag == "Item")
        {
            UpPoint();
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        //좌우 경계에 걸렸을 때 떨림 X
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "left":
                    isTouchLeft = false;
                    break;
                case "right":
                    isTouchRight = false;
                    break;
            }
        }

        
    }

    void OnDamaged()
    {
        
        //Change Layer
        gameObject.layer = 11;

        life -= 1;

        if (life == 2)
            life1.SetActive(false);
        else if (life == 1)
            life2.SetActive(false);
        else GameOver();



        //View Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        Invoke("OffDamaged", 0.5f);
    }
    
    void OffDamaged()
    {
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void UpPoint()
    {
        gameObject.layer = 11;

        point += 1;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        Invoke("OffDamaged", 0.5f);
    }
    public void GameOver()
    {
        gameOverSet.SetActive(true);
    }
    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }
}
