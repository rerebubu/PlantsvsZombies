using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootOrigin;

    public float cooldown;
    private bool canShoot;
    public float range;
    public LayerMask shootMask;

    private GameObject target;

    public int health = 4;

    private AudioSource source;
    public AudioClip[] shootClips;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        Invoke("ResetCooldown", cooldown);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, shootMask);

        if (hit.collider)
        {
            target = hit.collider.gameObject;

            Shoot();
        }
    }

    void ResetCooldown()
    {
        canShoot = true;

    }


    void Shoot()
    {
        if (!canShoot)
            return;

        source.PlayOneShot(shootClips[Random.Range(0, shootClips.Length)]);
        //AudioController.Instance.Play("Bullet")
        canShoot = false;
        Invoke("ResetCooldown", cooldown);


        GameObject myBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);

    }
}

