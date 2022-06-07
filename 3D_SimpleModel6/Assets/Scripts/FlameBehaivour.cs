using System;
using UnityEngine;

public class FlameBehaivour : MonoBehaviour
{
    private const float DELTA_TIME_COEFF = 1e-3f; // для замедления анимации
    private const float SCALE_POSITION_PROPORTION_COEFF = 5.0f; // пропорция между размерами и позицией горящей поверхности
    [SerializeField] public float flameFrontLineVelocity = 1.0f;
    private Vector3 _scaleChanges;
    private Vector3 _positionChanges;
    private GameObject _barrier;
    // Start is called before the first frame update
    void Start()
    {
        _scaleChanges = new Vector3(0.0f, 0.0f, -flameFrontLineVelocity * DELTA_TIME_COEFF);
        _positionChanges = new Vector3(0.0f, 0.0f, flameFrontLineVelocity * DELTA_TIME_COEFF * SCALE_POSITION_PROPORTION_COEFF);
        _barrier = GameObject.Find("Barrier");
    }

    // Update is called once per frame
    void Update()
    {
        var tmp = Math.Abs(transform.position.z + transform.localScale.z / 2.0f - _barrier.transform.position.z);
        if (_barrier.transform.position.y < 2.6f && 
            Math.Abs(transform.position.z + transform.localScale.z / 2.0f - _barrier.transform.position.z) < 0.55f)
        {
            return;
        }
        
        if (-transform.localScale.z < 0.6f)
        {
            transform.localScale += _scaleChanges;
            transform.localPosition += _positionChanges;
        }
    }
}
