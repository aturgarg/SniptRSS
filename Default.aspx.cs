using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //static IList<object> mPostList = new List<object>();    
  
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnFetchRssFeed_OnClick(object sender, EventArgs e)
    {
        try
        {
            XDocument xDocFeeds = XDocument.Load(txtUrl.Text.Trim());
            xDocFeeds = XDocument.Parse(xDocFeeds.ToString().Replace("snipt:tags>", "tags>"),LoadOptions.PreserveWhitespace);
            this.ReadXML(xDocFeeds);
        }
        catch (Exception ex)
        {
            //txtFeeds.Text = ex.Message;
        }
    }

    private void ReadXML(XDocument xFeeds)
    {
        XNamespace sniptsTags = "http://snipt.net/api/tags.xml";

        var posts = from item in xFeeds.Descendants("item")
                    select new
                    {
                        Title = item.Element("title").Value,
                        Published = DateTime.Parse(item.Element("pubDate").Value),
                        Url = item.Element("link").Value,
                        //Tags = item.Element(sniptsTags+ "tags").Value,
                        Tags = item.Element("tags").Value.Split(' ').ToArray(),
                        Guid = item.Element("guid").Value,
                        Description = item.Element("description").Value
                    };

        //mPostList.Clear();
        foreach (var item in posts)
        {
            //mPostList.Add((object)item);
        }

        //mPostList = (List<object>)posts;
        
        ListView1.DataSource = posts;
        //ListView1.DataSource = mPostList;
        ListView1.DataBind();

    }

    protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //var item = ListView1.SelectedValue;
        
        //
    }

    protected void ListView1_OnSelectedIndexChanging(object sender, ListViewSelectEventArgs  e)
    {
        if(e.NewSelectedIndex > -1)
        {
            txtDescription.InnerHtml = ListView1.DataKeys[e.NewSelectedIndex].Values["Description"].ToString();
        }
    }

    protected void ListView1_OnItemCommand(object source, ListViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            //int rowIndex = ((ListViewDataItem)e.Item).DisplayIndex;
            //object selectedObj = mPostList[rowIndex];            
        }
    }
}

/*
 <asp:Repeater ID="Repeater1" DataSource='<%#Eval("Tags") %>' runat="server">
                        <ItemTemplate> <%#Container.DataItem %> </ItemTemplate>
                        <SeparatorTemplate>,</SeparatorTemplate>
                    </asp:Repeater>
 * 
 * <%#Eval("Tags") %>
 * 
 * http://snipt.net/aturgarg/feed
 * 
 * http://snipt.net/api/users/aturgarg.xml
 * 
 * http://snipt.net/api/snipts/14983.xml?style=autumn
 * 
 * 
*/