using System;

public static class StringExtensions
{
    public static bool ValidateNAS(this string input)
    {
        // Vérification si la chaîne d'entrée est nulle ou a une longueur différente de 9.
        if (string.IsNullOrEmpty(input) || input.Length != 9)
        {
            return false;
        }

        // Vérification si la chaîne d'entrée est composée uniquement de chiffres.
        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }

        // Convertir la chaîne en tableau de chiffres.
        int[] digits = new int[9];
        for (int i = 0; i < 9; i++)
        {
            digits[i] = int.Parse(input[i].ToString());
        }

        // calcule de la validation du NAS Canadien.
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            int result = digits[i] * ((i % 2 == 0) ? 1 : 2); // Multiplication par 1 ou 2 en fonction de la position.
            sum += (result >= 10) ? result / 10 + result % 10 : result;
        }

        // Vérifier si la somme est divisible par 10.
        return sum % 10 == 0;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Bonjour veuillez entrer 9 chiffres du NAS Canadien (séparés en trois groupes de trois) : ");
        string input = Console.ReadLine().Replace(" ", "");

        if (input.Length != 9)
        {
            Console.WriteLine("Veuillez entrer exactement 9 chiffres.");
            return;
        }

        // Utilisation d'une méthode d'extension pour valider le numéro NAS Canadien.
        bool isValid = input.ValidateNAS();

        // Afficher le résultat.
        Console.WriteLine(isValid ? "Ce numéro NAS Canadien est valide." : "Ce numéro NAS Candien n'est pas valide.");
    }
}

