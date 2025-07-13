using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    Animator anim;
    private int offset;
    private float cooldown, maxCooldown, firerate,hp, bulletSpeed;
    bool isAttackBacking;
    public GameObject Bullet;
    private IEnumerator corutine;
    GameManagerScript gameManagerScript;
    public float[] hpScaling, maxCooldownScaling, bulletSpeedScaling;
    private void Start()
    {
        cooldown = 4;
        firerate = 0.5f;
        isAttackBacking = false;
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        anim = GetComponent<Animator>();
        transform.DOMoveY(3, 2f).SetEase(Ease.InOutSine);
        /*transform.DOMoveY(3, 2f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            transform.DOMoveX(2, 2.5f).SetEase(Ease.InOutSine).OnComplete(() =>
            {
                var sequence = DOTween.Sequence();
                sequence.Append(transform.DOMoveX(-2, 5f).SetEase(Ease.InOutSine));
                sequence.Append(transform.DOMoveX(2, 5f).SetEase(Ease.InOutSine));
                sequence.SetLoops(-1);
            });
        });*/
    }
    private void Update()
    {
        
        if (cooldown <= 0)
        {
            CicleAtack(isAttackBacking);
            isAttackBacking = !isAttackBacking;
            cooldown = maxCooldown;
        }
        if (cooldown > 0 )
            cooldown -= Time.deltaTime;
    }
    public void CicleAtack(bool backing)
    {
        corutine = FireProjectiles(isAttackBacking);
        StartCoroutine(corutine);
    }
    private IEnumerator FireProjectiles(bool backing)
    {
        for (int j = 0; j < 5; j++)
        {
            yield return new WaitForSeconds(firerate);
            for (int i = 0; i < 10; i++)
            {
                var bullet = Instantiate(Bullet, transform.position, transform.rotation);
                bullet.transform.Rotate(new Vector3(0, 0, i * 36 + offset));
                bullet.GetComponent<Bullet>().SetSpeed(bulletSpeed);
                Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

            }
            if (backing)
            {
                offset -= 6;
            }
            else
            {
                offset += 6;
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player_Bullet"))
        {
            hp--;
            anim.SetTrigger("Hit");
            Destroy(collision.gameObject);
            if (hp <= 0)
            {
                gameManagerScript.AddScore(1000);
                gameManagerScript.EndWave();
                transform.DOKill(this.gameObject);
                Destroy(gameObject);
            }
        }
    }
    public void SetDifficulty(int newDifficulty)
    {
        hp = hpScaling[newDifficulty];
        maxCooldown = maxCooldownScaling[newDifficulty];
        bulletSpeed = bulletSpeedScaling[newDifficulty];
    }
}
