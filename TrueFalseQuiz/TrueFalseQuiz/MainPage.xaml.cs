using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrueFalseQuiz
{
    public partial class MainPage : ContentPage
    {
        public int i;
        public MainPage()
        {
            InitializeComponent();
            trueButton.IsVisible = true;
            falseButton.IsVisible = true;
            questionArea.IsVisible = true;
            i = 0;
        }

        List<Question> questions = new List<Question>()
        {
            new Question("The glass is always half full."),
            new Question("There is always a good side to any bad outcome."),
            new Question("People are generally good in nature."),
            new Question("You always trust things will end up okay."),
            new Question("Sometimes people can't change."),
            new Question("Some people are a lost cause.")
        };


        int falseCount = 0;
        int trueCount = 0;
        List<int> questionList = new List<int>();



        void FalseClicked(object sender, EventArgs args)
        {
            falseCount++;
            i++;
            ValidateNum();
        }
        void TrueClicked(object sender, EventArgs args)
        {
            trueCount++;
            i++;
            ValidateNum();
        }

        void GetNextQuestion()
        {
            questionArea.Text = questions[i].Text;
        }

        void ValidateNum()
        {
 
            if (i == 5)
            {
                trueButton.IsVisible = false;
                falseButton.IsVisible = false;

                Generate();
            }
            else
            {
                GetNextQuestion();
            }
        }

        void Generate()
        {
            if (trueCount >= falseCount)
            {
                questionArea.Text = "You're an optimistic person";
            } else
            {
                questionArea.Text = "You're an pessimistic person";

            }
        }
  

    }
}
