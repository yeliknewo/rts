using System.Collections.Generic;

public class Stat
{
	private Dictionary<Attributes, float> _multipliers = new Dictionary<Attributes, float>();
	private Dictionary<Attributes, float> mults
	{
		get
		{
			return _multipliers;
		}
	}

	private float baseLevel;

	public Stat(float newBaseLevel, float strengthMult, float agilityMult, float intelligenceMult)
	{
		baseLevel = newBaseLevel;
		mults.Add(Attributes.Strength, strengthMult);
		mults.Add(Attributes.Agility, agilityMult);
		mults.Add(Attributes.Intelligence, intelligenceMult);
	}

	public float getCalculatedValue(Dictionary<Attributes, float> attributes)
	{
		return baseLevel + getStatPart(attributes, Attributes.Strength) + getStatPart(attributes, Attributes.Agility) + getStatPart(attributes, Attributes.Intelligence);
	}

	private float getStatPart(Dictionary<Attributes, float> attributes, Attributes attribute)
	{
		return attributes[attribute] * mults[attribute];
	}
}

