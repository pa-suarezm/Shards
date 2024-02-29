using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderManager : SingletonBehavior<ThunderManager>
{
    [Header("Audio")]
    [SerializeField]
    private AudioSource _thunderAudioSource;

    [SerializeField]
    private AudioClip _thunderAudioClip;

    [Space(20)]

    [Header("Light")]
    [SerializeField]
    private Light _thunderLight;

    private bool playingThunder = false;

    public void PlayThunder()
    {
        if (playingThunder) return;

        playingThunder = true;
        StartCoroutine(HandleThunder());
    }

    private WaitForSecondsRealtime waitForSeconds = new WaitForSecondsRealtime(0.05f);
    private IEnumerator HandleThunder()
	{
		_thunderLight.enabled = true;
		yield return waitForSeconds;
		yield return waitForSeconds;
		_thunderLight.enabled = false;
		yield return waitForSeconds;
		_thunderLight.enabled = true;
		yield return waitForSeconds;
		_thunderLight.enabled = false;
		yield return waitForSeconds;
		_thunderLight.enabled = true;
		yield return waitForSeconds;
		_thunderLight.enabled = false;
        yield return waitForSeconds;

		playingThunder = false;
    }
}
