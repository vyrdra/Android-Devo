using Android.App;
using Android.Widget;
using Android.OS;
using System.Xml.Serialization;
using System.IO;
using System;

namespace lab3Quotes
{
    [Activity(Label = "lab3Quotes", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        QuoteMaster quoteMaster;
        Random rand = new Random();
        int score = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //make the layout elements avaible for code
            SetContentView(Resource.Layout.Main);

            if (bundle == null)
            {
                quoteMaster = new QuoteMaster("testing");
            }
            else
            {
                //get the saved objet from the serializer
                string xmlQuotes = bundle.GetString("Quotes");
                XmlSerializer x = new XmlSerializer(typeof(QuoteMaster));
                quoteMaster = (QuoteMaster)x.Deserialize(new StringReader(xmlQuotes));
            }
            //display quotes
            int r = rand.Next(1, 7);
            var quoteTextView = FindViewById<TextView>(Resource.Id.quoteTxtV);
            quoteTextView.Text = quoteMaster.GetQuoteBody(r);

            //answer question
            var answerText = FindViewById<EditText>(Resource.Id.quoteAnswerTxtV);
            Button enterBtn = FindViewById<Button>(Resource.Id.enterBtn);
            var scoreText = FindViewById<TextView>(Resource.Id.scoreTxtV);

            enterBtn.Click += delegate
            {
                if (quoteMaster.GetQuoteAnswer(quoteMaster.GetQuote(r), answerText.Text))
                {
                    score++;
                    scoreText.Text = "Score: " + score;
                    answerText.Text = "Correct!";
                }
                else
                {
                    
                    scoreText.Text = "Score: " + score;
                    answerText.Text = "Sorry the correct answer is " + quoteMaster.GetAuthor(r);

                }

            };

            //next button, get new rand for new quote
            Button nextBtn = FindViewById<Button>(Resource.Id.nextBtn);

            nextBtn.Click += delegate
            {
                r = rand.Next(1, 7);
                quoteTextView = FindViewById<TextView>(Resource.Id.quoteTxtV);
                answerText.Text = " ";
                quoteTextView.Text = quoteMaster.GetQuoteBody(r);
            };


        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            // Use this to convert a stream to a string
            StringWriter writer = new StringWriter(); 

            // Serialize the public state of taskMaster to XML
            XmlSerializer quoteMasterSerializer = new XmlSerializer(typeof(QuoteMaster));
            quoteMasterSerializer.Serialize(writer, quoteMaster);

            // Save the serialized state
            string xmlQuotes = writer.ToString();
            outState.PutString("Quotes", xmlQuotes);

            base.OnSaveInstanceState(outState);
        }
    }
}

