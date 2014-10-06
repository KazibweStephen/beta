function RenderTables() {
    var isnormal = false;
    var games;
    var matches = [];
    this.startRenderingTables = function () {
        $.ajax({
            url: 'Index',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            type: 'GET'
        }).done(function (data) {
            var inmatchcodes = [];
            // original data from the server
            games = data;
            console.log(games);
            //single out unique games
            $.each(data, function (index, item) {
                inmatchcodes.push(item.MatchNo);
            });

            console.log(JSON.stringify(inmatchcodes));
            var matchcodes = $.unique(inmatchcodes.sort());
            console.log(JSON.stringify(matchcodes));

            $.each(matchcodes, function (index, item) {
                var match =
                {
                    matchcode: item,
                    odds: []
                };
                matches.push(match);
                $.each(games, function (key, value) {
                    if (value.MatchNo == match.matchcode) {
                        match.setno = value.SetNo;
                        match.starttime = value.StartTime;
                        match.hometeamid = value.HomeTeamId;
                        match.hometeamname = value.HomeTeamName;
                        match.homescore = value.HomeScore;
                        match.halftimehomescore = value.HalfTimeHomeScore;
                        match.awayteamid = value.AwayTeamId;
                        match.awayteamname = value.AwayTeamName;
                        match.awayscore = value.AwayScore;
                        match.halftimeawayscore = value.HalfTimeAwayScore;
                        var odd =
                        {
                            option: value.Option,
                            optionName: value.OptionName,
                            category: value.Category,
                            categoryid: value.CategoryId,
                            oddvalue: value.Odd
                        };
                        match.odds.push(odd);
                    }
                });

            });

            // testing for match data
            $.each(matches, function (index, item) {
                console.log('\n' + JSON.stringify(item.odds));
            });

            // building the table - add header for normals
            var headerrow = $('table > thead').find('tr').eq(0);
            headerrow.append('' +
                '<th><b>1</b></th>' +
                '<th><b>x</b></th>' +
                '<th><b>2</b></th>' +
                '<th><b>More</b></th>');

            // add matches
            $.each(matches, function (index, item) {
                $('table.oddstable > tbody').append(
                    '<tr class="match" id="' + item.matchcode + '">' +
                        '<td  data-field="matchId" class="match-code">' + item.matchcode + '</td>' +
                        '<td data-field="startTime" class="start-time">' + ToJavaScriptDate(item.starttime) + '</td>' +
                        '<td data-field="startDate" class="start-date hidden">' + ToJavaScriptFullDate(item.starttime) + '</td>' +
                        '<td class="livebet"><span class="badge">Live</span></td>' +
                        '<td>1+</td>' +
                        '<td data-field="teamVersus" class="team-versus">' + item.hometeamname + ' vs ' + item.awayteamname + '</td>' +
                        '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (item.odds[0].oddvalue).toFixed(2) + '" data-option-id="' + item.odds[0].option + '" data-option-name="' + item.odds[0].optionName + '"  data-bet-category="' + item.odds[0].category + '" /></td>' +
                        '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (item.odds[1].oddvalue).toFixed(2) + '" data-option-id="' + item.odds[1].option + '" data-option-name="' + item.odds[1].optionName + '"   data-bet-category="' + item.odds[1].category + '"/></td>' +
                        '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (item.odds[2].oddvalue).toFixed(2) + '" data-option-id="' + item.odds[2].option + '" data-option-name="' + item.odds[2].optionName + '"   data-bet-category="' + item.odds[2].category + '"/></td>' +
                        '<td class="livebet"><input type="button" class="btn btn-primary btn-xs moreodds" value="+' + item.odds.length + '" /></td>' +
                        '</tr>');
            });

            isnormal = true;
        });

        //$('table').delegate('.odd', 'click', function () {
        //    var odd = $(this).val();
        //    var optionName = $(this).data('option-name');
        //    var rowIndex = $(this).parent().parent().index('tr');
        //    var columnIndex = $(this).parent().index('tr:eq(' + rowIndex + ') td');
        //    var betCategory = $(this).data("bet-category");
        //    alert(optionName);
        //    alert('Row Index: ' + rowIndex + ', Column Index: ' + columnIndex + ', Odd: ' + odd + ',optionName: ' + optionName + ',betCategory: ' + betCategory);
        //});

        $('#morebtn').click(function () {
            if (isnormal) {
                //alert('attempting to view more odds');
                $('table > thead').find('tr').eq(0).find('th:last').remove();
                $('table > tbody > tr').each(function (n) {
                    $(this).find('td:last').remove();
                });

                // add the categories
                $('table > thead').find('tr').eq(0).append('' +
                    '<th colspan="2" style="padding-left: 5px;">Under 2.5 Over </th>' +
                    '<th style="padding-left: 5px;">1x</th><th>12</th><th>x2</th><th>More</th>');

                $('table > tbody > tr').each(function () {
                    var matchcode = $(this).attr('id');

                    var match = getMatchByCode(matchcode);

                    $(this).append('' +
                        '<td style="padding-left: 5px;"><input type="button" class="btn btn-default btn-xs odd" value="' + (match.odds[4].oddvalue).toFixed(2) + '"data-option-id="' + match.odds[4].option + '" data-option-name="' + match.odds[4].optionName + '"  data-bet-category="' + match.odds[4].category + '"  /></td>' +
                        '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (match.odds[5].oddvalue).toFixed(2) + '" data-option-id="' + match.odds[5].option + '" data-option-name="' + match.odds[5].optionName + '" data-bet-category="' + match.odds[5].category + '"/></td>' +
                        '<td style="padding-left: 5px;"><input type="button" class="btn btn-default btn-xs odd" value="' + (match.odds[6].oddvalue).toFixed(2) + '" data-option-id="' + match.odds[6].option + '" data-option-name="' + match.odds[6].optionName + '" data-bet-category="' + match.odds[6].category + '"/></td>' +
                        '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (match.odds[7].oddvalue).toFixed(2) + '" data-option-id="' + match.odds[7].option + '" data-option-name="' + match.odds[7].optionName + '" data-bet-category="' + match.odds[7].category + '"/></td>' +
                        '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (match.odds[3].oddvalue).toFixed(2) + '" data-option-id="' + match.odds[3].option + '" data-option-name="' + match.odds[3].optionName + '" data-bet-category="' + match.odds[3].category + '"/></td>' +
                        '<td class="livebet"><input type="button" class="btn btn-primary btn-xs moreodds" value="+' + match.odds.length + '" /></td>');
                });

                // change the text
                $('#morebtn').val('<< Less');
                isnormal = false;
            } else {
                for (var i = 0; i < 5; i++) {
                    $('table > thead').find('tr').eq(0).find('th:last').remove();
                }

                for (var j = 0; j < 6; j++) {
                    $('table > tbody > tr').each(function (n) {
                        $(this).find('td:last').remove();
                    });
                }

                $('table > thead').find('tr').eq(0).append('<th>More</th>');
                $('table > tbody > tr').each(function () {
                    var matchcode = $(this).attr('id');
                    var match = getMatchByCode(matchcode);
                    $(this).append('<td class="livebet"><input type="button" class="btn btn-primary btn-xs moreodds" value="+' + match.odds.length + '" /></td>');
                });
                $('#morebtn').val('More >>');
                isnormal = true;
            }
        });
    };

    function ToJavaScriptDate(value) {
        var pattern = /Date\(([^)]+)\)/;
        var results = pattern.exec(value);
        var dt = new Date(parseFloat(results[1]));
        if (dt.getHours < 12) {
            return (dt.getHours() + ':' + dt.getMinutes() + ' AM');
        } else {
            return (dt.getHours() - 12 + ':' + dt.getMinutes() + ' PM');
        }
    }
    function ToJavaScriptFullDate(value) {
        var pattern = /Date\(([^)]+)\)/;
        var results = pattern.exec(value);
        var dt = new Date(parseFloat(results[1]));
        var day = null, month = null, year = null;
        day = dt.getDay();
        month = dt.getMonth();
        year = dt.getFullYear();
        if (parseInt(day) < 10) {
            day = "0" + day;

        }
        if (parseInt(month) < 10) {
            month = "0" + month;
        }
        var date = day+"/"+month+"/"+year;
        return date;
        
    }

    function getMatchByCode(code) {
        var match = null;
        for (var i = 0; i < matches.length; i++) {
            if (matches[i].matchcode == code) {
                match = matches[i];
            }
        }
        return match;
    }

    //function getValueOfBetOption(betoption) {
    //    var value;
    //    for(var i = 0; i< matches.length)
    //}

}