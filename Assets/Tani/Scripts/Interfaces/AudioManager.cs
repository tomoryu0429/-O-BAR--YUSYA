using Cysharp.Threading.Tasks;
using R3.Triggers;
using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class AudioManager : SingletonMonoBehavior<AudioManager>
{
    [SerializeField] private AudioSource m_AudioSource;

    public void PlaySe(AudioClip clip)
    {
        m_AudioSource.PlayOneShot(clip);
    }

    public void SetVolume(float volume)
    {
        m_AudioSource.volume = volume;
    }
}

public class BoxManager : MonoBehaviour
{
    [SerializeField] GameObject BoxPrefab;
    [SerializeField]  AudioClip m_Clip;

    private void Start()
    {
        InstBox().Forget();
    }

    private async UniTaskVoid InstBox()
    {
        while (true)
        {
            GameObject box = Instantiate(BoxPrefab);

            box.OnDestroyAsObservable()
                .Subscribe(_ => AudioManager.Instance.PlaySe(m_Clip))
                .AddTo(box);

            await UniTask.Delay(1000);
        }
    }
}

public class SliderManager : MonoBehaviour
{
    [SerializeField]Slider slider;

    private void Start()
    {
        slider.OnValueChangedAsObservable()
            .Subscribe(vol=>AudioManager.Instance.SetVolume(vol))
            .AddTo(slider);
    }
}
