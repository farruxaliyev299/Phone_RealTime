﻿using MobilePhone.Helpers.Enums;
using MobilePhone.Helpers.UI;
using MobilePhone.Helpers.Validations;
using MobilePhone.Models;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;

namespace MobilePhone
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Phone phone = BuyNewPhone();
            while (true)
            {

                PhoneUIs.InitialUI(phone);

                CancellationTokenSource src = new();
                var token = src.Token;

                Task clock = new Task(() => ClockUpdater(phone, src), token);
                clock.Start();

                MakeACall(phone, src);
            }
        }

        static void ClockUpdater(Phone phone, CancellationTokenSource src)
        {
            while (true)
            {
                string time = DateTime.Now.ToString("HH:mm");
                Task.Delay(1000).Wait();
                if (!src.IsCancellationRequested) PhoneUIs.InitialUI(phone, time);
            }
        }

        static Phone BuyNewPhone()
        {
            Phone newPhone;
            do
            {
                Console.Write("Nomrenizi daxil edin: ");
                string? numberInput = Console.ReadLine();

                Console.Write("Balansi daxil edin: ");
                decimal balanceInput = decimal.Parse(Console.ReadLine());

                newPhone = new()
                {
                    Number = numberInput,
                    Balance = balanceInput
                };
            } while (newPhone.errors.Count != 0);

            return newPhone;
        }

        static void MakeACall(Phone phone, CancellationTokenSource src)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var tokenSource2 = new CancellationTokenSource();
            var token2 = tokenSource2.Token;

            DateTime dateTime = new DateTime(1, 1, 1, 00, 0, 0, 0);

            bool acceptStatus = false;


            Console.WriteLine("\nPress Y key to begin call...");
            while (Startup(phone, dateTime, src))
            {
                Task waitForInput = new Task(() => Wait(phone, dateTime, tokenSource, ref acceptStatus));
                Task limitCounter = new Task(() => SecondLimitViolated(phone, dateTime, tokenSource, ref acceptStatus));

                waitForInput.Start();
                Console.WriteLine("Calling....");
                Console.WriteLine("\nPress Y to accept the call");
                limitCounter.Start();
                break;
            }


            while (!Wait(phone, dateTime, tokenSource, ref acceptStatus))
            {
                Console.Clear();
                Console.WriteLine("\nPhone Call Ended");
                tokenSource.Cancel();
                break;
            }
        }

        static bool Startup(Phone phone ,DateTime dateTime, CancellationTokenSource src, string? number = "")
        {

            var keyInfo = Console.ReadKey(true);
            src.Cancel();
            if (keyInfo.Key == ConsoleKey.Y)
            {
                return true;
            }
            else if(keyInfo.Key == ConsoleKey.Backspace && number.Length > 0)
            {
                number = number?[0..(number.Length - 1)];
            }
            else if (Char.IsDigit(keyInfo.KeyChar) && number?.Length <= 13)
            {
                number += keyInfo.KeyChar;
            }
            PhoneUIs.DialUpPhaseUI(phone, number);
            return Startup(phone ,dateTime, src, number);
        }

        static bool Cancellation(DateTime dateTime, CancellationTokenSource tokenSrc, char keyInfo)
        {
            if (keyInfo == 'N' || keyInfo == 'n')
            {
                tokenSrc.Cancel();
                return true;
            }
            return Cancellation(dateTime, tokenSrc, keyInfo);
        }

        static void Start(Phone phone, DateTime dateTime, ref bool acceptStatus, CancellationTokenSource cts)
        {
            acceptStatus = true;
            while (true && !cts.IsCancellationRequested)
            {
                Console.Clear();
                Console.WriteLine("\n");
                PhoneUIs.CallingPhaseUI(phone, true, dateTime.ToString("HH:mm:ss"));
                Task.Delay(1000).Wait();
                dateTime = dateTime.AddSeconds(1);
            }
        }

        static bool Wait(Phone phone, DateTime dateTime, CancellationTokenSource cts, ref bool acceptStatus)
        {
            char keyInfo = Console.ReadKey(true).KeyChar;
            if (cts.IsCancellationRequested) return true;

            if (keyInfo == 'N' || keyInfo == 'n')
            {
                if (Cancellation(dateTime, cts, keyInfo))
                {
                    acceptStatus = true;
                    Console.Clear();
                    PhoneUIs.CallingPhaseUI(phone, false);
                    Task.Delay(1000).Wait();
                    return true;
                }
            }
            if ((keyInfo == 'Y' || keyInfo == 'y') && !acceptStatus)
            {
                Start(phone, dateTime, ref acceptStatus, cts);
            }
            return Wait(phone, dateTime, cts, ref acceptStatus);
        }

        static bool SecondLimitViolated(Phone phone, DateTime dateTime, CancellationTokenSource tokenSrc, ref bool acceptStatus)
        {
            while (dateTime.Second <= 13 && !acceptStatus)
            {
                PhoneUIs.CallingPhaseUI(phone);
                Task.Delay(1000).Wait();
                dateTime = dateTime.AddSeconds(1);
            }
            if (tokenSrc.IsCancellationRequested || acceptStatus) return false;
            tokenSrc.Cancel();
            Console.Clear();
            PhoneUIs.CallingPhaseUI(phone, false);
            return true;
        }
    }
}


