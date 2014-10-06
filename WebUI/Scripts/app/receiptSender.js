/**
 * Created by kazibwesempa on 9/12/2014.
 */
function Receipt() {

    this.receiptSize = 0;
    this.TotalOdd = 0;
    this.totalStake = 0;
    this.betData = new Array();
    this.multipleBetAmount = 0;
}

function BetData() {

    this.matchId = null;

    this.betCategory = null;

    this.optionId = 0;

    this.odd = 1;
    this.betAmount = 0;

};


function SendReceipt() {


    this.postReceipt = function(betList) {
        var diferred = $.Deferred();
        var receipt = new Receipt();
        var bets = betList.getBets();
        receipt.receiptSize = bets.length;
        receipt.TotalOdd = betList.getTotalBettedOdd();
        receipt.totalStake = betList.getTotalBettedAmount();
        receipt.multipleBetAmount = Bet.multipleBetAmount;
        for (var i in bets)
        {
            var _betData = new BetData(),
                _bet = bets[i];
            _betData.matchId = _bet.matchId;
            _betData.betCategory = _bet.betCategory;
            _betData.optionId = _bet.optionId;
            _betData.odd = _bet.odd;
            _betData.betAmount = _bet.betAmount


            receipt.betData.push(_betData);

        }
        if (betList.getBets().length > 0) console.log(receipt);
        var url = "../Match/ReceiveReceipt";
        $.ajax({
            url: url,
            type: "POST",
            data: JSON.stringify(receipt),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        }).done(function(response) {
            var Message = response.message;

            if (Message == "Success") {
              
                $("#rcpTorderId").text(response.ReceiptNumber);
                $("#rcpTbarCode span.caption").text(response.FormatedSerial);
                $("#rcpTtimeOfBet").text(response.ReceiptTime);
                $("#rcpTbranch").text(response.BranchName);
                $("#rcpTteller").text(response.TellerName);
                $("#rcpTbarCode img").attr({
                    src: "../Content/Barcodes/" + response.Serial + ".png",
                    alt: response.Serial.toString()
                });
               // ReceiptNumber
               
                $("#tellerBalance").text("Teller Balance is Ugx " + response.Balance);
                var $receiptDiv = $("#rcpTreceiptTemplate");
                var receiptGen = new ReceiptGen();
                receiptGen.clearReceipt();
                receiptGen.generateReceipt(betList);
                // $receiptDiv.removeClass("hidden");

                $receiptDiv.print();
                $receiptDiv.addClass("hidden");


                diferred.resolve(response);

            } else {
                diferred.reject("Failed to submit the receipt with error message " + '""' + response.message + '""' + " contact your systems administrator ");

            }


        });

        return diferred.promise();
    };
}