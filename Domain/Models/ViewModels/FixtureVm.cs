namespace Domain.Models.ViewModels
{
    public class FixtureVm
    {
        public int MatchNo { get; set; }
        public int MatchCode { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public double NormalHome { get; set; }
        public double NormalAway { get; set; }
        public double NormalDraw{ get; set; }
    }
}