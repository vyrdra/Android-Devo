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

namespace lab3Quotes
{
    class Quiz
    {
        public class Quote
        {
            public string Body { get; set; }
            public string Author { get; set; }
            public int QuoteID { get; set; }
        }


        public class QuoteMaster
        {
            private List<Quote> quotes = new List<Quote>();

            public List<Quote> Quotes { get { return quotes; } }

            // default constructor
            public QuoteMaster()
            {
            
            }

           
            public QuoteMaster(string dummy)
            {
                quotes.Add(new Quote() { QuoteID = 1 , Body = "My mission in life is not merely to survive, but to thrive, and to do so with some passion, some compassion, some humor, and some style.", Author = "maya angelou" });
                quotes.Add(new Quote() { QuoteID = 2, Body = "Things work out best for those who make the best of how things work out.", Author = "John Wooden" });
                quotes.Add(new Quote() { QuoteID = 3, Body = "Learn from yesterday, live for today, hope for tomorrow. The important thing is not to stop questioning.", Author = "albert einstein" });
                quotes.Add(new Quote() { QuoteID = 4, Body = "It does not matter how slowly you go, so long as you do not stop.", Author = "confucius" });
                quotes.Add(new Quote() { QuoteID = 5, Body = "Success is walking from failure to failure with no loss of enthusiasm.", Author = "winston churchill" });
                quotes.Add(new Quote() { QuoteID = 6, Body = "Don't cry because it's over, smile because it happened.", Author = "dr. seuss" });
                
            }

            public string GetQuoteBody(int i)
            {
                string body = "";
                foreach (Quote q in Quotes)
                {
                    if (i == q.QuoteID)
                    {
                        body += q.Body + "\n\r";
                    }  
                }
                return body;
            }

            public Quote GetQuote(int i)
            {
                Quote qt = new Quote();
                foreach(Quote q in Quotes)
                {
                    if (i == q.QuoteID)
                    {
                        qt = q;
                    }
                }
                return qt;
            }

            public string GetAuthor(int i)
            {
                string auth = "";
                foreach (Quote q in Quotes)
                {
                    if (i == q.QuoteID)
                    {
                        auth += q.Author + "\n\r";
                    }
                }
                return auth;
            }

            public bool GetQuoteAnswer(Quote q, string ans)
            {
               if (q.Author == ans)
                {
                    return true;
                }
               else
                {
                    return false;
                }
                
            }

            

        }

    }
}