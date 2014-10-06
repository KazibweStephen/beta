/**
 * Created by kazibwesempa on 9/13/2014.
 */
function ReceiptGen() {
    this.generateReceipt = function (betList) {
        var self = this;
        betList.each(function (bet) {
            self.addBetElement(bet);
        });
        this.updateSummaryFields(betList);
    };


    var autoNumericInitializer = new AutoNumericInitializer();


    this.addBetElement = function (bet) {
        var $bet = $("#rcpTbet-template .bet>tr.receipt").clone();

        $("td.match-code", $bet).text(bet.matchCode);
        $bet.data("betId", bet.betId);
        $("#rcpTbetList").append($bet);

        $("td", $bet).each(function () {
            var $input = $(this),
                fieldName = $input.data("field");
            if (fieldName == "startTime") {
                $input.text(bet["startDate"] + " - " + bet[fieldName]);
            } else {
                if (fieldName == "teamVersus" && bet.betCategory == "Handicap") {
                    $input.text(bet[fieldName] + "-     " + bet["handCapGoalString"]);
                } else {
                    $input.text(bet[fieldName]);
                }
            }
        });

    };

    this.updateSummaryFields = function (betList) {
        var $rcpTselectionSummary = $("#rcpTstakeSummary");
        $("#rcpTtotalOdd", $rcpTselectionSummary).text(betList.getTotalBettedOdd() == 1 ? 0 : betList.getTotalBettedOdd());
        autoNumericInitializer.initAutoNumberOnField($("#rcpTtotalStake", $rcpTselectionSummary), betList.getTotalBettedAmount(), 0, ' Ugx ');
        autoNumericInitializer.initAutoNumberOnField($("#rcpTtotalPayout", $rcpTselectionSummary), betList.getTotalPayout(), 0, ' ');
        autoNumericInitializer.initAutoNumberOnField($("#rcpTmaxPayout", $rcpTselectionSummary), betList.getMaxPayout(), 0, ' Ugx ');
        autoNumericInitializer.initAutoNumberOnField($(".total-tax", $rcpTselectionSummary), betList.getTax(), 0, ' - ');
        autoNumericInitializer.initAutoNumberOnField($(".total-bonus", $rcpTselectionSummary), betList.getBonus(), 0, ' + ');

       // $("#rcpTtotalStake", $rcpTselectionSummary).text("Ugx " + betList.getTotalBettedAmount());
        $("#rcpTNoSelections", $rcpTselectionSummary).text(betList.getBets().length + "  ");

        // var $stakeSummary=$("#stakeSummary");
       // $("#rcpTtotalPayout", $rcpTselectionSummary).text( betList.getTotalPayout().toFixed(0));
        $(".stake-text", $rcpTselectionSummary).text("(" + betList.getBets().length + ")" + " lines");

        //var $maxPayout=$("#maxPayout");
       // $("#rcpTmaxPayout", $rcpTselectionSummary).text( betList.getMaxPayout());
       // $(".total-tax", $rcpTselectionSummary).text( betList.getTax().toFixed(0));
    };

    this.clearReceipt = function() {
        var $rcpTselectionSummary = $("#rcpTstakeSummary");
        $("#rcpTtotalOdd", $rcpTselectionSummary).text("");
        $("#rcpTtotalStake", $rcpTselectionSummary).text("");
        $("#rcpTNoSelections", $rcpTselectionSummary).text("");
        $("#rcpTbonus", $rcpTselectionSummary).text("");

        // var $stakeSummary=$("#stakeSummary");
        $("#rcpTtotalPayout", $rcpTselectionSummary).text("");
        $(".stake-text", $rcpTselectionSummary).text("");

        //var $maxPayout=$("#maxPayout");
        $("#rcpTmaxPayout", $rcpTselectionSummary).text("");
        $(".total-tax", $rcpTselectionSummary).text("");
        $("#rcpTbetList").empty();
    };
}
