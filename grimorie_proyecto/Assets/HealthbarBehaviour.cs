using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehaviour : MonoBehaviour {

	public EnemyController enemyController;
	public Slider Slider;
	public Image fillImage;

	void Awake()
	{
		// Slider = GetComponent<Slider>();
	}

	// Update is called once per frame

	void Update () 
	{
		float fillValue = enemyController.currentHealth / enemyController.maxHealth;
		Slider.value = fillValue;
	}
}
