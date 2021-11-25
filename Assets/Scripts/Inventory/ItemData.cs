using UnityEngine;

public static class ItemData
{
   public static Item CreateItem(int itemID)
    {
         string name;
         string description;
         int amount;
         int _value;
         int stat;
         string icon;
         string mesh;
         ItemType type;
         string rarity;
        switch (itemID)
        {
            #region Armour 0-99
            case 0:
                name = "Plain Boots";
                description = "A plain old boot. Probably seen a lot of use.";
                amount = 1;
                _value = 20;
                stat = 1;
                icon = "Armour/BootsPlain";
                mesh = "Armour/BootsPlain";
                type = ItemType.Armour;
                rarity = "Common";
                break;
            case 1:
                name = "Plain Bracers";
                description = "A pair of used old bracers. They're in surprisingly good shape.";
                amount = 1;
                _value = 20;
                stat = 1;
                icon = "Armour/BracerOld";
                mesh = "Armour/BracerOld";
                type = ItemType.Armour;
                rarity = "Common";
                break;
            case 2:
                name = "Tunic";
                description = "A simple tunic. A little leather offers a small amount of protection.";
                amount = 1;
                _value = 30;
                stat = 3;
                icon = "Armour/ChestPlateCloth";
                mesh = "Armour/ChestPlateCloth";
                type = ItemType.Armour;
                rarity = "Common";
                break;
            case 3:
                name = "Plain Gloves";
                description = "A pair of well-used gloves. They seem to be made of a light leather.";
                amount = 1;
                _value = 15;
                stat = 1;
                icon = "Armour/GlovesPlain";
                mesh = "Armour/GlovesPlain";
                type = ItemType.Armour;
                rarity = "Common";
                break;
            case 4:
                name = "Old Leather Helm";
                description = "This thing has seen better days. Still, best to protect your head.";
                amount = 1;
                _value = 20;
                stat = 2;
                icon = "Armour/HelmOld";
                mesh = "Armour/HelmOld";
                type = ItemType.Armour;
                rarity = "Common";
                break;
            case 5:
                name = "Old Pants";
                description = "These things look ready to fall apart, if it weren't for the patches holding them together.";
                amount = 1;
                _value = 20;
                stat = 1;
                icon = "Armour/PantsOld";
                mesh = "Armour/PantsOld";
                type = ItemType.Armour;
                rarity = "Common";
                break;
            case 6:
                name = "Wooden Shield";
                description = "Crudely made, but it'll do just fine to block a few blows.";
                amount = 1;
                _value = 40;
                stat = 4;
                icon = "Armour/ShieldWood";
                mesh = "Armour/ShieldWood";
                type = ItemType.Armour;
                rarity = "Common";
                break;
            case 7:
                name = "Leather Pauldrons";
                description = "Probably used to belong to a squire.";
                amount = 1;
                _value = 20;
                stat = 1;
                icon = "Armour/ShouldersLeather";
                mesh = "Armour/ShouldersLeather";
                type = ItemType.Armour;
                rarity = "Common";
                break;
            case 8:
                name = "Boots of the Protector";
                description = "Scaled and plated, these sturdy boots make you feel grounded.";
                amount = 1;
                _value = 200;
                stat = 5;
                icon = "Armour/BootsProtector";
                mesh = "Armour/BootsProtector";
                type = ItemType.Armour;
                rarity = "Rare";
                break;
            case 9:
                name = "Bracers of the Protector";
                description = "Tough metal wrapped over with a thick blue fabric of unknown origin";
                amount = 1;
                _value = 140;
                stat = 3;
                icon = "Armour/BracerProtector";
                mesh = "Armour/BracerProtector";
                type = ItemType.Armour;
                rarity = "Rare";
                break;
            case 10:
                name = "Protector's Chestpiece";
                description = "Blue platemail. The metal is unknown; maybe mithril?";
                amount = 1;
                _value = 400;
                stat = 10;
                icon = "Armour/ChestPlateDefender";
                mesh = "Armour/ChestPlateDefender";
                type = ItemType.Armour;
                rarity = "Rare";
                break;
            case 11:
                name = "Gloves of the Protector";
                description = "Plated gloves, with digits protected with thick metal. They're surprisingly mobile.";
                amount = 1;
                _value = 140;
                stat = 2;
                icon = "Armour/GlovesProtector";
                mesh = "Armour/GlovesProtector";
                type = ItemType.Armour;
                rarity = "Rare";
                break;
            case 12:
                name = "Helmet of the Protector";
                description = "The spikes on the front give this helmet an intimidating look.";
                amount = 1;
                _value = 250;
                stat = 5;
                icon = "Armour/HelmProtector";
                mesh = "Armour/HelmProtector";
                type = ItemType.Armour;
                rarity = "Rare";
                break;
            case 13:
                name = "Pants of the Protector";
                description = "The soft blue fabric is plated with the same stuff as the chestpiece.";
                amount = 1;
                _value = 300;
                stat = 7;
                icon = "Armour/PantsProtector";
                mesh = "Armour/PantsProtector";
                type = ItemType.Armour;
                rarity = "Rare";
                break;
            case 14:
                name = "Protector's Shield";
                description = "This blue-plated metal can deflect even magic to keep the wearer safe.";
                amount = 1;
                _value = 400;
                stat = 9;
                icon = "Armour/ShieldProtector";
                mesh = "Armour/ShieldProtector";
                type = ItemType.Armour;
                rarity = "Rare";
                break;
            case 15:
                name = "Pauldrons of the Protector";
                description = "Scaled yet flexible, these tough shoulderpads can take many blows.";
                amount = 1;
                _value = 180;
                stat = 2;
                icon = "Armour/ShouldersProtector";
                mesh = "Armour/ShouldersProtector";
                type = ItemType.Armour;
                rarity = "Rare";
                break;
            #endregion
            #region Trinket 100-199
            case 100:
                name = "Old Belt";
                description = "The leather is old and worn.";
                amount = 1;
                _value = 10;
                stat = 1;
                icon = "Trinket/BeltOld";
                mesh = "Trinket/BeltOld";
                type = ItemType.Trinket;
                rarity = "Common";
                break;
            case 101:
                name = "Plain Cloak";
                description = "A staple for keeping warm. The furred collar makes for a comfortable wear in the cold.";
                amount = 1;
                _value = 40;
                stat = 2;
                icon = "Trinket/CloakPlain";
                mesh = "Trinket/CloakPlain";
                type = ItemType.Trinket;
                rarity = "Common";
                break;
            case 102:
                name = "Belt of the Protector";
                description = "The studded belt is held closed by a runestone.";
                amount = 1;
                _value = 150;
                stat = 2;
                icon = "Trinket/BeltProtector";
                mesh = "Trinket/BeltProtector";
                type = ItemType.Trinket;
                rarity = "Rare";
                break;
            case 103:
                name = "Cloak of the Protector";
                description = "This light cape won't do you much good against the cold, but it's surprisingly resistant.";
                amount = 1;
                _value = 210;
                stat = 4;
                icon = "Trinket/CloakDefender";
                mesh = "Trinket/CloakDefender";
                type = ItemType.Trinket;
                rarity = "Rare";
                break;
            #endregion
            #region Weapon 200-299
            case 200:
                name = "Makeshift Club";
                description = "You don't know who made this, but at least the spiked end will hurt.";
                amount = 1;
                _value = 25;
                stat = 5;
                icon = "Weapon/ClubMakeshift";
                mesh = "Weapon/ClubMakeshift";
                type = ItemType.Weapon;
                rarity = "Common";
                break;
            case 201:
                name = "Old Axe";
                description = "Looks like it was designed for more than just cutting wood. Unfortunately, it's fairly old.";
                amount = 1;
                _value = 20;
                stat = 4;
                icon = "Weapon/AxeOld";
                mesh = "Weapon/AxeOld";
                type = ItemType.Weapon;
                rarity = "Common";
                break;
            case 202:
                name = "Plain Sword";
                description = "A fine weapon. The grip is still intact, and it's well-weighted. A good piece of equipment, worth the price.";
                amount = 1;
                _value = 60;
                stat = 8;
                icon = "Weapon/SwordPlain";
                mesh = "Weapon/SwordPlain";
                type = ItemType.Weapon;
                rarity = "Uncommon";
                break;
            case 203:
                name = "Protector's Blade";
                description = "It has far more heft behind it than a regular sword, but still light enough to wield with a shield.";
                amount = 1;
                _value = 260;
                stat = 14;
                icon = "Weapon/SwordProtector";
                mesh = "Weapon/SwordProtector";
                type = ItemType.Weapon;
                rarity = "Rare";
                break;
            case 204:
                name = "Old Bow";
                description = "The wood looks ready to gnarl, but a layer of polish prevents it.";
                amount = 1;
                _value = 40;
                stat = 6;
                icon = "Weapon/BowOld";
                mesh = "Weapon/BowOld";
                type = ItemType.Weapon;
                rarity = "Common";
                break;
            #endregion
            #region Scroll 300-399
            case 300:
                name = "Nature Tome";
                description = "The pages smell like freshly fallen leaves. This probably used to belong to an elf.";
                amount = 1;
                _value = 100;
                stat = 20;
                icon = "Scroll/BookGreen";
                mesh = "Scroll/BookGreen";
                type = ItemType.Scroll;
                rarity = "Rare";
                break;
            #endregion
            #region Potion 400-499
            case 400:
                name = "Health Potion";
                description = "A swig of this familiar red liquid will help heal your wounds.";
                amount = 1;
                _value = 50;
                stat = 40;
                icon = "Potion/hp";
                mesh = "Potion/hp";
                type = ItemType.Potion;
                rarity = "Uncommon";
                break;
            #endregion
            #region Food 500-599
            case 500:
                name = "Apple";
                description = "Sweet and healthy!";
                amount = 1;
                _value = 5;
                stat = 4;
                icon = "Food/apple";
                mesh = "Food/apple";
                type = ItemType.Food;
                rarity = "Common";
                break;
            #endregion
            #region Ingredient 600-699
            case 600:
                name = "Raw Meat";
                description = "Needs to be cooked before you can eat it.";
                amount = 1;
                _value = 10;
                stat = 0;
                icon = "Ingredient/Meat";
                mesh = "Ingredient/Meat";
                type = ItemType.Ingredient;
                rarity = "Common";
                break;
            #endregion
            #region Material 700-799
            case 700:
                name = "Iron Ingot";
                description = "A hefty slab of metal. Can be forged with enough skill, or sold.";
                amount = 1;
                _value = 35;
                stat = 0;
                icon = "Material/ingots";
                mesh = "Material/ingots";
                type = ItemType.Material;
                rarity = "Common";
                break;
            case 701:
                name = "Gem";
                description = "A blue gem, but it isn't sapphire.";
                amount = 1;
                _value = 500;
                stat = 0;
                icon = "Material/gem";
                mesh = "Material/gem";
                type = ItemType.Material;
                rarity = "Rare";
                break;
            #endregion
            #region Misc 800-899
            case 800:
                name = "Sharpened Arrows";
                description = "The heads of these arrows have been sharpened extra. These will definitely hurt.";
                amount = 1;
                _value = 20;
                stat = 5;
                icon = "Misc/ArrowSharpened";
                mesh = "Misc/ArrowSharpened";
                type = ItemType.Misc;
                rarity = "Common";
                break;
            case 801:
                name = "Deadly Arrows";
                description = "With a firm wood shaft, sharp steel tip, and proper feather fletching; these arrows are valuable.";
                amount = 1;
                _value = 60;
                stat = 9;
                icon = "Misc/ArrowDeadly";
                mesh = "Misc/ArrowDeadly";
                type = ItemType.Misc;
                rarity = "Uncommon";
                break;
            case 802:
                name = "Royal Arrows";
                description = "Carried by royal guards, these high quality arrows don't come cheap- for a good reason.";
                amount = 1;
                _value = 150;
                stat = 15;
                icon = "Misc/ArrowRoyal";
                mesh = "Misc/ArrowRoyal";
                type = ItemType.Misc;
                rarity = "Rare";
                break;
            case 803:
                name = "Elven Arrows";
                description = "The fletching is made of leaves, and the tips of stone. However, they still somehow hurt far more than a human's arrow.";
                amount = 1;
                _value = 175;
                stat = 18;
                icon = "Misc/ArrowElvish";
                mesh = "Misc/ArrowElvish";
                type = ItemType.Misc;
                rarity = "Rare";
                break;
            case 804:
                name = "Gold";
                description = "Mmm, gold.";
                amount = 1;
                _value = 1;
                stat = 0;
                icon = "Misc/coins";
                mesh = "Misc/coins";
                type = ItemType.Money;
                rarity = "Common";
                break;
            #endregion
            default:
                name = "Apple";
                description = "Sweet and healthy!";
                amount = 1;
                _value = 5;
                stat = 4;
                icon = "Food/apple";
                mesh = "Food/apple";
                type = ItemType.Food;
                rarity = "Common";
                break;
        }
        Item temp = new Item
        {
            ID = itemID,
            Name = name,
            Description = description,
            Amount = amount,
            Value = _value,
            Stat = stat,
            IconName = Resources.Load("Icon/" + icon) as Texture2D,
            MeshName = Resources.Load("Mesh/" + mesh) as GameObject,
            ItemType = type,
            Rarity = rarity

        };
        return temp;
    }
}
