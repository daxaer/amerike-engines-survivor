using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioChannel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AudioSetting", menuName = "AudioManager/AudioSetting", order = 1)]

    public class AudioSettings : ScriptableObject
    {
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private AudioMixerGroup _output;

        [SerializeField] private bool _mute;
        [SerializeField] private bool _bypassEffects;
        [SerializeField] private bool _bypassListenerEffects;
        [SerializeField] private bool _bypassReverbEffects;
        [SerializeField] private bool _playOnAwake;
        [SerializeField] private bool _loop;

        [SerializeField, Range(0,256)] private int _priority = 128;
        [SerializeField, Range(0, 1)] private float _volumen = 1;
        [SerializeField, Range(-3, 3)] private float _pitch = 1;
        [SerializeField, Range(-1, 1)] private float _stereoPan = 0f;
        [SerializeField, Range(0, 1)] private float _spatialBlend = 0;
        [SerializeField, Range(0, 1.1f)] private float _reverbZone = 1;

        enum VolumeRoloff
        {
            LOGARITMIC_ROLLOFF,
            LINEAR,
            CUSTOM
        }

        [Serializable]
        public class SoundSettings3D
        {
            [SerializeField, Range(0, 5)] private float _dopplerlevel = 1;
            [SerializeField, Range(0,360)] private float _Spread = 0;
            [SerializeField] private VolumeRoloff _volumeRoloff = VolumeRoloff.LOGARITMIC_ROLLOFF;
            [SerializeField] private float _MinDistance = 1;
            [SerializeField] private float _MaxDistance = 500;
        }

        [SerializeField] private SoundSettings3D _3dSoundSettings;

        public AudioClip Audioclip { get; }
        public AudioMixer AudioMixer { get; }
        public bool Mute { get; }
        public bool BypassEffects { get; }
    }
}

