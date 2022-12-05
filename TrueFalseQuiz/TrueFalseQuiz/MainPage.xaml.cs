using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrueFalseQuiz
{
    public partial class MainPage : ContentPage
    {
        public int i;
        public int j;
        IList<string> strList = new List<string>();
        IList<string> imageList = new List<string>();
        public MainPage()
        {
            InitializeComponent();
            trueButton.IsVisible = true;
            falseButton.IsVisible = true;
            questionArea.IsVisible = true;
            i = 0;
            j = 0;
            strList.Add("A");
            strList.Add("B");
            strList.Add("C");
            strList.Add("D");
            strList.Add("E");
            imageList.Add("a.jpg");
            imageList.Add("b.png");
            imageList.Add("c.jpg");
            imageList.Add("d.jpg");
            imageList.Add("e.jpg");
        }

        List<Question> questions = new List<Question>()
        {
            new Question("The glass is always half full.", "a.jpg"),
            new Question("There is always a good side to any bad outcome.", "b.png"),
            new Question("People are generally good in nature.", "c.jpg"),
            new Question("You always trust things will end up okay.", "d.jpg"),
            new Question("Sometimes people can't change.", "e.jpg"),
            new Question("Some people are a lost cause.", "b.png"),
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
 
            if (i >= 5)
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
        void OnSwiped(object sender, SwipedEventArgs e)
        {

            i++;

            theLabel2.Text = e.Direction.ToString() + " " + j;
            if (e.Direction == SwipeDirection.Right)
            {
                if (j >= strList.Count - 1)
                {
                   j = -1;
                }
                theLabel2.Text = strList[++j];
                theImage.Source = imageList[j];
                ValidateNum();
            }
            else if (e.Direction == SwipeDirection.Left)
            {
                if (j <= 0)
                {
                    j = strList.Count;
                }
            
                theLabel2.Text = strList[--j];
                theImage.Source = imageList[j];
                ValidateNum();
            }
            else if (e.Direction == SwipeDirection.Up)
            {

                theLabel2.Text = "Oh Snap";

            }
            else if (e.Direction == SwipeDirection.Down)
            {

                theLabel2.Text = "Wake up!";

            }
        }

    }

}

