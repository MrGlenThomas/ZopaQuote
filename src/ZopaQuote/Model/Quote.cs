namespace ZopaQuote.Model
{
    public class Quote
    {
        public Quote(decimal requestedAmount, decimal rate, decimal monthlyRepayment, decimal totalRepayment)
        {
            RequestedAmount = requestedAmount;
            Rate = rate;
            MonthlyRepayment = monthlyRepayment;
            TotalRepayment = totalRepayment;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal RequestedAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// £XXXX.XX
        /// </summary>
        public decimal MonthlyRepayment { get; set; }

        /// <summary>
        /// £XXXX.XX
        /// </summary>
        public decimal TotalRepayment { get; set; }
    }
}
