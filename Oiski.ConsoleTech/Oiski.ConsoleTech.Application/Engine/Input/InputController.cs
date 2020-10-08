﻿using Oiski.ConsoleTech.OiskiEngine.Controls;
using Oiski.ConsoleTech.OiskiEngine.Engine.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Oiski.ConsoleTech.OiskiEngine.Input
{
    public class InputController
    {
        public int CurrentSelectedIndex { get; protected set; }

        public NavController Navigation { get; } = new NavController();

        public bool EnableNavigation { get; set; } = true;

        public ConsoleKeyInfo GetKeyInfo ()
        {
            return Console.ReadKey();
        }

        public char GetChar ()
        {
            return Console.ReadKey().KeyChar;
        }

        public string GetString ()
        {
            return Console.ReadLine();
        }

        public void ListenForInput<T> (Func<T> _inputStream)
        {
            if ( _inputStream == null )
            {
                throw new Exception("Input Stream can't be null!");
            }

            Thread inputThread = new Thread(() => Run(_inputStream))
            {
                Name = "Input",
                IsBackground = true

            };

            inputThread.Start();
        }

        Stopwatch watch = Stopwatch.StartNew();

        private void Run<T> (Func<T> _inputStream)
        {
            var sw = watch;
            string infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Since Last Input: {sw.ElapsedMilliseconds / 1000} Seconds<";
            Label threadInfo = new Label(infoOutput, new Vector2(Console.WindowWidth - infoOutput.Length - 4, 3));

            if ( _inputStream == null )
            {
                throw new Exception("Input Stream can't be null!");
            }

            if ( EnableNavigation )
            {
                if ( ( ( ConsoleKeyInfo ) ( object ) _inputStream.Invoke() ).Key == Navigation.Up )
                {
                    lock ( this )
                    {
                        CurrentSelectedIndex++;
                        watch.Restart();
                    }
                }
                else if ( ( ( ConsoleKeyInfo ) ( object ) _inputStream.Invoke() ).Key == Navigation.Down )
                {
                    lock ( this )
                    {
                        CurrentSelectedIndex--;

                        watch.Restart();
                    }
                }
            }
        }
    }
}
