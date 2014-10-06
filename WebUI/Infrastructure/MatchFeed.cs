using System.Collections.Generic;
using Domain.Models.Concrete;

namespace WebUI.Infrastructure
{
    public class MatchFeed
    {
      public  List<Team> Team =null;
      public Match Game = null;
      public List<MatchOdd> Odd = null;
    }
}