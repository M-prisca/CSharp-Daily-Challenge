
using System;

public enum TransactionType
{
    Deposit,
    Withdrawal
}

public static class TransactionValidator
{
    public static bool Validate(
        TransactionType type,
        decimal amount,
        decimal balance)
    {
        if (amount <= 0 || balance < 0)
        {
            return false;
        }

        if (type == TransactionType.Deposit)
        {
            return true;
        }

        if (type == TransactionType.Withdrawal)
        {
            return amount <= balance;
        }

        return false;
    }
}
