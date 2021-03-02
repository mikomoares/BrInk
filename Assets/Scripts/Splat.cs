﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splat : MonoBehaviour
{
    public float minSizeMod = 0.8f;
    public float maxSizeMod = 1.5f;

    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(){
        SetSprite();
        SetSize();
        SetRotation();
    }

    private void SetSprite(){
        int randomIndex = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[randomIndex];
    }

    private void SetSize(){
        float sizeMod = Random.Range(minSizeMod, maxSizeMod);
        transform.localScale *= sizeMod;
    }

    private void SetRotation(){
        float randomRotation = Random.Range(-360f,360f);
        transform.rotation = Quaternion.Euler(0f,0f, randomRotation);
    }
}
