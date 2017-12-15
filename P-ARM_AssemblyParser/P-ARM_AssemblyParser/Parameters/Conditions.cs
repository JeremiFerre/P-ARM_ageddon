using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_ARM_AssemblyParser.Parameters
{
    [Flags]
    public enum Conditions
    {
        // Egalité
        EQ = 0b0000,
        // Différence
        NE = 0b0001,
        // Retenue
        CS = 0b0010,
        // Pas de retenue
        CC = 0b0011,
        // Négatif
        MI = 0b0100,
        // Positif ou nul
        PL = 0b0101,
        // Dépassement de capacité
        VS = 0b0110,
        // Pas de dépassement de capacité
        VC = 0b0111,
        // Supérieur (non signé)
        HI = 0b1000,
        // Inférieur ou égal (non signé)
        LS = 0b1001,
        // Supérieur ou égal (signé)
        GE = 0b1010,
        // Inférieur (signé)
        LT = 0b1011,
        // Supérieur (signé)
        GT = 0b1100,
        // Inférieur ou égal
        LE = 0b1101,
        // Valeur par défaut, toujours vrai
        AL = 0b1110
    }
}
