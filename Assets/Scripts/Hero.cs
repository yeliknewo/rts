using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
	private Dictionary<Attributes, float> attributes;

	private Stat _walkSpeed = new Stat (10f, 0.1f, 1f, 0.1f);
	private Stat _projectileSpeed = new Stat (1.5f, 1.0f, 0.1f, 0.1f);
	private Stat _range = new Stat (2.0f, 0.1f, 0.1f, 1.0f);

	protected Stat walkSpeed {
		get {
			return this._walkSpeed;
		}
	}

	protected Stat projectileSpeed {
		get {
			return this._projectileSpeed;
		}
	}

	protected Stat range {
		get {
			return this._range;
		}
	}

	void Start() {
		attributes = new Dictionary<Attributes, float> ();
		attributes.Add (Attributes.Strength, 0);
		attributes.Add (Attributes.Agility, 0);
		attributes.Add (Attributes.Intelligence, 0);
	}
}
