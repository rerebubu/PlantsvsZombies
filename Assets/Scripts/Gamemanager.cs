using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gamemanager : MonoBehaviour
{

    public GameObject currentPlant;
    public Sprite currentPlantSprite;
    public Transform tiles;

    public LayerMask tileMask;

    public int suns;
    public TextMeshProUGUI sunText;
    public LayerMask sunMask;

    public AudioClip plantSFX;
    private AudioSource source;

    public AudioSource sunSource;
    public AudioClip sunClip;   
    
     
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void BuyPlant(GameObject plant, Sprite sprite)
    {
        currentPlant = plant;
        currentPlantSprite = sprite;
    }

    private void Update()
    {
        sunText.text = suns.ToString();


        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileMask);

        foreach (Transform tile in tiles)
            tile.GetComponent<SpriteRenderer>().enabled = false;

        if (hit.collider && currentPlant)
        {
            hit.collider.GetComponent<SpriteRenderer>().sprite = currentPlantSprite;
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;

            if (Input.GetMouseButtonDown(0) && hit.collider.GetComponent<Tile>().hasPlant)
            {
                Plant(hit.collider.gameObject);
            }
        }

        RaycastHit2D sunHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, sunMask);

        if (sunHit.collider)
        {
            if (Input.GetMouseButtonDown(0)) {
                sunSource.pitch = Random.Range(.90f, 1.1f);
                sunSource.PlayOneShot(sunClip);
                
                suns += 25;
                Destroy(sunHit.collider.gameObject);
            }



        }

    }
    void Plant(GameObject hit)
    {
        source.PlayOneShot(plantSFX);
        Instantiate(currentPlant, hit.transform.position, Quaternion.identity);
        hit.GetComponent<Tile>().hasPlant = true;
        currentPlant = null;
        currentPlantSprite = null;
       
    }

}

