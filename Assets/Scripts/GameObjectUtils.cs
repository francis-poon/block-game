using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectUtils
{
    public static IEnumerator FadeTo(SpriteRenderer renderer, Color fadeToColor, float duration)
    {
        float counter = 0f;
        //Get current color
        Color spriteColor = renderer.color;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float red = Mathf.Lerp(spriteColor.r, fadeToColor.r, counter / duration);
            float green = Mathf.Lerp(spriteColor.g, fadeToColor.g, counter / duration);
            float blue = Mathf.Lerp(spriteColor.b, fadeToColor.b, counter / duration);
            float alpha = Mathf.Lerp(spriteColor.a, fadeToColor.a, counter / duration);


            renderer.color = new Color(red, green, blue, alpha);
            //Wait for a frame
            yield return null;
        }
    }

    public static IEnumerator FadeFromTo(SpriteRenderer renderer, Color startColor, Color fadeToColor, float duration)
    {
        renderer.color = startColor;
        return FadeTo(renderer, fadeToColor, duration);
    }

    public static IEnumerator FadeIn(SpriteRenderer renderer, float duration)
    {
        Color spriteColor = renderer.color;
        return FadeFromTo(renderer, new Color(spriteColor.r, spriteColor.g, spriteColor.b, 0f), new Color(spriteColor.r, spriteColor.g, spriteColor.b, 1f), duration);
    }

    public static IEnumerator FadeOut(SpriteRenderer renderer, float duration)
    {
        Color spriteColor = renderer.color;
        return FadeFromTo(renderer, new Color(spriteColor.r, spriteColor.g, spriteColor.b, 1f), new Color(spriteColor.r, spriteColor.g, spriteColor.b, 0f), duration);
    }


    //===========================================================================================
    //===== FADE WITH START DELAY ===============================================================
    //===========================================================================================
    public static IEnumerator FadeTo(SpriteRenderer renderer, Color fadeToColor, float startDelay, float duration)
    {
        yield return new WaitForSeconds(startDelay);
        yield return FadeTo(renderer, fadeToColor, duration);
    }

    public static IEnumerator FadeFromTo(SpriteRenderer renderer, Color startColor, Color fadeToColor, float startDelay, float duration)
    {
        yield return new WaitForSeconds(startDelay);
        yield return FadeFromTo(renderer, startColor, fadeToColor, duration);
    }

    public static IEnumerator FadeIn(SpriteRenderer renderer, float startDelay, float duration)
    {
        yield return new WaitForSeconds(startDelay);
        yield return FadeIn(renderer, duration);
    }

    public static IEnumerator FadeOut(SpriteRenderer renderer, float startDelay, float duration)
    {
        yield return new WaitForSeconds(startDelay);
        yield return FadeOut(renderer, duration);
    }

}
