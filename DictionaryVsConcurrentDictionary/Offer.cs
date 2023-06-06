namespace DictionaryVsConcurrentDictionary
{
    public class Offer
    {
        public Offer(string title, string body, string comments)
        {
            this.Title = title;
            this.Body = body;
            this.Comments = comments;
        }

        public string Title { get; }

        public string Body { get; }

        public string Comments { get; }
    }
}