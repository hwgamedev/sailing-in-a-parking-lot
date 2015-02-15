using UnityEngine;
using System.Collections;


public class MagicCombiner : MonoBehaviour
{
    public bool attackOn = false;
    public bool shieldOn = false;
    public bool earthOn = false;
    public bool windOn = false;
    public bool fireOn = false;
    

    private SpriteRenderer spriteRenderer;
    private GameObject[] tokens = new GameObject[5];
    private GameObject[] _tokens = new GameObject[5];
    private Sprite[] sprites;


    void Start()
    {
        tokens = Resources.LoadAll<GameObject>("Prefabs/Tokens");
		Canvas c = GameObject.FindObjectOfType<Canvas> ();
        for (int i = 0; i < tokens.Length; i++ )
        {
            _tokens[i] = Instantiate(tokens[i], tokens[i].transform.position, Quaternion.identity) as GameObject;
			_tokens[i].transform.parent = c.transform;
			_tokens[i].transform.localPosition = tokens[i].transform.position;
			_tokens[i].transform.localScale = tokens[i].transform.localScale;
        }
        sprites = Resources.LoadAll<Sprite>("Sprites/MagicComb/Combiner");
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = sprites[0];

    }

    // Update is called once per frame
    void Update()
    {
        checkCollisions();
        updateSprite();
    }

    void checkCollisions()
    {
        if (!attackOn)
        {
            if (renderer.bounds.Intersects(_tokens[0].renderer.bounds))
            {
                attackOn = true;
                Destroy(_tokens[0]);
            }
        }
        if (!shieldOn)
        {
            if (renderer.bounds.Intersects(_tokens[1].renderer.bounds))
            {
                shieldOn = true;
                Destroy(_tokens[1]);
            }
        }
        if (!earthOn)
        {
            if (renderer.bounds.Intersects(_tokens[2].renderer.bounds))
            {
                earthOn = true;
                Destroy(_tokens[2]);
            }
        }
        if (!windOn)
        {
            if (renderer.bounds.Intersects(_tokens[3].renderer.bounds))
            {
                windOn = true;
                Destroy(_tokens[3]);
            }
        }
        if (!fireOn)
        {
            if (renderer.bounds.Intersects(_tokens[4].renderer.bounds))
            {
                fireOn = true;
                Destroy(_tokens[4]);
            }
        }
    }

    void updateSprite()
    {
        if(earthOn && attackOn)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if(windOn && attackOn)
        {
            spriteRenderer.sprite = sprites[2];
        }
        else if (fireOn && attackOn)
        {
            spriteRenderer.sprite = sprites[3];
        }
        else if (earthOn && shieldOn)
        {
            spriteRenderer.sprite = sprites[4];
        }
        else if (windOn && shieldOn)
        {
            spriteRenderer.sprite = sprites[5];
        }
        else if (fireOn && shieldOn)
        {
            spriteRenderer.sprite = sprites[6];
        }
        else if (attackOn)
        {
            spriteRenderer.sprite = sprites[7];
        }
        else if (shieldOn)
        {
            spriteRenderer.sprite = sprites[8];
        }
        else if (earthOn)
        {
            spriteRenderer.sprite = sprites[9];
        }
        else if (windOn)
        {
            spriteRenderer.sprite = sprites[10];
        }
        else if (fireOn)
        {
            spriteRenderer.sprite = sprites[11];
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
        }
    }

    void removeDuplicates()
    {
        if(earthOn)
        {
            windOn = false;
            fireOn = false;
        }
        if (windOn)
        {
            earthOn = false;
            fireOn = false;
        }
        if (fireOn)
        {
            earthOn = false;
            fireOn = false;
        }
        if (attackOn)
        {
            shieldOn = false;
        }
        if (shieldOn)
        {
            attackOn = false;
        }
    }
}
