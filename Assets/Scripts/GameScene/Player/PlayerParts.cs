[System.Serializable]
public class PlayerParts
{
    public CorePart Core;
    public string CoreSprite;
    public EnginePart Engine;
    public string EngineSprite;
    public BodyPart Body;
    public string BodySprite;
    public WeaponPart Weapon;
    public string WeaponSprite;
    public SpesialWeaponPart SpesialWeapon;
    public string SpesialWeaponSprite;
    public int Orin;
    public int Idirium;
    public int Tumtain;

    public bool[] CORE;
    public bool[] ENGINE;
    public bool[] BODY;
    public bool[] WEAPON;
    public bool[] SWEAPON;
}
