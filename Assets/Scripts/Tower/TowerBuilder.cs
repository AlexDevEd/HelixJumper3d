using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _kernel;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private Platform[] _platform;
    [SerializeField] private FinishPlatform _finishPlatform;
   

    private float _startAndFinishAdditionalScale = 0.5f;
    private float _kernelScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale / 2f;
    private void Awake()
    {
        Build();
    }


    private void Update()
    {

    }

    private void Build()
    {
        GameObject kernel = Instantiate(_kernel, transform);
        kernel.transform.localScale = new Vector3(1, _kernelScaleY, 1);

        Vector3 spawnPosition = kernel.transform.position;
        spawnPosition.y += kernel.transform.localScale.y *2.2f - _additionalScale;

        SpawnPlatform( _startPlatform, ref spawnPosition, kernel.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platform[Random.Range(0, _platform.Length)], ref spawnPosition, kernel.transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, kernel.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform,spawnPosition, Quaternion.Euler(0,Random.Range(0,360),0), parent);
        spawnPosition.y -= 1;
            ;
    }
}
