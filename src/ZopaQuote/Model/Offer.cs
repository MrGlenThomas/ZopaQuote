namespace ZopaQuote.Model
{
    public class Offer
    {
        public Offer(string lender, string rate, string amountAvailable)
            : this(lender, decimal.Parse(rate), int.Parse(amountAvailable))
        {
        }

        public Offer(string lender, decimal rate, int amountAvailable)
        {
            Lender = lender;
            Rate = rate;
            AmountAvailable = amountAvailable;
        }

        public string Lender { get; set; }
        public decimal Rate { get; set; }
        public int AmountAvailable { get; set; }
    }
}
