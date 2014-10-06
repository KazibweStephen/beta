using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
 
public static class XmlHelper
{
 
    public static XmlNamespaceManager GetXmlNameSpaceManager(XPathNavigator xpn)
    {
        xpn.MoveToFollowing(XPathNodeType.Element);
 
        XmlNamespaceManager xmlnsm = new XmlNamespaceManager(xpn.NameTable);
        xmlnsm.AddNamespace("x", xpn.NamespaceURI);
 
        foreach (KeyValuePair<string, string> xns in xpn.GetNamespacesInScope(XmlNamespaceScope.All))
            xmlnsm.AddNamespace(xns.Key, xns.Value);
 
        return xmlnsm;
    }
 
}


/**


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Score.aspx.cs" Inherits="Score" %>
<%@ OutputCache Duration="3600" VaryByParam="none" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 
        <h1>My RSS Feed</h1>
	
		<asp:Repeater ID="rptRssFeed" OnItemDataBound="rptRssFeed_ItemDataBound" runat="server">
			
			<ItemTemplate>
				<div>
				
					 <h3><asp:Literal ID="litTitle" runat="server" /></h3>
					<asp:Literal ID="litDescription" runat="server" /><br />
					<asp:HyperLink ID="hypLink" Text="View" runat="server" />
				</div>
			</ItemTemplate>
			<SeparatorTemplate>
				<hr />
			</SeparatorTemplate>
		</asp:Repeater>
 
    </div>
    </form>
</body>
</html>

*/


/**


using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Xml;
using System.Xml.XPath;
 
public partial class Score : System.Web.UI.Page
{
 
    private string _feedUrl = "F:\\gbeal\\template046\\feed.xml";
 
    private XmlNamespaceManager _xmlnsm;
 
    protected void Page_Init(object sender, EventArgs e)
    {
        XPathNavigator xpn = new XPathDocument(_feedUrl).CreateNavigator();
        _xmlnsm = XmlHelper.GetXmlNameSpaceManager(xpn);
 
        rptRssFeed.DataSource = xpn.Select("/x:rss/x:channel/x:item", _xmlnsm);
        rptRssFeed.DataBind();
    }
 
    protected void rptRssFeed_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    {
        XPathNavigator xpn = (XPathNavigator)e.Item.DataItem;
        Literal litTitle = (Literal)e.Item.FindControl("litTitle");
        Literal litDescription = (Literal)e.Item.FindControl("litDescription");
        HyperLink hypLink = (HyperLink)e.Item.FindControl("hypLink");
 
        litTitle.Text = xpn.SelectSingleNode("x:localteam:name", _xmlnsm).Value;
        litDescription.Text = xpn.SelectSingleNode("x:localteam:name", _xmlnsm).Value;
        hypLink.NavigateUrl = xpn.SelectSingleNode("x:visitorteam:name", _xmlnsm).Value;
    }
    }
 
}













*/