using System;

namespace P_ARM_AssemblyParser.Parameters
{
    [Flags]
    public enum Conditions
    {
        // Egalité
		EQ = 0,
        // Différence
        NE = 1,
        // Retenue
        CS = 2,
        // Pas de retenue
        CC = 3,
        // Négatif
        MI = 4,
        // Positif ou nul
        PL = 5,
        // Dépassement de capacité
        VS = 6,
        // Pas de dépassement de capacité
        VC = 7,
        // Supérieur (non signé)
        HI = 8,
        // Inférieur ou égal (non signé)
        LS = 9,
        // Supérieur ou égal (signé)
        GE = 10,
        // Inférieur (signé)
        LT = 11,
        // Supérieur (signé)
        GT = 12,
        // Inférieur ou égal
        LE = 13,
        // Valeur par défaut, toujours vrai
        AL = 14
    }
}
