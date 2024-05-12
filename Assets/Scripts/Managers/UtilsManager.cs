using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilsManager : SingletonBehavior<UtilsManager>
{
	private void Start()
	{
		Random.InitState(System.DateTime.Now.Millisecond);
	}

	public int GetRandomIntBetween(int min, int max)
	{
		float minF = min - 0.499f;
		float maxF = max + 0.499f;

		return Mathf.RoundToInt(Random.Range(minF, maxF));
	}
}
