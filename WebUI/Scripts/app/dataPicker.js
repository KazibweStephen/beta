
$(document).ready(function () {
    /*$('.odd').click(function () {
         var $that = $(this);
         var matchCode = $that.siblings("td")
         var odd = $that.val();
         var rowIndex = $(this).parent().parent().index('tr');
         var columnIndex = $(this).parent().index('tr:eq(' + rowIndex + ') td');

         alert('Row Index: ' + rowIndex + ', Column Index: ' + columnIndex + ', Odd: ' + odd);

         var headrow = $('#oddstable tr').eq(0);
         //var cell = headrow.index('th:eq(0)').html();
         alert('Cell Contents: ' + headrow);
         //var oddType = $('#oddstable tr:nth-child(0) > th:nth-child(0)').html();
         //  ('td:nth-child('+columnIndex+')');
         //var child = oddType.child(0)
         //console.log(oddType);

         //console.log('Odd Type: ' + oddType);
     });*/


    var $match = $("#match .match");
    var betList = new Array();
    $("input.odd", $match).on("click", function () {
        var $that = $(this);
        var chosenOdd = $that.val(),
        $matchCode = $that.parent().siblings("td.match-code"),
        matchCode = $matchCode.text(),
        bet = new Bet(matchCode);
        bet.chosenOdd = chosenOdd;
        $matchCode.siblings("td").each(function () {
            var fieldName = $(this).data("field");
            bet[fieldName] = $(this).val();
        });
        var $parentTr = $matchCode.parent();
        $("td>input.odd", $parentTr).each(function () {
            var fieldName = $(this).data("field");
            if (fieldName) {
                bet[fieldName] = $(this).val();
                bet["fixture"] = $(this).data("fixture");
                bet["fixtureOption"] = $(this).data("fixture-option");
            }
        });


    
        betList.push(bet);
        console.log(bet);




    });


    function Bet(matchCode) {
        this.betId = Bet.nextBetId++;
        this.matchCode = matchCode;
        this.startTime = null;
        this.fixture = null;
        this.homeTeamOdd = 0;
        this.drawOdd = 0;
        this.awayTeamOdd = 0;
        this.moreOdds = 0;
        this.fixtureOption = null;
        this.teamVersus = null;
        this.chosenOdd = 0;
        this.amountBet = 0;
        this.betTotal = 0;
        this.maxPayout = 0;
    };
    //define some static variable here
    Bet.nextBetId = 1;

});