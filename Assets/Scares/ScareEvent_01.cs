using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareEvent_01 : ScareEvent
{
	public override void ScareStart()
	{
		base.ScareStart();

		ThunderManager.Instance.PlayThunder();

		OnScareEnd();
	}
}
