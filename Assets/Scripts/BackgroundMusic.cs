using System;
using UnityEngine;
using VNCreator;

namespace Assets.Scripts
{
    public class BackgroundMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource source;

        private void Start()
        {
            BackgroundMusic[] bms = FindObjectsOfType<BackgroundMusic>();
            if (bms.Length > 1)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
            source.volume = PlayerData.MusicVolume;
            GameOptions.OnMusicVolumeChanged += volume => source.volume = volume;
        }

        public void DisableMusic()
        {
            source.Stop();
        }
    }
}