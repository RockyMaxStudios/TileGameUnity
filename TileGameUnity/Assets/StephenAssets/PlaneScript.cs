using UnityEngine;
using System.Collections;

public class PlaneScript : MonoBehaviour 
{
    bool playingClickOnAnimation = false;
    float clickOnAnimationTimer = 0;
    float timeToPlayClickOnAnimation = 0.2f;
    float maxScaleMultiplierClickOn = 1.1f;
    Color colourToInterpolateToClickOn = new Color(0.5f, 0, 0.5f);

    bool playingClickOffAnimation = false;
    float clickOffAnimationTimer = 0;
    float timeToPlayClickOffAnimation = 2;

    bool playingSequenceAnimation = false;
    float sequenceAnimationTimer = 0;
    float timeToPlaySequenceAnimation = 2;

    float initialScaleX;
    float initialScaleZ;
    Quaternion initialRotation;
    Color initialColour;

    Renderer renderer;

    void Start()
    {
        initialScaleX = transform.localScale.x;
        initialScaleZ = transform.localScale.z;
        initialRotation = transform.rotation;
        initialColour = GetComponent<Renderer>().material.color;
        renderer = GetComponent<Renderer>();
    }

	void Update ()
    {
        UpdateClickOnAnimation();
	}

    void UpdateClickOnAnimation()
    {
        if (!playingClickOnAnimation)
            return;

        if (clickOnAnimationTimer >= timeToPlayClickOnAnimation)
        {
            Reset();
            return;
        }

        clickOnAnimationTimer += Time.smoothDeltaTime;

        float currentScaleX;
        float currentScaleZ;
        float currentColourR;
        float currentColourG;
        float currentColourB;

        if (clickOnAnimationTimer < timeToPlayClickOnAnimation/2)
        {
            currentScaleX = Mathf.Lerp(initialScaleX, initialScaleX * maxScaleMultiplierClickOn, clickOnAnimationTimer / (timeToPlayClickOnAnimation / 2));
            currentScaleZ = Mathf.Lerp(initialScaleZ, initialScaleZ * maxScaleMultiplierClickOn, clickOnAnimationTimer / (timeToPlayClickOnAnimation / 2));

            currentColourR = Mathf.Lerp(initialColour.r, colourToInterpolateToClickOn.r, clickOnAnimationTimer / (timeToPlayClickOnAnimation / 2));
            currentColourG = Mathf.Lerp(initialColour.g, colourToInterpolateToClickOn.g, clickOnAnimationTimer / (timeToPlayClickOnAnimation / 2));
            currentColourB = Mathf.Lerp(initialColour.b, colourToInterpolateToClickOn.b, clickOnAnimationTimer / (timeToPlayClickOnAnimation / 2));
        }
        else
        {
            currentScaleX = Mathf.Lerp(initialScaleX * maxScaleMultiplierClickOn, initialScaleX, (clickOnAnimationTimer - (timeToPlayClickOnAnimation / 2)) / (timeToPlayClickOnAnimation / 2));
            currentScaleZ = Mathf.Lerp(initialScaleZ * maxScaleMultiplierClickOn, initialScaleZ, (clickOnAnimationTimer - (timeToPlayClickOnAnimation / 2)) / (timeToPlayClickOnAnimation / 2));

            currentColourR = Mathf.Lerp(colourToInterpolateToClickOn.r, initialColour.r, (clickOnAnimationTimer - (timeToPlayClickOnAnimation / 2)) / (timeToPlayClickOnAnimation / 2));
            currentColourG = Mathf.Lerp(colourToInterpolateToClickOn.g, initialColour.g, (clickOnAnimationTimer - (timeToPlayClickOnAnimation / 2)) / (timeToPlayClickOnAnimation / 2));
            currentColourB = Mathf.Lerp(colourToInterpolateToClickOn.b, initialColour.b, (clickOnAnimationTimer - (timeToPlayClickOnAnimation / 2)) / (timeToPlayClickOnAnimation / 2));
        }

        transform.localScale = new Vector3(currentScaleX, transform.localScale.y, currentScaleZ);
        renderer.material.color = new Color(currentColourR, currentColourG, currentColourB);
    }

    void Reset()
    {
        clickOnAnimationTimer = 0;
        playingClickOnAnimation = false;
        clickOffAnimationTimer = 0;
        playingClickOffAnimation = false;
        transform.localScale = new Vector3(initialScaleX, transform.localScale.y, initialScaleZ);
        transform.rotation = initialRotation;
        renderer.material.color = initialColour;
    }

    void PlaySequenceAnimation()
    {
        playingSequenceAnimation = true;
    }

    public void Click()
    {
        if (!playingClickOnAnimation)
        {
            Reset();
            playingClickOnAnimation = true;
        }
        else
        {
            Reset();
            playingClickOffAnimation = true;
        }
    }
}

