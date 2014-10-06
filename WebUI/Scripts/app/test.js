else if (category === 'HT U/O') {
                    var oddHtUnder05 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 15);
                    var oddHtOver05 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 16);
                    var oddHtUnder15 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 17);
                    var oddHtOver15 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 18);
                    var oddHtUnder25 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 19);
                    var oddHtOver25 = getOddOptionInBetCategory(requiredOdds, item.MatchNo, 20);
                   
                   
                    if (typeof oddHtUnder05 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddHtUnder05.Odd).toFixed(2) + '" data-odd-type="' + oddHtUnder05.BetOptionId + '" data-option-id="' + oddHtUnder05.BetOptionId + '" data-option-name="' + oddHtUnder05.BetOption + '"  data-bet-category="' + oddHtUnder05.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddHtOver05 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddHtOver05.Odd).toFixed(2) + '" data-odd-type="' + oddHtOver05.BetOptionId + '" data-option-id="' + oddHtOver05.BetOptionId + '" data-option-name="' + oddHtOver05.BetOption + '"  data-bet-category="' + oddHtOver05.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddHtUnder15 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddHtUnder15.Odd).toFixed(2) + '" data-odd-type="' + oddHtUnder15.BetOptionId + '" data-option-id="' + oddHtUnder15.BetOptionId + '" data-option-name="' + oddHtUnder15.BetOption + '"  data-bet-category="' + oddHtUnder15.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddHtOver15 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddHtOver15.Odd).toFixed(2) + '" data-odd-type="' + oddHtOver15.BetOptionId + '" data-option-id="' + oddHtOver15.BetOptionId + '" data-option-name="' + oddHtOver15.BetOption + '"  data-bet-category="' + oddHtOver15.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddHtUnder25 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddHtUnder25.Odd).toFixed(2) + '" data-odd-type="' + oddHtUnder25.BetOptionId + '" data-option-id="' + oddHtUnder25.BetOptionId + '" data-option-name="' + oddHtUnder25.BetOption + '"  data-bet-category="' + oddHtUnder25.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    if (typeof oddHtOver25 !== 'undefined') {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="' + (oddHtOver25.Odd).toFixed(2) + '" data-odd-type="' + oddHtOver25.BetOptionId + '" data-option-id="' + oddHtOver25.BetOptionId + '" data-option-name="' + oddHtOver25.BetOption + '"  data-bet-category="' + oddHtOver25.BetCategory + '" /></td>';
                    } else {
                        htmlstring += '<td><input type="button" class="btn btn-default btn-xs odd" value="N/A" data-odd-type="" data-option-id="" data-option-name=""  data-bet-category="" disabled /></td>';
                    }
                    
                    htmlstring += '<td class="livebet"><input type="button" class="btn btn-primary btn-xs moreodds" value="+' + item.GameOdds.length + '" /></td></tr>';
                }
