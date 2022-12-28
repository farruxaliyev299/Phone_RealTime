using MobilePhone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.Helpers.UI
{
    public static class PhoneUIs
    {
        public static void InitialUI(Phone phone, string? time = "")
        {
            var providerUI = phone.NumberProvider == "Bakcell" ?
                "Bakcell " : phone.NumberProvider == "Nar" ?
                "Nar     " : phone.NumberProvider == "Azercell" ?
                "Azercell" : phone.NumberProvider == "Naxtel" ?
                "Naxtel  " : phone.NumberProvider == null ?
                "        " : " ";

            if (time == "") time = DateTime.Now.ToString("HH:mm");

            string date = DateTime.Now.ToString("ddd");

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"               ┌─────────────────────────────┐");
            Console.WriteLine($"               │                             │");
            Console.WriteLine($"               │  {providerUI}              \\|/  │");
            Console.WriteLine($"               │                             │");
            Console.WriteLine($"               │                             │");
            Console.WriteLine($"               │            {time}            │");
            Console.WriteLine($"               │             {date}             │");
            Console.WriteLine($"               │          _________          │");
            Console.WriteLine($"               │                             │");
            Console.WriteLine($"               │                             │");
            Console.WriteLine($"               │                             │");
            Console.WriteLine($"               │                             │");
            Console.WriteLine($"               │                             │");
            Console.WriteLine($"               │                             │");
            Console.WriteLine($"               │                             │");
            Console.WriteLine($"               │─────────────────────────────│");
            Console.WriteLine($"               │                             │");
            Console.WriteLine($"               │─────────┐    |    ┌─────────│");
            Console.WriteLine($"               │    Y    │  ─ + ─  │    N    │");
            Console.WriteLine($"               │─────────┘    |    └─────────│");
            Console.WriteLine($"               │                             │");
            Console.WriteLine($"               │                             │");
            Console.WriteLine($"               │───────── ───────── ─────────│");
            Console.WriteLine($"               │    1    │    2    │    3    │");
            Console.WriteLine($"               │───────── ───────── ─────────│");
            Console.WriteLine($"               │    4    │    5    │    6    │");
            Console.WriteLine($"               │───────── ───────── ─────────│");
            Console.WriteLine($"               │    7    │    8    │    9    │");
            Console.WriteLine($"               │───────── ───────── ─────────│");
            Console.WriteLine($"               │    *    │    0    │    #    │");
            Console.WriteLine($"               └─────────────────────────────┘");
            Console.WriteLine();

            Console.WriteLine("     -------------------- Kredit -----------------------");
            Console.WriteLine("     -------------- Nar - *700# - 3 AZN ----------------");
            Console.WriteLine("     ------------ Bakcell - *150# - 2 AZN --------------");
            Console.WriteLine("     ------------ Azercell - *100# - 0.50 AZN ----------------");
            Console.WriteLine("     ------------- Naxtel - *100*1# - 1 AZN ----------------");
            Console.WriteLine();
            Console.WriteLine("Type the number you want to dial: ");

        }

        public static void CallingPhaseUI(Phone phone, bool? callState = null, string? timeStr = null)
        {
            var providerUI = phone.NumberProvider == "Bakcell" ?
                "Bakcell " : phone.NumberProvider == "Nar" ?
                "Nar     " : phone.NumberProvider == "Azercell" ?
                "Azercell" : phone.NumberProvider == "Naxtel" ?
                "Naxtel  " : phone.NumberProvider == null ?
                "        " : " ";

            string state = callState == true ?
                           timeStr + "  " : callState == false ?
                           "Call ended" : callState == null ?
                           "Calling.. " : "";

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"                   ┌─────────────────────────────┐");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │  {providerUI}              \\|/  │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │          {state}         │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │─────────────────────────────│");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │─────────┐    |    ┌─────────│");
            Console.WriteLine($"                   │    Y    │  ─ + ─  │    N    │");
            Console.WriteLine($"                   │─────────┘    |    └─────────│");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │───────── ───────── ─────────│");
            Console.WriteLine($"                   │    1    │    2    │    3    │");
            Console.WriteLine($"                   │───────── ───────── ─────────│");
            Console.WriteLine($"                   │    4    │    5    │    6    │");
            Console.WriteLine($"                   │───────── ───────── ─────────│");
            Console.WriteLine($"                   │    7    │    8    │    9    │");
            Console.WriteLine($"                   │───────── ───────── ─────────│");
            Console.WriteLine($"                   │    *    │    0    │    #    │");
            Console.WriteLine($"                   └─────────────────────────────┘");
        }


        public static void DialUpPhaseUI(Phone phone, string number)
        {
            var providerUI = phone.NumberProvider == "Bakcell" ?
                "Bakcell " : phone.NumberProvider == "Nar" ?
                "Nar     " : phone.NumberProvider == "Azercell" ?
                "Azercell" : phone.NumberProvider == "Naxtel" ?
                "Naxtel  " : phone.NumberProvider == null ?
                "        " : " ";

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"                   ┌─────────────────────────────┐");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │  {providerUI}              \\|/  │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                     {number}                     ");
            Console.WriteLine($"                   │─────────────────────────────│");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │─────────┐    |    ┌─────────│");
            Console.WriteLine($"                   │    Y    │  ─ + ─  │    N    │");
            Console.WriteLine($"                   │─────────┘    |    └─────────│");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │                             │");
            Console.WriteLine($"                   │───────── ───────── ─────────│");
            Console.WriteLine($"                   │    1    │    2    │    3    │");
            Console.WriteLine($"                   │───────── ───────── ─────────│");
            Console.WriteLine($"                   │    4    │    5    │    6    │");
            Console.WriteLine($"                   │───────── ───────── ─────────│");
            Console.WriteLine($"                   │    7    │    8    │    9    │");
            Console.WriteLine($"                   │───────── ───────── ─────────│");
            Console.WriteLine($"                   │    *    │    0    │    #    │");
            Console.WriteLine($"                   └─────────────────────────────┘");
        }
    }
}
