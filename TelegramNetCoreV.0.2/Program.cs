using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramNetCoreV._0._2
{
    class Program
    {
            static ITelegramBotClient botClient;
        static long chatID = 730424171;
        //static long chatID = 695278516;      ===   ini id botnya vino === 
        static string kata = "0";

            static void Main()
            {
                botClient = new TelegramBotClient("695278516:AAGNTqhMroKgIIXuFUeI8SydbznzzPBWh8M");

                var me = botClient.GetMeAsync().Result;
                Console.WriteLine(
                  $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
                );

                botClient.OnMessage += Bot_OnMessage;
                botClient.StartReceiving();
                Thread.Sleep(int.MaxValue);
            }

            static async void Bot_OnMessage(object sender, MessageEventArgs e)
            {
                if (e.Message.Text != null)
                {
                    //Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
                    Console.WriteLine($"Received a text message in chat {chatID}.");

                    //await botClient.SendTextMessageAsync(
                    //  chatId: e.Message.Chat,
                    //  text: "You said:\n" + e.Message.Text
                    //);

                    while (kata != "end")
                    {
                        Console.Write("Masukkan Kata : ");
                        kata = Console.ReadLine();
                        try
                        {
                            await botClient.SendTextMessageAsync(chatID, kata);
                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine(exp);
                        }
                    }

                Environment.Exit(1);
                }
            }
        }
    }