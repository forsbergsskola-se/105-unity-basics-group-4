using UnityEngine;

public interface ITakeDamage
{
    //simple interface - implement to things that should be able to take damage.
    //takedamage accepts value of damage to deal to target as a simple int value.
    void takedamage(int damagedealt);
}
