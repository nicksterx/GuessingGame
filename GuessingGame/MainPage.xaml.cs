using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace GuessingGame
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        guessing_engine ge;

        public MainPage()
        {
            InitializeComponent();
            var numericScope = new InputScope();
            var numericScopeName = new InputScopeName();
            numericScopeName.NameValue = InputScopeNameValue.Number;
            numericScope.Names.Add(numericScopeName);
            bxGuess.InputScope = numericScope;  
        }
        public int input_int(string foo)
        {
            try
            {
                System.Convert.ToInt16(foo);
                return System.Convert.ToInt16(foo);
            }
            catch
            {
                return -1234567; //I'm really hoping this is a number that never get's calculated!
            }
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int guess = input_int(bxGuess.Text);
            if (ge.getRemaining()== 0)
            {
                bxGuess.IsEnabled = false;
                hiLowDisplay.Text = "LOSE!";
                button1.IsEnabled = false;
            }
            else
            {
                if (guess == ge.getRandomNumber())
                {
                    bxGuess.IsEnabled = false;
                    hiLowDisplay.Text = "WIN!";
                    button1.IsEnabled = false;
                }
                else if (guess != ge.getRandomNumber())
                {
                    if (guess > ge.getRandomNumber())
                    {
                        hiLowDisplay.Text = "HIGH";
                        txRem.Text = ge.decrRemaining();
                        txAtmp.Text = ge.incrAttempts();
                    }
                    if (guess < ge.getRandomNumber())
                    {
                        hiLowDisplay.Text = "LOW";
                        txRem.Text = ge.decrRemaining();
                        txAtmp.Text = ge.incrAttempts();
                    }
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ge = new guessing_engine();
            txAtmp.Text = ge.getAttempts().ToString();
            txRem.Text = ge.getRemaining().ToString();
            bxGuess.IsEnabled = true;
            bxGuess.Text = "";
            button1.IsEnabled = true;
        }
    }
}