using UnityEngine;
using System.Collections;


public class MagicCombiner : MonoBehaviour
{
    public bool earthOn = false;
    public bool attackOn = false;

    private SpriteRenderer spriteRenderer;
    private GameObject[] tokens = new GameObject[2];
    private GameObject[] _tokens = new GameObject[2];
    private Sprite[] sprites;


    void Start()
    {
        tokens = Resources.LoadAll<GameObject>("Prefabs/Tokens");
        for (int i = 0; i < tokens.Length; i++ )
        {
            _tokens[i] = Instantiate(tokens[i]) as GameObject;
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
    }

    void checkCollisions()
    {
        if (!earthOn)
        {
            if (renderer.bounds.Intersects(_tokens[0].renderer.bounds))
            {
                earthOn = true;
                updateSprite();
                Destroy(_tokens[0]);
            }
        }
        if (!attackOn)
        {
            if (renderer.bounds.Intersects(_tokens[1].renderer.bounds))
            {
                attackOn = true;
                updateSprite();
                Destroy(_tokens[1]);
            }
        }
    }

    void updateSprite()
    {
        if(earthOn && attackOn)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if (earthOn)
        {
            spriteRenderer.sprite = sprites[2];
        }
        else if (attackOn)
        {
            spriteRenderer.sprite = sprites[3];
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
        }
    }
}
