using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : SingletonBehavior<SoundsManager>
{
    [SerializeField]
    private AudioSource _audioSource;
}
