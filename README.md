# EKA UI RPG

This project is a simple RPG game built using Unity with an emphasis on Object-Oriented Programming (OOP) principles. The game includes features such as spells, weapons, player and enemy interactions, and a simple turn-based combat system.

## OOP Principles Used in the Project

### 1. **Inheritance**
- **Weapon Class**: Acts as a base class for all weapon types, providing functionality for damage and special effects.
- **Spell Class**: The base class for all spells, allowing for different spell effects such as healing or damage buffs to be implemented by subclasses.
- 
### 2. **Polymorphism**
Polymorphism is utilized through method overriding, specifically with the ApplyEffect method in the Spell class.
This allows spells like HealSpell and DamageBuffSpell to be applied in different ways based on the specific spell type.

### 3. **Encapsulation**
Private fields such as minDamage, maxDamage, and isShieldBroken are used in classes like Weapon and Player.

### 3. **Abstraction**
Abstraction is applied in the Spell class, where the ApplyEffect method is abstract. (duh)
This means each spell (HealSpell or DamageBuffSpell) defines its own implementation of how the effect is applied, while the base Spell class provides a common interface for all spells in case i add more spells before submitting.
