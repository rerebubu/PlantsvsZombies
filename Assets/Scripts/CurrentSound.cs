using UnityEngine;

namespace Audio
{
    [System.Serializable]
    
    public class CurrentSound
    {
        public string name;
        
        public AudioClip clip;
        
        [Range(0f,1f)]
        public float volume;
        
        [Range(1f,3f)]
        public float pitch;

        public bool loop;

        [HideInInspector] 
        public AudioSource source;
    }
}
