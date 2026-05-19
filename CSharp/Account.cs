// Imports //
using System.Text.Json;

// Account Blueprint / Class //
class Account
{
    // Public Variables //
    public string Name;
    public string LastName;
    public string Password;
    public double Balance;

    // Public Deposit & Withdraw Voids //
    public void Deposit(double amount)
    {
        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        Balance -= amount;
    }

    // Json Saver //
    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}
