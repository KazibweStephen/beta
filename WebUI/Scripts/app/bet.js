/**
 * Created by kazibwesempa on 9/6/2014.
 */

function Bet(matchId) {
    this.betId = Bet.nextBetId++;
    this.matchId = matchId;
    this.startTime = null;
    this.startDate = null;
    this.betCategory = null;
    this.homeTeamOdd = 0;
    this.drawOdd = 0;
    this.awayTeamOdd = 0;
    this.moreOdds = 0;
    this.optionId = 0;
    this.optionName = "";
    this.teamVersus = null;
    this.odd = 1;
    this.betAmount = 0;
    this.handCapGoalString = null;
    //this.betTotal=0;
    //this.maxPayout=0;
};
//define some static variable here
//Bet.localTax = 0;
Bet.nextBetId = 1;
Bet.singles = false;
//this one is for testing, please comment it out
Bet.nextBetAmount = 100;
Bet.multipleBetAmount = 0;
Bet.setMaxPayoutPossible = 0;
//********************************

//define support objects here
function BetList(bets) {
    bets = bets || [];
    this.getBets = function () {
        return bets;
    };
    this.addBet = function (bet) {
        bets.push(bet);
        return this;
    };
    function getBetIndex(betId) {
        for (var i in bets) {
            if (betId == bets[i].betId) {
                return parseInt(i);
            }
        }
        return -1;
    };
    this.getBet = function (betId) {
        var betIndex = getBetIndex(betId)
        return (betIndex >= 0 ? bets[betIndex] : null);
    };

    this.getBetByMatchId = function (matchId) {
       
        var found = false;
        this.each(function (bet) {
           
            if (bet.matchId === matchId || bet.matchId===0) {
                //alert(" " + bet.matchId + "Froma Ui " +  matchId+ "in bet");
                found=true;
            }
           
        });
        return found;
    };
    this.getBetByOptionNameAndMatchId = function (matchId, optionName) {

        var found = false;
        this.each(function (bet) {


            if (bet.matchId === matchId && bet.optionName.toString() === optionName.toString()) {
                //alert(" " + bet.matchId + "Froma Ui " +  matchId+ "in bet");

                found = true;
                return found;

            }

        });
        //console.log(bet.optionName + "---" + optionName);
        return found;
    };
    this.removeBet = function (betId) {
        var betIndex = getBetIndex(betId);
        if (betIndex >= 0) {
            var bet = bets[betIndex];
            bets.splice(betIndex, 1);
            return bet;
        }
        return null;
    };
    this.each = function (callBack) {
        if (callBack) {
            for (var i in bets) {

                callBack(bets[i]);
            }
        }
    };
    this.removeBets = function () {

        bets.splice(0, bets.length);
    };
    this.getTotalBettedOdd = function () {
        var _totalBettedOdd = 1;
        this.each(function (bet) {
            _totalBettedOdd *= bet.odd;
        });
        return _totalBettedOdd.toFixed(2);
    };

    this.getMaxPayout = function () {
        var _maxPayout = 0;
        
        // this.each(function(bet){
        //  _maxPayout+=(bet.odd*bet.betAmount);
        // });
        _maxPayout = (this.getTotalPayout() - this.getTax()+this.getBonus()).toFixed(0);
        return _maxPayout <= Bet.setMaxPayoutPossible ? _maxPayout : Bet.setMaxPayoutPossible;
    };

    this.getTotalPayout = function () {
        //var _maxPayout=1;
        // this.each(function(bet){
        //  _maxPayout+=(bet.odd*bet.betAmount);
        // });
        // return _maxPayout;
        /*If the value below in th e if statement evaluates to true
        * then the total payout is from singles only else its from multiples only
        * Note that this is also applies to the tax calculations, please find that function in this script if
        * you are to change this*/
        if (Bet.singles == true) {
            return this.getTotalBettedAmount() * this.getTotalBettedOdd();
        }
        return Bet.multipleBetAmount * this.getTotalBettedOdd();
    };
    this.getTotalBettedAmount = function () {
        var _totalBettedAmount = 0;
        this.each(function (bet) {
            _totalBettedAmount += parseInt(bet.betAmount);
        });
        if (Bet.singles == true) {
            return _totalBettedAmount;
        } else {
            return Bet.multipleBetAmount;
        }
    };

    this.getTax = function () {
        var _tax = 0,
            _taxPercentage = 0.15;//Bet.localTax;
        if (Bet.singles == true) {
            _tax = (this.getTotalPayout() /*- this.getTotalBettedAmount()*/) * _taxPercentage;
        } else {
            _tax = (this.getTotalPayout() /*- Bet.multipleBetAmount*/) * _taxPercentage;
        }
        return _tax;
    };
    
    this.getBonus = function () {
        var _bonus = 0,
            _bonusPercentage = 0.05;//Bet.localTax;
        if (Bet.singles == true) {
            _bonus = (this.getTotalPayout() /*- this.getTotalBettedAmount()*/) * _bonusPercentage;
        } else {
            _bonus = (this.getTotalPayout()/* - Bet.multipleBetAmount*/) * _bonusPercentage;
        }
        return _bonus;
    };


    
};


function AutoNumericInitializer() {
     this.initAutoNumberOnField=function($field, value, numDec, prefix) {
        var _numDec = numDec,
            _prefix = prefix;
        $field.autoNumeric('init', { aSign: prefix, mDec: _numDec });
        $field.autoNumeric('set', value);
    };
};
//********************************