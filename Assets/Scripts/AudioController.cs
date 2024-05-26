using System;
using UnityEngine;

namespace Audio
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController Instance { get; private set; }
        
        public CurrentSound[] sounds;
        [SerializeField] private bool isOn;
        
        public void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            Initialize();
        }

        private void Start()
        {
            isOn = true;
            Play("Theme");
        }

        private void Initialize()
        {
            foreach (var s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        public void Play(string clipName)
        {
            CurrentSound s = Array.Find(sounds, sound => sound.name == clipName);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + clipName + " not found!");
                return;
            }
            s.source.Play();
        }
        
        public void OnOrOfSounds()
            {
                if (!isOn)
                {
                    AudioListener.volume = 1f;
                    isOn = true;
                }
                
                else if(isOn)
                {
                    AudioListener.volume = 0f;
                    isOn = false;
                }
            }
    
    }
}
