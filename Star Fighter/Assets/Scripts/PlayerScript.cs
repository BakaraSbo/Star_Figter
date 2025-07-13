using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerScript : MonoBehaviour
{
    
    private float lives, weapon, speed, firerate = 1, timeToFire = 0, immortality;

    public Animator anim;
    public GameObject bullet;
    public GameManagerScript gameManagerScript;
    public TextMeshProUGUI livesText;
    private void Start()
    {
        speed = 4;
    }

    void Update()
    {
        this.transform.position += speed * Time.deltaTime* new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        
        if (Input.GetKey(KeyCode.RightControl))
        {
            if (timeToFire > firerate)
            {
                Attack();
                timeToFire = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            weapon++;
        }
        if (timeToFire < firerate)
        {
            timeToFire += Time.deltaTime;
        }
        if (immortality > 0)
        {
            immortality -= Time.deltaTime;
        }
        livesText.text = lives.ToString();
    }

    void CreateBullet(float angle, float move)
    {
        var bulletCreated = Instantiate(bullet, transform.position, transform.rotation);
        bulletCreated.transform.Rotate(0, 0, angle);
        bulletCreated.GetComponent<Bullet>().SetSpeed(7);
        bulletCreated.transform.position = new Vector3(transform.position.x - move, transform.position.y, transform.position.z) ;
    }
    void Attack()
    {
        if (weapon == 1)
        {
            CreateBullet(0, 0);
        }
        else if (weapon == 2)
        {
            CreateBullet(0, 0.3f);
            CreateBullet(0, -0.3f);
        }
        else if (weapon == 3)
        {
            CreateBullet(0, 0);
            CreateBullet(5, 0.1f);
            CreateBullet(-5, -0.1f);
        }
        else if (weapon == 4)
        {
            CreateBullet(0, 0.3f);
            CreateBullet(0, -0.3f);
            CreateBullet(5, 0.4f);
            CreateBullet(-5, -0.4f);
        }
        else if (weapon == 5)
        {
            CreateBullet(0, 0);
            CreateBullet(5, 0.1f);
            CreateBullet(-5, -0.1f);
            CreateBullet(10, 0.2f);
            CreateBullet(-10, -0.2f);
        }
        FindObjectOfType<AudioManager>().Play("Bullet");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy_Bullet")
        {
            
            Destroy(collision.gameObject);
            if (immortality <= 0)
            {
                if (lives > 1)
                {
                    lives--;
                    immortality = 2f;
                }
                else
                {
                    gameManagerScript.EndGame();
                }
            }
        }
        else if(collision.gameObject.tag == "Power_Up")
        {
            if (weapon < 5)
                weapon++;
            Destroy(collision.gameObject);
        }
    }
    public void SetLives(int numberOfLives)
    {
        lives = numberOfLives;
    }
    public float GetWeapon()
    {
        return weapon;
    }
    public void SetWeapon(float weaponSet)
    {
        weapon = weaponSet;
    }
}