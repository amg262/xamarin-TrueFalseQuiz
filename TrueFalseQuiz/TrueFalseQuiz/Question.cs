using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace TrueFalseQuiz
{
     class Question
    {
        public string Text { get; set; }
        public string Image { get; set; }

        public Question(string text, string image)
        {
            this.Text = text;
            this.Image = image;
        }
    }
}
