using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderManager : SingletonBehavior<ThunderManager>
{
    [Header("Audio")]
    [SerializeField]
    private AudioSource _thunderAudioSource;

    [SerializeField]
    private List<AudioClip> _thunderAudioClips;

    [Space(20)]

    [Header("Light")]
    [SerializeField]
    private Light _thunderLight;

    private bool playingThunder = false;
    private AudioClip clipToPlay;

    public void PlayThunder()
    {
        if (playingThunder) return;

        playingThunder = true;
        StartCoroutine(HandleThunder());
    }

    private WaitForSecondsRealtime waitForSecondsShort = new WaitForSecondsRealtime(0.05f);
    private WaitForSecondsRealtime waitForSecondsLong = new WaitForSecondsRealtime(3f);
    private IEnumerator HandleThunder()
	{
        clipToPlay = _thunderAudioClips[UtilsManager.Instance.GetRandomIntBetween(0, _thunderAudioClips.Count - 1)];

		_thunderLight.enabled = true;
		yield return waitForSecondsShort;
		yield return waitForSecondsShort;
		yield return waitForSecondsShort;
		_thunderLight.enabled = false;
		yield return waitForSecondsShort;
		_thunderLight.enabled = true;
		yield return waitForSecondsShort;
		_thunderLight.enabled = false;
		yield return waitForSecondsShort;
		_thunderLight.enabled = true;
		yield return waitForSecondsShort;
		_thunderLight.enabled = false;

        yield return waitForSecondsLong;

		_thunderAudioSource.PlayOneShot(clipToPlay);

		playingThunder = false;
    }
}
