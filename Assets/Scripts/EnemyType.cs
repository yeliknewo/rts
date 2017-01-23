using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
	public EnemyTypes enemyType;
}

public enum EnemyTypes
{
	Chaser,
	Peasant,
	Base,
}