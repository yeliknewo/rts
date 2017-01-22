using System.Collections.Generic;

public class Stat
{
	private Dictionary<Attributes, float> _multipliers = new Dictionary<Attributes, float> ();
	private Dictionary<Attributes, float> mults {
		get {
			return _multipliers;
		}
	}

	private float baseLevel;

	public Stat (float newBaseLevel, float strengthMult, float agilityMult, float intelligenceMult)
	{
		this.baseLevel = newBaseLevel;
		this.mults.Add (Attributes.Strength, strengthMult);
		this.mults.Add (Attributes.Agility, agilityMult);
		this.mults.Add (Attributes.Intelligence, intelligenceMult);
	}

	public float getCalculatedValue(float strength, float agility, float intelligence) {
		return this.baseLevel + strength * mults [Attributes.Strength] + agility * mults [Attributes.Agility] + intelligence * mults [Attributes.Intelligence];
	}
}

