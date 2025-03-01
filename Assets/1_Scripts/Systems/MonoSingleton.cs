using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<TSingleton> : MonoBehaviour where TSingleton : MonoSingleton<TSingleton>
{
	public static TSingleton Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this as TSingleton;
		OnAwakeRoutine();
	}

	private void OnDestroy()
	{
		if (Instance != this as TSingleton)
		{
			return;
		}

		OnDestroyRoutine();
		Instance = null;
	}

	protected virtual void OnAwakeRoutine() { }
	protected virtual void OnDestroyRoutine() { }
}