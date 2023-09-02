using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public abstract class SingletonBehavior<T> : MonoBehaviour where T : SingletonBehavior<T>
{
	private static T instance;
	private static bool appQuit;

	private static int lastSearchFrameCount = -1; // otherwise instance will be null on frame 0.

	public static T Instance
	{
		get
		{
			if (instance != null)
			{
				return instance;
			}

			instance = InitInstance();

			return instance;
		}
	}

	protected static T InitInstance()
	{
		// Safe-guard from initializing singleton multiple times
		if (instance != null)
		{
			return instance;
		}

		if (lastSearchFrameCount != Time.frameCount)
		{
			// First time init
			instance = FindObjectOfType(typeof(T)) as T;
			if (instance == null)
			{
				if (appQuit == false)
				{
					Debug.LogWarning("Unable to find singleton. It has probably been destroyed already: " + typeof(T));
				}
			}
		}

		return instance;
	}

	protected virtual void Awake()
	{
		//Singleton instance can be initialized from either an awake call from unity, or from a .Instance call from other script
		if (instance == null)
		{
			InitInstance();
		}
	}

	protected virtual void OnDisabled()
	{
		instance = null;
	}

	protected virtual void OnDestroyed()
	{
		instance = null;
	}

	protected virtual void OnApplicationQuit()
	{
		appQuit = true;
	}
}
