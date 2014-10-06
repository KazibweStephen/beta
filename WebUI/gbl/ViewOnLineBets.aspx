<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOnLineBets.aspx.cs" MasterPageFile="~/gbl/indexadmin.master" Inherits="NewBet.gbl.ViewOnLineBets" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <head />
    <script language="javascript" type="text/javascript">
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);
            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "../images/delete-item.gif";
            } else {
                div.style.display = "none";
                img.src = "../images/add-item.gif";
            }
        }
    </script>

    <script src="Scripts/ScrollableGridPlugin.js" type="text/javascript"></script>
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/jquery.dimensions.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.8.2.js" type="text/javascript"></script>
   
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div style="text-align: left; width: 100%; font-weight: bold; font-size: 20px; font-family: 'Segoe UI';" class="header">
                Online Bets
            </div>
           <br />
            <asp:Label runat="server" ID="status" Text="" CssClass="status"></asp:Label>
            <asp:Label runat="server" ID="currentDate" Text="" CssClass="currentdate"></asp:Label>
            <asp:Button runat="server" ID="today" OnClientClick="loadingNow()" OnClick="today_Click" CssClass="link floatright" Text="Today"></asp:Button>
            <img id="loading" src="../images/loader.gif" style="float: right; display: none; position: relative; left: -20px;" />
            <asp:Panel runat="server" ID="filter">
                <div id="navigate">
                    NAVIGATION: &nbsp;&nbsp;&nbsp;&nbsp;
                From
                <asp:DropDownList ID="startDay" OnSelectedIndexChanged="startDay_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="startMonth" OnSelectedIndexChanged="startMonth_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="startYear" OnSelectedIndexChanged="startYear_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    To
                <asp:DropDownList ID="endDay" runat="server" OnSelectedIndexChanged="endDay_SelectedIndexChanged"></asp:DropDownList>
                    <asp:DropDownList ID="endMonth" OnSelectedIndexChanged="endMonth_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="endYear" runat="server" OnSelectedIndexChanged="endYear_SelectedIndexChanged"></asp:DropDownList>
                    <asp:Button runat="server" OnClientClick="loadingNow()" ID="navigateByDate" Text="GO" OnClick="navigateByDate_Click" CssClass="go" />
                    <asp:Button runat="server" OnClientClick="loadingNow()" ID="previusDay" OnClick="previusDay_Click" Text="<<" CssClass="go" />
                    <asp:Button runat="server" OnClientClick="loadingNow()" ID="nextDay" OnClick="nextDay_Click" Text=">>" CssClass="go" />
                    <div class="search">
                        <asp:Label ID="Label2" runat="server" Text="Search"></asp:Label><asp:TextBox runat="server" ID="searchtext" Width="90px"></asp:TextBox>
                        <asp:Button runat="server" ID="search" OnClientClick="loadingNow()" Text="GO" OnClick="search_Click" CssClass="go" />
                    </div>
                </div>
            </asp:Panel>
            <h3><b style="position: relative;"></b>Pending Bets:
                <asp:Label runat="server" ID="smscount" CssClass="bignum"></asp:Label></h3>
            <div style="width: 100%; height: 700px; margin: 0px; position: relative; top: -1px; overflow: auto; overflow-x: hidden; border: none;">

                <asp:GridView ID="gvParentGrid" runat="server" DataKeyNames="betid" Width="99%" HorizontalAlign="Left" OnPageIndexChanging="gvParentGrid_PageIndexChanging"
                    AutoGenerateColumns="False" OnRowDataBound="gvUserInfo_RowDataBound" PageSize="30" AllowPaging="true"
                    GridLines="Horizontal" BorderStyle="Solid" BorderColor="#f2f2f2" BorderWidth="1px" >
                    <PagerStyle CssClass="pager" />
                    <HeaderStyle CssClass="header" Height="30px" BorderWidth="1px" BorderStyle="Solid" />
                    <RowStyle CssClass="gridrow" Height="25px" />
                    <AlternatingRowStyle CssClass="gridrow_alt" Height="25px" />
                    <PagerSettings Position="TopAndBottom" Mode="NextPreviousFirstLast" FirstPageImageUrl="../images/top.png" LastPageImageUrl="../images/bottom.png" NextPageImageUrl="../images/next.png" PreviousPageImageUrl="../images/prev.png" />
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="40px">
                            <ItemTemplate>
                                <a href="JavaScript:divexpandcollapse('div<%# Eval("betid") %>');" class="gridViewToolTip"><%# Container.DataItemIndex + 1 %> </a>
                                <a href="JavaScript:divexpandcollapse('div<%# Eval("betid") %>');" class="gridViewToolTip">
                                    <img id='imgdiv<%# Eval("betid") %>' width="20px" border="0" src="../images/add-item.gif" />
                                </a>
                            </ItemTemplate>
                            <ItemStyle Width="40px"></ItemStyle>
                        </asp:TemplateField>

                        <asp:BoundField DataField="betid" HeaderText="BetId" ItemStyle-Width="80px"
                            HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="username" HeaderText="Username" ItemStyle-Width="120px"
                            HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="betmoney" HeaderText="betmoney" ItemStyle-Width="80px"
                            HeaderStyle-HorizontalAlign="center">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="setodd" HeaderText="Totalodd" DataFormatString="{0:0.0}"
                            HeaderStyle-HorizontalAlign="center">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="nos" HeaderText="setsize"
                            HeaderStyle-HorizontalAlign="center">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="bdate" HeaderText="BetDate"
                            HeaderStyle-HorizontalAlign="center">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Set status">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstname" Text='<%# getstatus(Eval("status").ToString(),Eval("setodd").ToString(),Eval("betmoney").ToString()) %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="% Reciept Prediction">
                            <ItemTemplate>
                                <table runat="server" id="tblBar" style="background:#7D9ACE;">
                                    <tr >
                                        <td><asp:Label ID="lblPrediction" Text='<%# getPrediction(Eval("betid").ToString(),Eval("nos").ToString()) %>' runat="server" /></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField>
                            <ItemTemplate>
                                <tr>
                                    <td colspan="100%">
                                        <div id='div<%# Eval("betid") %>' style="display: none; position: relative; left: 15px; overflow: auto">
                                            <asp:GridView ID="gvChildGrid" OnRowDataBound="childbind" runat="server" CssClass="grid" AutoGenerateColumns="false" BorderStyle="Double" GridLines="Vertical" Width="98%">
                                                <PagerStyle CssClass="pager" />
                                                <HeaderStyle CssClass="header" Height="30px" />
                                                <RowStyle CssClass="gridrow" Height="25px" />
                                                <AlternatingRowStyle CssClass="gridrow_alt" Height="25px" />
                                                <PagerSettings Position="TopAndBottom" />
                                                <Columns>
                                                    <asp:BoundField DataField="MatchNo" HeaderText="Match no" HeaderStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="bet_type" HeaderText="Bettype" HeaderStyle-HorizontalAlign="Left" />

                                                    <asp:BoundField DataField="host" HeaderText="Home" HeaderStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Scores" HeaderText="Scores" />
                                                    <asp:BoundField DataField="visitor" HeaderText="Away" HeaderStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="oddname" HeaderText="Choice" />
                                                    <asp:BoundField DataField="oddhome" HeaderText="Odd" />
                                                    <asp:BoundField DataField="StartTime" HeaderText="Match Time" HeaderStyle-HorizontalAlign="Left" HtmlEncode="false" DataFormatString="{0:dd MMM hh:mm tt}" />
                                                    <asp:TemplateField HeaderText="Prediction">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtPredicted" Text='<%# getpredictions(Convert.ToString(Eval("oddname")),Convert.ToString(Eval("NormalPrediction")),Convert.ToString(Eval("WirePrediction")),Convert.ToString(Eval("bet_type"))) %>' runat="server"></asp:Label>
                                                            <asp:ImageButton ID="imgbtn" runat="server" Height="15px" Width="15px" ImageUrl='<%# getphoto(Convert.ToString(Eval("oddname")),Convert.ToString(Eval("NormalPrediction")),Convert.ToString(Eval("wirePrediction")),Convert.ToString(Eval("bet_type"))) %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>

            </div>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>


