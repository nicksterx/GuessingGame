using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace GuessingGame 
{
    public class guessing_engine
    {
        private int randomNumber;
        private int attempts = 0;
        private int remaining = 10;
        public guessing_engine()
        {
            setRandomNumber();
        }

        private void setRandomNumber(){
            Random random = new Random();
            randomNumber = random.Next(0, 100);
        }
        public int getRandomNumber()
        {
            return randomNumber;
        }
        public string incrAttempts()
        {
            attempts += 1;
            return attempts.ToString();
        }
        public int getAttempts()
        {
            return attempts;
        }
       public string decrRemaining()
        {
            remaining -= 1;
            return remaining.ToString();
        }
        public int getRemaining()
        {
            return remaining;
        }
    }
}
