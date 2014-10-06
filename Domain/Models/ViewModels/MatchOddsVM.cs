using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ViewModels
{
   public class MatchOddsVm
   {
       public int  Mat { get; set; }
       public decimal OddFt1 { get; set; }
       public decimal OddFTX { get; set; }
       public decimal OddFT2 { get; set; }

       public decimal OddHt1 { get; set; }
       public decimal OddHtx { get; set; }
      public decimal OddHt2 { get; set; }

      public decimal odd1X { get; set; }
      public decimal oddX2 { get; set; }
      public decimal odd12 { get; set; }

      public decimal oddHC1 { get; set; }
      public decimal oddHCX { get; set; }
      public decimal oddHC2 { get; set; }
      public decimal oddHtUnder05 { get; set; }
      public decimal oddHtOver05 { get; set; }
        public decimal oddHtOver15 { get; set; }
      public decimal oddHtUnder15 { get; set; }
      public decimal oddHtOver25 { get; set; }
      public decimal oddHtUnder25 { get; set; }
      public decimal oddHtUnder35 { get; set; }
      public decimal oddHtOver35 { get; set; }
      public decimal oddFtUnder05 { get; set; }
      public decimal oddFtOver05 { get; set; }
      public decimal oddFtOver15 { get; set; }
      public decimal oddFtUnder15 { get; set; }
      public decimal oddFtOver25 { get; set; }
      public decimal oddFtUnder25 { get; set; }
      public decimal oddFtOver35 { get; set; }
      public decimal oddFtUnder35 { get; set; }
      public decimal oddFtOver45 { get; set; }
      public decimal oddFtUnder45 { get; set; }

      public decimal oddFtOver55 { get; set; }
      public decimal oddFtUnder55 { get; set; }

      public decimal oddGG { get; set; }
      public decimal oddNG { get; set; }
      public int HomeGoal { get; set; }
      public int AwayGoal { get; set; }
   }
}
