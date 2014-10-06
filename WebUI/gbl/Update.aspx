<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" MasterPageFile="~/gbl/indexadmin.master" Inherits="WebUI.gbl.Update" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
     <script type="text/javascript">
         var httpObj = null;
         function feed() {
             document.getElementById("automessage").innerHTML = "updating games.";
             document.getElementById("note").style.display = "block";
             progress = true;
             httpObj = getHTTPObject();
             if (httpObj != null) {
                 httpObj.open("GET", "Tickets", true);
                 httpObj.send(null);
                 httpObj.onreadystatechange = done;
             }
         }

         function done() {
             if (httpObj.readyState == 4) {
                 document.getElementById("automessage").innerHTML = httpObj.responseText;
                 document.getElementById("note").style.display = "none";
                 progress = false;
             }
         }

         // Get the HTTP Object
         function getHTTPObject() {
             if (window.ActiveXObject) return new ActiveXObject("Microsoft.XMLHTTP");
             else if (window.XMLHttpRequest) return new XMLHttpRequest();
             else {
                 alert("Your browser does not support AJAX.");
                 return null;
             }
         }


         var anim = setInterval(function () { animation() }, 500);
         var c = 0;
         var progress = false;
         function animation() {
             if (progress) {
                 if (c == 0)
                     document.getElementById("automessage").innerHTML = "updating games";
                 else if (c == 1)
                     document.getElementById("automessage").innerHTML = "updating games.";
                 else if (c == 2)
                     document.getElementById("automessage").innerHTML = "updating games..";
                 else if (c == 3)
                     document.getElementById("automessage").innerHTML = "updating games...";
                 c++;
                 if (c > 3)
                     c = 0;
             }
         }
</script>

    <div style="width:650px;text-align:center;margin-left:auto;margin-right:auto;">
        <p style="width:100%;height:20px;background:#ABD31B;color:#fff;font-size:14px;">Auto Update Games | Set Number: <asp:Label ID="setno" ForeColor="Black"  runat="server"></asp:Label></p>
        <input type="button" id="autoupdate" value="Auto Update" class="link" onclick="feed()" />
        <asp:Label runat="server" ID="label" ForeColor="Black" Text="Click button to update games."></asp:Label><br />
        <p id="automessage" style="width:600px;height:auto;background:#D9EFEF;margin-left:auto;margin-right:auto;text-align:left;padding:5px;color:#7fba00;font-size:16px;">
            start...</p>
        <p id="note" style="width:600px;height:auto;background:#D9EFEF;margin-left:auto;margin-right:auto;text-align:left;padding:5px;display:none;">Note: Update may take several minutes</p>
    </div>

</asp:Content>


