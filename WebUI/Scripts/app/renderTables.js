function RenderTables(betListReff) {
    var self = this;
    var _betListReff = betListReff;
    var headerRowString = "";
    var headerrow = null;
    var $headerrowstatic = null;
    var games;
    var betUrl = window.location;
    // var path = betUrl.host + betUrl.pathname;
    this.startRenderingTables = function () {
        $.ajax({
            url: "../Games/Index",//betUrl,
            dataType: 'json',
            type: 'GET'
        }).done(function (data) {
            var originalData = data;
            games = [];

            $.each(originalData, function (index, item) {
                if (item.GameOdds.length > 0) {
                    games.push(item);
                }
            });
            console.log(games);
            var ft1X2Odds = getGameOddsByCategory("FT 1x2");

            // building the table - add header for normals
            $('#oddstable > thead').append('<tr></tr>');
            headerrow = $('#oddstable > thead').find('tr').eq(0);
            $headerrowstatic = $('#headersstable > thead').find('tr').eq(0);
            headerRowString = '' +
               '<th>Code</th>' +
               '<th>Time</th>' +
               '<th colspan="3" style="text-align: center;">Info</th>' +
               '<th><b>1</b></th>' +
               '<th><b>X</b></th>' +
               '<th><b>2</b></th>' +
               '<th><b>More</b></th>';
            // we can reuse this function to append the headerRows
            // appendHeaderRow(headerrow, headerRowString, true);
            appendHeaderRow(headerrow, $headerrowstatic, headerRowString);
            // headerrow.append();

            // add matches
            $.each(games, function (index, item) {
                var oddHome = getOddOptionInBetCategory(ft1X2Odds, item.MatchNo, 1);
                var oddDraw = getOddOptionInBetCategory(ft1X2Odds, item.MatchNo, 2);
                var oddAway = getOddOptionInBetCategory(ft1X2Odds, item.MatchNo, 3);
                var oddHomeClass = self.getMatchClassIfMatchIsSelected(item.MatchNo, oddHome.BetOption),
                    oddDrawClass = self.getMatchClassIfMatchIsSelected(item.MatchNo, oddDraw.BetOption),
                    oddAwayClass = self.getMatchClassIfMatchIsSelected(item.MatchNo, oddAway.BetOption);
                console.log(oddHomeClass + "     " + oddDrawClass + "    " + oddAwayClass);
                $('table#oddstable > tbody').append(
                    '<tr  class="match" id="' + item.MatchNo + '">' +
                        '<td  data-field="matchId" class="match-code">' + item.MatchNo + '</td>' +
                        '<td data-field="startTime" class="start-time">' + toJavaScriptDate(item.OldDateTime) + '</td>' +
                        '<td data-field="startDate" class="start-date hidden">' + item.StartTime + '</td>' +
                        '<td class="livebet"><span class="badge">Live</span></td>' +
                        '<td>1+</td>' +
                        '<td data-field="teamVersus" class="team-versus">' + item.HomeTeamName + ' vs ' + item.AwayTeamName + '</td>' +
                        '<td><input type="button" class="' + oddHomeClass + '" value="' + (oddHome.Odd).toFixed(2) + '" data-odd-type="' + oddHome.BetOptionId + '" data-option-id="' + oddHome.BetOptionId + '" data-option-name="' + oddHome.BetOption + '"  data-bet-category="' + oddHome.BetCategory + '" /></td>' +
                        '<td><input type="button" class="' + oddDrawClass + '" value="' + (oddDraw.Odd).toFixed(2) + '" data-odd-type="' + oddDraw.BetOptionId + '" data-option-id="' + oddDraw.BetOptionId + '" data-option-name="' + oddDraw.BetOption + '"  data-bet-category="' + oddDraw.BetCategory + '" /></td>' +
                        '<td><input type="button" class="' + oddAwayClass + '" value="' + (oddAway.Odd).toFixed(2) + '" data-odd-type="' + oddAway.BetOptionId + '" data-option-id="' + oddAway.BetoptionId + '" data-option-name="' + oddAway.BetOption + '"  data-bet-category="' + oddAway.BetCategory + '" /></td>' +
                        '<td class="livebet"><input type="button" class="btn btn-primary btn-xs moreodds" value="+' + item.GameOdds.length + '" /></td>' +
                        '</tr>');
            });
            var $headerrow1 = $('#oddstable > thead').find('tr').eq(0),
           $headerrowstatic1 = $('#headersstable > thead').find('tr').eq(0);
            appendHeaderRowSizes($headerrow1, $headerrowstatic1);
        });

        // Showing the different odds in the table -- takes in a particular odd category and alters the table
        $('.oddCategory').click(function () {
            var category = $(this).data('bet-category');
            $('#oddstable > thead').find('tr').eq(0).remove();
            $('#oddstable > tbody > tr').each(function () {
                $(this).remove();
            });

            $('#headersstable > thead').find('tr').eq(0).remove();
            //$('#headersstable > tbody > tr').each(function () {
            //    $(this).remove();
            //});

            // reconstruct it
            $('#oddstable > thead').append('<tr></tr>');
            $('#headersstable > thead').append('<tr></tr>');
            headerrow = $('#oddstable > thead').find('tr').eq(0);
            $headerrowstatic = $('#headersstable > thead').find('tr').eq(0);
            headerRowString = '' +
                '<th>Code</th>' +
                '<th>Time</th>' +
                '<th colspan="3" style="text-align: center;">Info</th>';
            appendHeaderRow(headerrow, $headerrowstatic, headerRowString);
            if (category === 'FT 1x2') {
                headerRowString = '' +
                    '<th><b>1</b></th>' +
                    '<th><b>x</b></th>' +
                    '<th><b>2</b></th>' +
                    '<th><b>More</b></th>';
                appendHeaderRow(headerrow, $headerrowstatic, headerRowString);
            } else if (category === 'FT U/O') {
                headerRowString = '' +
                    '<th colspan="2" style="text-align: center;"><b>0.5 <br />Under Over</b></th>' +
                    '<th colspan="2" style="text-align: center;"><b>1.5 <br />Under Over</b></b></th>' +
                    '<th colspan="2" style="text-align: center;"><b>2.5 <br />Under Over</b></b></th>' +
                    '<th colspan="2" style="text-align: center;"><b>3.5 <br />Under Over</b></b></th>' +
                    '<th colspan="2" style="text-align: center;"><b>4.5 <br />Under Over</b></b></th>' +
                    '<th colspan="2" style="text-align: center;"><b>5.5 <br />Under Over</b></b></th>' +
                    '<th><b>More</b></th>';
                appendHeaderRow(headerrow, $headerrowstatic, headerRowString);
            } else if (category === 'Double Chance') {
                headerRowString = '' +
                    '<th><b>1x</b></th>' +
                    '<th><b>12</b></th>' +
                    '<th><b>x2</b></th>' +
                    '<th><b>More</b></th>';
                appendHeaderRow(headerrow, $headerrowstatic, headerRowString);

            } else if (category === 'HT 1x2') {
                headerRowString = '' +
                    '<th><b>HT1</b></th>' +
                    '<th><b>HTX</b></th>' +
                    '<th><b>HT2</b></th>' +
                    '<th><b>More</b></th>';
                appendHeaderRow(headerrow, $headerrowstatic, headerRowString);

            } else if (category === 'Handicap') {
                headerRowString = '' +
                    '<th></th>' +
                    '<th><b>HC1</b></th>' +
                    '<th><b>HCX</b></th>' +
                    '<th><b>HC2</b></th>' +
                    '<th><b>More</b></th>';
                appendHeaderRow(headerrow, $headerrowstatic, headerRowString);
            } else if (category === 'Both Teams To Score') {
                headerRowString = '' +
                    '<th><b>GG</b></th>' +
                    '<th><b>NG</b></th>' +
                    '<th><b>More</b></th>';
                appendHeaderRow(headerrow, $headerrowstatic, headerRowString);

            }

            var requiredOdds = getGameOddsByCategory(category);
            console.log(requiredOdds);

            $.each(games, function (index, item) {

                var htmlstring = '<tr  class="match "id="' + item.MatchNo + '">' +
                    '<td data-field="matchId" class="match-code">' + item.MatchNo + '</td>' +
                    '<td data-field="startTime" class="start-time">' + toJavaScriptDate(item.OldDateTime) + '</td>' +
                    '<td data-field="startDate" class="start-date hidden">' + item.StartTime + '</td>' +
                    '<td class="livebet"><span class="badge">Live</span></td>' +
                    '<td>1+</td>' +
                    '<td data-field="teamVersus" class="team-versus">' + item.HomeTeamName + ' vs ' + item.AwayTeamName + '</td>';


                if (category === 'FT 1x2') {
                    var oddHome = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 1);
                    var oddDraw = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 2);
                    var oddAway = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 3);
                    var oddHomeClass = self.getMatchClassIfMatchIsSelected(item.MatchNo, oddHome.BetOption),
                        oddDrawClass = self.getMatchClassIfMatchIsSelected(item.MatchNo, oddDraw.BetOption),
                        oddAwayClass = self.getMatchClassIfMatchIsSelected(item.MatchNo, oddAway.BetOption);
                    console.log(oddHomeClass + "     " + oddDrawClass + "    " + oddAwayClass);
                    if (typeof oddHome === 'undefined' || typeof oddDraw === 'undefined' || typeof oddAway === 'undefined') {

                    } else {
                        htmlstring +=
                            '<td><input type="button" class="' + oddHomeClass + '" value="' + (oddHome.Odd).toFixed(2) + '" data-odd-type="' + oddHome.BetOptionId + '" data-option-id="' + oddHome.BetOptionId + '" data-option-name="' + oddHome.BetOption + '"  data-bet-category="' + oddHome.BetCategory + '" /></td>' +
                                '<td><input type="button" class="' + oddDrawClass + '" value="' + (oddDraw.Odd).toFixed(2) + '" data-odd-type="' + oddDraw.BetOptionId + '" data-option-id="' + oddDraw.BetOptionId + '" data-option-name="' + oddDraw.BetOption + '"  data-bet-category="' + oddDraw.BetCategory + '" /></td>' +
                                '<td><input type="button" class="' + oddAwayClass + '" value="' + (oddAway.Odd).toFixed(2) + '" data-odd-type="' + oddAway.BetOptionId + '" data-option-id="' + oddAway.BetOptionId + '" data-option-name="' + oddAway.BetOption + '"  data-bet-category="' + oddAway.BetCategory + '" /></td>' +
                                '<td class="livebet"><input type="button" class="btn btn-primary btn-xs moreodds" value="+' + item.GameOdds.length + '" /></td>' +
                                '</tr>';
                    }
                } else if (category === 'FT U/O') {
                    var oddFtUnder05 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 32);
                    var oddFtOver05 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 33);
                    var oddFtUnder15 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 4);
                    var oddFtOver15 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 5);
                    var oddFtUnder25 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 6);
                    var oddFtOver25 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 7);
                    var oddFtUnder35 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 8);
                    var oddFtOver35 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 9);
                    var oddFtUnder45 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 10);
                    var oddFtOver45 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 11);
                    var oddFtUnder55 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 34);
                    var oddFtOver55 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 35);
                    if (typeof oddFtUnder05 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddFtUnder05.Odd).toFixed(2) + '" data-odd-type="' + oddFtUnder05.BetOptionId + '" data-option-id="' + oddFtUnder05.BetOptionId + '" data-option-name="' + oddFtUnder05.BetOption + '"  data-bet-category="' + oddFtUnder05.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddFtOver05 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddFtOver05.Odd).toFixed(2) + '" data-odd-type="' + oddFtOver05.BetOptionId + '" data-option-id="' + oddFtOver05.BetOptionId + '" data-option-name="' + oddFtOver05.BetOption + '"  data-bet-category="' + oddFtOver05.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddFtUnder15 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddFtUnder15.Odd).toFixed(2) + '" data-odd-type="' + oddFtUnder15.BetOptionId + '" data-option-id="' + oddFtUnder15.BetOptionId + '" data-option-name="' + oddFtUnder15.BetOption + '"  data-bet-category="' + oddFtUnder15.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddFtOver15 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddFtOver15.Odd).toFixed(2) + '" data-odd-type="' + oddFtOver15.BetOptionId + '" data-option-id="' + oddFtOver15.BetOptionId + '" data-option-name="' + oddFtOver15.BetOption + '"  data-bet-category="' + oddFtOver15.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddFtUnder25 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddFtUnder25.Odd).toFixed(2) + '" data-odd-type="' + oddFtUnder25.BetOptionId + '" data-option-id="' + oddFtUnder25.BetOptionId + '" data-option-name="' + oddFtUnder25.BetOption + '"  data-bet-category="' + oddFtUnder25.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddFtOver25 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddFtOver25.Odd).toFixed(2) + '" data-odd-type="' + oddFtOver25.BetOptionId + '" data-option-id="' + oddFtOver25.BetOptionId + '" data-option-name="' + oddFtOver25.BetOption + '"  data-bet-category="' + oddFtOver25.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddFtUnder35 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddFtUnder35.Odd).toFixed(2) + '" data-odd-type="' + oddFtUnder35.BetOptionId + '" data-option-id="' + oddFtUnder35.BetOptionId + '" data-option-name="' + oddFtUnder35.BetOption + '"  data-bet-category="' + oddFtUnder35.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddFtOver35 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddFtOver35.Odd).toFixed(2) + '" data-odd-type="' + oddFtOver35.BetOptionId + '" data-option-id="' + oddFtOver35.BetOptionId + '" data-option-name="' + oddFtOver35.BetOption + '"  data-bet-category="' + oddFtOver35.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddFtUnder45 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddFtUnder45.Odd).toFixed(2) + '" data-odd-type="' + oddFtUnder45.BetOptionId + '" data-option-id="' + oddFtUnder45.BetOptionId + '" data-option-name="' + oddFtUnder45.BetOption + '"  data-bet-category="' + oddFtUnder45.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddFtOver45 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddFtOver45.Odd).toFixed(2) + '" data-odd-type="' + oddFtOver45.BetOptionId + '" data-option-id="' + oddFtOver45.BetOptionId + '" data-option-name="' + oddFtOver45.BetOption + '"  data-bet-category="' + oddFtOver45.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddFtUnder55 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddFtUnder55.Odd).toFixed(2) + '" data-odd-type="' + oddFtUnder55.BetOptionId + '" data-option-id="' + oddFtUnder55.BetOptionId + '" data-option-name="' + oddFtUnder55.BetOption + '"  data-bet-category="' + oddFtUnder55.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddFtOver55 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddFtOver55.Odd).toFixed(2) + '" data-odd-type="' + oddFtOver55.BetOptionId + '" data-option-id="' + oddFtOver55.BetOptionId + '" data-option-name="' + oddFtOver55.BetOption + '"  data-bet-category="' + oddFtOver55.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    htmlstring += '<td class="livebet"><input type="button" class="btn btn-primary btn-xs moreodds" value="+' + item.GameOdds.length + '" /></td></tr>';
                } else if (category === 'Double Chance') {
                    var oddDchd = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 21);
                    var oddDcha = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 22);
                    var oddDcda = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 23);
                    if (typeof oddDchd === 'undefined' || typeof oddDchd === 'undefined' || typeof oddDcda === 'undefined') {

                    } else {
                        htmlstring +=
                            '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddDchd.Odd).toFixed(2) + '" data-odd-type="' + oddDchd.BetOptionId + '" data-option-id="' + oddDchd.BetOptionId + '" data-option-name="' + oddDchd.BetOption + '"  data-bet-category="' + oddDchd.BetCategory + '" /></td>' +
                                '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddDcha.Odd).toFixed(2) + '" data-odd-type="' + oddDcha.BetOptionId + '" data-option-id="' + oddDcha.BetOptionId + '" data-option-name="' + oddDcha.BetOption + '"  data-bet-category="' + oddDcha.BetCategory + '" /></td>' +
                                '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddDcda.Odd).toFixed(2) + '" data-odd-type="' + oddDcda.BetOptionId + '" data-option-id="' + oddDcda.BetOptionId + '" data-option-name="' + oddDcda.BetOption + '"  data-bet-category="' + oddDcda.BetCategory + '" /></td>' +
                                '<td class="livebet"><input type="button" class="btn btn-primary btn-xs moreodds" value="+' + item.GameOdds.length + '" /></td>' +
                                '</tr>';
                    }
                } else if (category === 'HT 1x2') {
                    var oddht1 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 12);
                    var oddhtx = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 13);
                    var oddht2 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 14);
                    if (typeof oddht1 === 'undefined' || typeof oddhtx === 'undefined' || typeof oddht2 === 'undefined') {

                    } else {
                        htmlstring +=
                            '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddht1.Odd).toFixed(2) + '" data-odd-type="' + oddht1.BetOptionId + '" data-option-id="' + oddht1.BetOptionId + '" data-option-name="' + oddht1.BetOption + '"  data-bet-category="' + oddht1.BetCategory + '" /></td>' +
                                '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddhtx.Odd).toFixed(2) + '" data-odd-type="' + oddhtx.BetOptionId + '" data-option-id="' + oddhtx.BetOptionId + '" data-option-name="' + oddhtx.BetOption + '"  data-bet-category="' + oddhtx.BetCategory + '" /></td>' +
                                '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddht2.Odd).toFixed(2) + '" data-odd-type="' + oddht2.BetOptionId + '" data-option-id="' + oddht2.BetOptionId + '" data-option-name="' + oddht2.BetOption + '"  data-bet-category="' + oddht2.BetCategory + '" /></td>' +
                                '<td class="livebet"><input type="button" class="btn btn-primary btn-xs moreodds" value="+' + item.GameOdds.length + '" /></td>' +
                                '</tr>';
                    }
                } else if (category === 'Handicap') {
                    //console.log('Required Handicap Odds');
                    //console.log(requiredOdds);
                    var homegoals = 0, awaygoals = 0;
                    var oddhc1 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 24);
                    var oddhcx = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 31);
                    var oddhc2 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 25);
                    console.log(JSON.stringify(oddhc1) + ' ' + JSON.stringify(oddhcx) + ' ' + JSON.stringify(oddhc2));
                    if (typeof oddhc1 !== 'undefined') {
                        homegoals = oddhc1.HandicapGoals;
                    }
                    if (typeof oddhc2 !== 'undefined') {
                        awaygoals = oddhc2.HandicapGoals;
                    }

                    if (awaygoals == 0 && homegoals == 0) {
                        return;
                    } else {
                        htmlstring += '<td data-oddhc-home="' + homegoals + '" data-oddhc-away="' + awaygoals + '">' + homegoals + ':' + awaygoals + '</td>';
                        if (typeof oddhc1 !== 'undefined') {
                            htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddhc1.Odd).toFixed(2) + '" data-odd-type="' + oddhc1.BetOptionId + '" data-option-id="' + oddhc1.BetOptionId + '" data-option-name="' + oddhc1.BetOption + '"  data-bet-category="' + oddhc1.BetCategory + '" data-hc-homegoal="' + homegoals + '" data-hc-awaygoal="' + awaygoals + '" /></td>';
                        } else {
                            htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                        }
                        if (typeof oddhc2 !== 'undefined') {
                            htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddhcx.Odd).toFixed(2) + '" data-odd-type="' + oddhcx.BetOptionId + '" data-option-id="' + oddhcx.BetOptionId + '" data-option-name="' + oddhcx.BetOption + '"  data-bet-category="' + oddhcx.BetCategory + '" data-hc-homegoal="' + homegoals + '" data-hc-awaygoal="' + awaygoals + '"/></td>';
                        } else {
                            htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                        }
                        if (typeof oddhcx !== 'undefined') {
                            htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddhc2.Odd).toFixed(2) + '" data-odd-type="' + oddhc2.BetOptionId + '" data-option-id="' + oddhc2.BetOptionId + '" data-option-name="' + oddhc2.BetOption + '"  data-bet-category="' + oddhc2.BetCategory + '" data-hc-homegoal="' + homegoals + '" data-hc-awaygoal="' + awaygoals + '" /></td>';
                        } else {
                            htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                        }
                        htmlstring +=
                                '<td class="livebet"><input type="button" class="btn btn-primary btn-xs moreodds" value="N/A"  disabled/></td>' +
                                '</tr>';
                    }
                } else if (category === 'Both Teams To Score') {
                    var oddgg = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 26);
                    var oddng = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 27);
                    if (typeof oddgg === 'undefined' || typeof oddng === 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled/></td>' +
                              '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled/></td>' +
                              '<td class="livebet"><input type="button" class="btn btn-primary btn-xs moreodds" value="N/A" disabled/></td>' +
                              '</tr>';

                    } else {
                        htmlstring +=
                            '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddgg.Odd).toFixed(2) + '" data-odd-type="' + oddgg.BetOptionId + '" data-option-id="' + oddgg.BetOptionId + '" data-option-name="' + oddgg.BetOption + '"  data-bet-category="' + oddgg.BetCategory + '" /></td>' +
                                '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddng.Odd).toFixed(2) + '" data-odd-type="' + oddng.BetOptionId + '" data-option-id="' + oddng.BetOptionId + '" data-option-name="' + oddng.BetOption + '"  data-bet-category="' + oddng.BetCategory + '" /></td>' +
                                '<td class="livebet"><input type="button" class="btn btn-primary btn-xs moreodds" value="+' + item.GameOdds.length + '" /></td>' +
                                '</tr>';
                    }
                }
                $('table > tbody').append(htmlstring);
            });
            var $headerrow1 = $('#oddstable > thead').find('tr').eq(0),
                 $headerrowstatic1 = $('#headersstable > thead').find('tr').eq(0);
            appendHeaderRowSizes($headerrow1, $headerrowstatic1);
        });
    };
    var logToconsole = function (data) { console.log(data); };
    function getGameOddsByCategory(category) {
        var gameOdds = [];
        $.each(games, function (index, item) {
            $.each(item.GameOdds, function (key, value) {
                if (value.BetCategory === category) {
                    var gameodd =
                    {
                        BetCategory: value.BetCategory,
                        BetOptionId: value.BetOptionId,
                        BetOption: value.BetOption,
                        LastUpdateTime: value.LastUpdateTime,
                        Odd: (typeof value.Odd === 'undefined') ? 0 : value.Odd,
                        MatchNo: item.MatchNo,
                        HandicapGoals: (typeof value.HandicapGoals === 'undefined') ? 0 : value.HandicapGoals
                    };
                    gameOdds.push(gameodd);
                }
            });
        });
        return gameOdds;
    }

    function getOddOptionInBetCategory(gameOdds, matchno, requiredOption) {
        var gameodd;
        $.each(gameOdds, function (key, value) {
            if (value.MatchNo == matchno && value.BetOptionId == requiredOption) {
                gameodd = {
                    BetCategory: value.BetCategory,
                    BetOptionId: value.BetOptionId,
                    BetOption: value.BetOption,
                    Odd: (typeof value.Odd === 'undefined') ? 0 : value.Odd,
                    MatchNo: value.MatchNo,
                    HandicapGoals: (typeof value.HandicapGoals === 'undefined') ? 0 : value.HandicapGoals
                };
            }
        });
        return gameodd;
    }

    function toJavaScriptDate(value) {
        var pattern = /Date\(([^)]+)\)/;
        var results = pattern.exec(value);
        var dt = new Date(parseFloat(results[1]));
        var hours = (dt.getHours() < 10) ? '0' + dt.getHours() : dt.getHours();
        var mins = (dt.getMinutes() < 10) ? '0' + dt.getMinutes() : dt.getMinutes();
        return (hours + ':' + mins);
    }

    function appendHeaderRow($headerRow, $headerRowStatic, strheaderRowString) {

        $headerRow.append(strheaderRowString);
        var thWidths = [];
        var arrIndex = 0;

        $("th", $headerRow).each(function () {
            // alert("hit");
            var width = 0;
            var $that = $(this);
            width = $that.css("width");
            thWidths.push(width);
            // alert(width);
        });
        var _$headerRowStatic = $headerRowStatic;
        $("th", _$headerRowStatic).each(function () {
            var $that = $(this);
            //alert(thWidths[arrIndex]);
            $that.width(thWidths[arrIndex]);
            // alert( arrIndex);
            arrIndex++;
        });
        _$headerRowStatic.append(strheaderRowString);

    }


    function appendHeaderRowSizes($headerRow, $headerRowStatic) {

        // $headerRow.append(strheaderRowString);
        var thWidths = [];
        var arrIndex = 0;

        $("th", $headerRow).each(function () {
            // alert("hit");
            var width = 0;
            var $that = $(this);
            width = $that.css("width");
            thWidths.push(width);
            // alert(width);
        });
        var _$headerRowStatic = $headerRowStatic;
        $("th", _$headerRowStatic).each(function () {
            var $that1 = $(this);
            //alert(thWidths[arrIndex]);
            $that1.css("width", thWidths[arrIndex]);
            // alert( arrIndex);
            arrIndex++;
        });
    };

    this.getMatchClassIfMatchIsSelected = function (matchCode, optionName) {
        //console.log(_betListReff.getBets());


        var classString = null;
        var res = _betListReff.getBetByOptionNameAndMatchId($.trim(matchCode), optionName);
        console.log(res);
        if (res == true) {

            classString = "btn btn-default btn-xs odd selected_option";
        } else {

            classString = "btn btn-default btn-xs odd not_selected_option";
        }
        return classString.toString();
    };


    //function toJavaScriptFullDate(value) {
    //    var pattern = /Date\(([^)]+)\)/;
    //    var results = pattern.exec(value);
    //    var dt = new Date(parseFloat(results[1]));
    //    var day, month, year;
    //    day = dt.getDay();
    //    console.log(day);
    //    month = dt.getMonth();
    //    console.log(month);
    //    year = dt.getFullYear();
    //    console.log(year);
    //    if (parseInt(day) < 10) {
    //        day = "0" + day;
    //    }
    //    if (parseInt(month) < 10) {
    //        month = "0" + month;
    //    }
    //    var date = day + "/" + month + "/" + year;
    //    console.log(date);
    //    return date;
    //}
};

