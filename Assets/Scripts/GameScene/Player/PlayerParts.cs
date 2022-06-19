[System.Serializable]
public class PlayerParts
{
    public CorePart Core = CorePart.CORE_01;
    public string CoreSprite = "";
    public EnginePart Engine = EnginePart.BU_01;
    public string EngineSprite = "";
    public BodyPart Body = BodyPart.CS_01;
    public string BodySprite = "";
    public WeaponPart Weapon = WeaponPart.G_01;
    public string WeaponSprite = "";
    public SpecialWeaponPart SpecialWeapon = SpecialWeaponPart.CU_03;
    public string SpecialWeaponSprite = "";

    public bool[] CORE = new bool[3];
    public bool[] ENGINE = new bool[3];
    public bool[] BODY = new bool[3];
    public bool[] WEAPON = new bool[3];
    public bool[] SWEAPON = new bool[3];
}
