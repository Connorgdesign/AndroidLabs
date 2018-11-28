using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SavedStateTest
{
    class Number
    {
        public string N { get; set; }
        public int C { get; set; }

        public Number() {
            N = "0";
            C = 0;
        }

        public Number(string number, int count) {
           
            N = number;
            C = count;
        }

        public int increaseNumber() {

            int c = C += 1;
            return c;
        }

        public int updateNumber() {

            return 0;
        }

        public string resetNumber() {
            C = 0;
            N = C.ToString();
            return N;
        }

        public int getNumber() {
            return C;
        }

    }
}