using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    private float speed;

    private int health;

    private int damage;
    private float range;

    public ZombieType type;


    public LayerMask plantMask;

    private float eatCooldown;

    public bool canEat = true;

    public Plant targetPlant;

    private AudioSource source;
    public AudioClip[] groans;

    private void Start()
    {
        
        health = type.health;
        speed = type.speed;
        damage = type.damage;
        range = type.range; 
        eatCooldown = type.eatCooldown;

        source = GetComponent<AudioSource>();
        GetComponent<SpriteRenderer>().sprite = type.sprite;

        Invoke("Groan", UnityEngine.Random.Range(1f, 20f));
    }

    void Groan()
    {
        source.PlayOneShot(groans[UnityEngine.Random.Range(0, groans.Length)]);
    }

    private void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, plantMask);
        if (hit.collider)
        {
            targetPlant = hit.collider.GetComponent<Plant>();
            Eat();
        }

       

    }

    void Eat()
    {
        if (!canEat || !targetPlant)
            return;
        canEat = false;
        Invoke("ResetEatCooldown", eatCooldown);

        targetPlant.Hit(damage);
    }

    void ResetEatCooldown()
    {
        canEat = true;
    }




    private void FixedUpdate () {

        if(!targetPlant)    
            transform.position -= new Vector3(speed, 0, 0);
    }

    public void Hit(int damage, bool freeze)
    {
        source.PlayOneShot(type.hitClips[UnityEngine.Random.Range(0, type.hitClips.Length)]);
        health -= damage;
        if (freeze)
             Freeze();
        if (health <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = type.deathSprite;
            Destroy(gameObject, 1);
        }
    }
    

    void Freeze()
    {
        CancelInvoke("UnFreeze");
        GetComponent<SpriteRenderer>().color = Color.blue;
        speed = type.speed / 2;
        Invoke("UnFreeze", 5);
    }

    void UnFreeze()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        speed = type.speed;
    }

}

