using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject Chin;

    protected override void Start()
    {
        base.Start();

        hp = 150;
        attackPower = 15;
    }

    protected override void Update()
    {

    }

    protected override void FixedUpdate()
    {

    }

    public override void TakeDamage(float damage)
    {
        hp = hp - damage;

        if (hp <= 0)
        {
            Destroy(this.gameObject);

        }
        else
        {
            this.GetComponentInChildren<SpriteRenderer>().color = Color.clear;
            Chin.GetComponent<SpriteRenderer>().color = Color.clear;
            StartCoroutine(FadeToOriginalColor());
        }

    }


    protected override IEnumerator FadeToOriginalColor()
    {
        Color originalColor = Color.white;
        Color startColor = spriteRenderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            this.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, originalColor, elapsedTime / fadeDuration);
            Chin.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, originalColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = originalColor;
    }


}
