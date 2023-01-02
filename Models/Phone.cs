using MobilePhone.Helpers.Enums;
using MobilePhone.Helpers.Extenisons;
using MobilePhone.Helpers.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.Models;

public class Phone : ErrorsBase
{
    public Phone()
    {
        errors = new List<PhoneError>();
    }

    public static Dictionary<string, string> credits = new()
        {
            { "Bakcell", "*150#" },
            { "Nar", "*700#" },
            { "Azercell", "*100#" },
            { "Naxtel", "*100*1#" }
        };

    private string _number;
    public string Number
    {
        get => _number;
        set
        {
            value = value.Trim();

            List<string> providers = GetProviders(typeof(Provider));


            if (PhoneNumberValidation.IsValidWithoutAnything(value, providers))
            {
                _number = "+994" + value;

                this.NumberProvider = EnumExtensions.GetDisplayName((Provider)int.Parse("0" + value.Substring(0, 2)));

                return;
            };
            if (PhoneNumberValidation.IsValidWithCountryCode(value, providers))
            {
                _number = value;

                this.NumberProvider = EnumExtensions.GetDisplayName((Provider)int.Parse("0" + value.Substring(4, 2)));

                return;
            };
            if (PhoneNumberValidation.IsValidWithZeroAtStart(value, providers))
            {
                _number = "+994" + value.Substring(1);

                this.NumberProvider = EnumExtensions.GetDisplayName((Provider)int.Parse("0" + value.Substring(1, 2)));

                return;
            }
            errors.Add(PhoneError.NumberIsFalse);
            Console.WriteLine("Entered number is incorrect! Try Again");
        }
    }
    public string NumberProvider { get; set; }

    private decimal _balance;
    public decimal Balance
    {
        get => _balance;
        set
        {
            if (value >= 0) _balance = value;
            else errors.Add(PhoneError.BalanceUnderZero);
        }
    }
    public List<Contact> ContactList { get; set; }



    public static List<string> GetProviders(Type provider)
    {
        List<string> providers = new List<string>();

        foreach (var pr in Enum.GetValues(typeof(Provider)))
        {
            providers.Add(((int)pr).ToString());
        }

        return providers;
    }

    public void AddToContacts(Contact contact)
    {
        ContactList.Add(contact);
        Console.WriteLine("Contact has ben added!");
    }

    public void MakeACall()
    {
        DateTime time = DateTime.Now;

    }

    public void TakeCredit()
    {
        switch (this.NumberProvider)
        {
            case "Bakcell":
                this.Balance += 2;
                break;
            case "Azercell":
                this.Balance += 0.5M;
                break;
            case "Nar":
                this.Balance += 3;
                break;
            case "Naxtel":
                this.Balance += 1;
                break;
            default:
                return;
        }
    }
}
