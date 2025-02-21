namespace PruebaTecnica.Domain.Models
{
    public class LoanModel : Entity
    {
        public double LoanAmount { get; private set; }
        public int LoanState { get; private set; }
        public int LoanUser { get; private set; }

        public LoanModel(int Id, double LoanAmount, int LoanState, int LoanUser):base(Id)
        {
            this.LoanAmount = LoanAmount;
            this.LoanState = LoanState;
            this.LoanUser = LoanUser;
        }
    }
}
