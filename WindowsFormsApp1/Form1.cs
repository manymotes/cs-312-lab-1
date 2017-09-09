using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //takes the input form the input box.
            int inputValue = Convert.ToInt32(Input.Text);
            // convertes input from string to long
            long possible_prime = (Convert.ToInt64(Input.Text));
            //checks if number generated is prime
            if (is_It_Prime(possible_prime))
            {
                //uses the given algorith to find the probability and then prints it
                double k = Convert.ToDouble(kValue.Text);
                Output.Text = "prime, Probablity: " + 100.0 * (1.0 / (Math.Pow(2.0, k))) + "%";
            }
            else
            {
                Output.Text = "Not Prime.";
            }
        }

        // this funciton checks to see if the number n, random generated integers are prime
        //this is O(n^3) becuase it calls the modular expotentiation function which is O(n^3) which means it cant be anything lesser than that function
        // Its not greater than O(n^3) because is_it_prime doesnt add any signifigance lager than O(n^3) so it is simplified to O(n^3)

        private bool is_It_Prime(long n)
        {

            Random rnd = new Random();
            //converts 
            int k = (Convert.ToInt32(kValue.Text));
            //creates an array list the size of the given k value
            int[] rands = new int[k];
            for (int i = 0; i < k; i++)
            {
                // adds randomly generated umbers to the array of numbers between the n values. 
                rands[i] = rnd.Next(2, (int)n - 1);
            }

            //iterates over the random number list
            foreach (long r in rands)
            {
                //runs the given moduler exponentiation algorithm on each r number
                long exp = modular_exponentiation((int)r, ((int)n - 1), (int)n);
                //check to see if it prime or not and returns the desired response
                if (exp == 1)
                {
                    return true;
                }
            }
            return false;
        }

        //this function recursivly finds xmod N. It keeps the bit size down of the calculations by dividing repeatedly multiplying by x modulo N
        //this is O(n^3)
        //we calculate this big O by letting n be the size in bits x, y, and N as with multiplication. This function will halt after at most n recursive calls, and druing each call it multiplies n-bit numbers, for a total runtime of O(n^3).
        private long modular_exponentiation(long x, long y, long n)
        {
            //check if we met our base case of y = 0
            if (y == 0)
                return 1;
            long z = modular_exponentiation(x, y / 2, n);
            //check if y is an odd number
            if ((y & 1) == 1)
            {
                // return this value for the recursion process to run on the returned value
                long returnValue = x * ((z * z) % n) % n;
                return returnValue;
            }
            else
            {
                // return this value for the recursion process to run on the returned value
                long returnValue = (z * z) % n;
                return returnValue;
            }
        }
    }
}
