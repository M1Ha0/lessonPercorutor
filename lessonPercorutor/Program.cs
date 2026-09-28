using System;

interface IWeapon
{
    string GetName();
    int GetDamage();
}

class Sword : IWeapon
{
    public string GetName()
    {
        return "Меч";
    }

    public int GetDamage()
    {
        return 50;
    }
}
class Bow : IWeapon
{
    public string GetName()
    {
        return "Лук";
    }

    public int GetDamage()
    {
        return 40;
    }
}
class Staff : IWeapon
{
    public string GetName()
    {
        return "Посох";
    }

    public int GetDamage()
    {
        return 35;
    }
}

class WeaponDecorator : IWeapon
{
    protected IWeapon weapon;

    public WeaponDecorator(IWeapon weapon)
    {
        this.weapon = weapon;
    }

    public virtual string GetName()
    {
        return weapon.GetName();
    }

    public virtual int GetDamage()
    {
        return weapon.GetDamage();
    }
}

class FireDecorator : WeaponDecorator
{
    public FireDecorator(IWeapon weapon)
        : base(weapon)
    {

    }
    public override string GetName()
    {
        return weapon.GetName() + " с огнем";
    }

    public override int GetDamage()
    {
        return weapon.GetDamage() + 20;
    }
}
class PoisonDecorator : WeaponDecorator
{
    public PoisonDecorator(IWeapon weapon)
        : base(weapon)
    {

    }
    public override string GetName()
    {
        return weapon.GetName() + " с ядом";
    }

    public override int GetDamage()
    {
        return weapon.GetDamage() + 10;
    }
}

class CriticalDecorator : WeaponDecorator
{
    public CriticalDecorator(IWeapon weapon)
        : base(weapon)
    {

    }
    public override string GetName()
    {
        return weapon.GetName() + " с критическим уроном";
    }

    public override int GetDamage()
    {
        return weapon.GetDamage() * 2;
    }
}

class Program
{
    static void Main()
    {
        IWeapon weaponS = new Sword();
        IWeapon weaponB = new Bow();
        IWeapon weaponSt = new Staff();

        weaponS = new FireDecorator(weaponS);
        weaponS = new CriticalDecorator(weaponS);

        weaponB = new PoisonDecorator(weaponB);
        weaponB = new FireDecorator(weaponB);

        weaponSt = new CriticalDecorator(weaponSt);
        weaponSt = new PoisonDecorator(weaponSt);

        Console.WriteLine(weaponS.GetName());
        Console.WriteLine("Урон - " + weaponS.GetDamage());
        Console.WriteLine(weaponB.GetName());
        Console.WriteLine("Урон - " + weaponB.GetDamage());
        Console.WriteLine(weaponSt.GetName());
        Console.WriteLine("Урон - " + weaponSt.GetDamage());
    }
}