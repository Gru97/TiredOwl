using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiredOwl.Domain.ChannelOwners;

public class BankAccount : ValueObject
{
    public string Value { get; set; }
    public Bank Bank { get; set; }
    public BankAccount Create(string value) => new (value, GetBank(value));

    private Bank GetBank(string value)
    {
        throw new NotImplementedException();
    }

    public BankAccount(string value, Bank bank)
    {
        //validations of bank account
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

public class Bank: EnumerableValueObject
{
    public static Bank Bank1 = new Bank(1, "Bank1");
    public static Bank Bank2 = new Bank(1, "Bank2");
    protected Bank(int value, string name) : base(value, name) { }
}

