using System;
using UnityEngine;

public class FlameBehaivour : MonoBehaviour
{
	private const float DELTA_TIME_COEFF = 1e-6f; // для замедления анимации

	private const float SCALE_POSITION_PROPORTION_COEFF = 5.0f; // пропорция между размерами и позицией горящей поверхности

	private const float STEFAN_BOLTCMAN_COEFF = 5.67f * 1e-8f;

	[SerializeField] public float flameDeepVelocity = 1.0f;
	[SerializeField] public float flameTemprature = 573.0f;

	[SerializeField] public float oilTemprature = 297.0f;
	[SerializeField] public float oilBlacknessCoeff = 0.8f;
	[SerializeField] public float oilDensity = 800.0f;
	[SerializeField] public float oilBurningVelocityCoeff = 0.1f;

	private GameObject _barrier;
	// Start is called before the first frame update
	void Start()
	{
		_barrier = GameObject.Find("Barrier");
	}

	// Update is called once per frame
	void Update()
	{
		if (_barrier.transform.position.y < 2.6f &&
			Math.Abs(transform.position.z + transform.localScale.z / 2.0f - _barrier.transform.position.z) < 0.55f)
		{
			return;
		}

		if (-transform.localScale.z < 0.6f)
		{
			var flameFrontLineVelocity =
				(oilBlacknessCoeff * STEFAN_BOLTCMAN_COEFF * (Mathf.Pow(flameTemprature, 4.0f) - Mathf.Pow(oilTemprature, 4.0f))
				- oilBurningVelocityCoeff * oilDensity * flameDeepVelocity)
				/ (oilBurningVelocityCoeff * (flameTemprature - oilTemprature));

			var scaleChanges = new Vector3(0.0f, 0.0f, -flameFrontLineVelocity * DELTA_TIME_COEFF);
			var positionChanges = new Vector3(0.0f, 0.0f, flameFrontLineVelocity * DELTA_TIME_COEFF * SCALE_POSITION_PROPORTION_COEFF);

			transform.localScale += scaleChanges;
			transform.localPosition += positionChanges;
		}
	}
}
