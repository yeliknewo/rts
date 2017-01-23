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

	public float GetCalculatedValue(Dictionary<Attributes, float> attributes)
	{
		return baseLevel + GetStatPart(attributes, Attributes.Strength) + GetStatPart(attributes, Attributes.Agility) + GetStatPart(attributes, Attributes.Intelligence);
	}

	private float GetStatPart(Dictionary<Attributes, float> attributes, Attributes attribute)
	{
		return attributes[attribute] * mults[attribute];
	}
}

