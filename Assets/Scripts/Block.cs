using System;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private TextMeshPro text;
    private int hitsRemaining = 5;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        UpdateVisualState();
    }

    private void UpdateVisualState()
    {
        text.SetText(hitsRemaining.ToString());
        spriteRenderer.color = Color.Lerp(Color.white, Color.red, hitsRemaining / 10f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitsRemaining--;
        if (hitsRemaining > 0)
        {
            UpdateVisualState(); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    internal void SetHits(int hits)
    {
        hitsRemaining = hits;
        UpdateVisualState();
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Touchline")
        {
            Debug.Log("You Touch line :c");
            GameManager.Instance.GameOver();
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Touchline")
        {
            Debug.Log("You Touch line :c");
            GameManager.Instance.GameOver();
        }
    }
}


