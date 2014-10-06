using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnhancedWebControls
{
    /// <summary>
    /// Enhanced version of the GridView control. 
    /// Supports: Column sort direction images, row selecting/highlighting, prev/numeric/next paging.
    /// </summary>
    [DefaultProperty("SelectedValue")]
    [ToolboxData("<{0}:GridView runat=server></{0}:GridView>")]
    public class EGridView : System.Web.UI.WebControls.GridView
    {
        /// <summary>
        /// Color of the row being hovered over.
        /// </summary>
        public string HighlightColor
        {
            get
            {
                if (ViewState["highlightColor"] == null)
                {
                    ViewState["highlightColor"] = false;
                }
                return (string)ViewState["highlightColor"];
            }

            set
            {
                ViewState["highlightColor"] = value;
            }
        }

        /// <summary>
        /// Turns the selection highlighting on or off.
        /// </summary>
        public bool EnableSelection
        {
            get
            {
                if (ViewState["enableSelection"] == null)
                {
                    ViewState["enableSelection"] = false;
                }
                return (bool)ViewState["enableSelection"];
            }

            set
            {
                ViewState["enableSelection"] = value;
            }
        }

        /// <summary>
        /// Turns on JustinsWeb sanctioned pager.
        /// </summary>
        public bool EnableNextPrevNumericPager
        {
            get
            {
                if (ViewState["enableJustinsWebPager"] == null)
                {
                    ViewState["enableJustinsWebPager"] = false;
                }
                return (bool)ViewState["enableJustinsWebPager"];
            }

            set
            {
                this.AllowPaging = value;
                ViewState["enableJustinsWebPager"] = value;
            }
        }

        /// <summary>
        /// Get/Set alternative to the inherited SortDirection field that is always accurate.
        /// </summary>
        public SortDirection SortDirectionAlt
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                {
                    ViewState["sortDirection"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["sortDirection"];
            }

            set
            {
                ViewState["sortDirection"] = value;
            }
        }

        /// <summary>
        /// Get/Set alternative to the inherited SortExpression field that is always accurate.
        /// </summary>
        public string SortExpressionAlt
        {
            get
            {
                if (ViewState["sortExpressionAlt"] == null)
                {
                    ViewState["sortExpressionAlt"] = "";
                }
                return (string)ViewState["sortExpressionAlt"];
            }

            set
            {
                ViewState["sortExpressionAlt"] = value;
            }
        }

        /// <summary>
        /// When using GridView in certain ways the SortDirection and SortExpression
        /// properties are sometimes left blank or never changed. When using this control,
        /// the Alt properties remedy this situation.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSorting(GridViewSortEventArgs e)
        {
            //Handle setting up of sorting info 
            if (!String.IsNullOrEmpty(this.SortExpression))
            {
                SortExpressionAlt = e.SortExpression;
                SortDirectionAlt = e.SortDirection;
            }
            else
            {
                if (SortExpressionAlt == e.SortExpression)
                {
                    if (SortDirectionAlt == SortDirection.Ascending)
                    {
                        SortDirectionAlt = SortDirection.Descending;
                    }
                    else
                    {
                        SortDirectionAlt = SortDirection.Ascending;
                    }
                }
                else
                {
                    SortDirectionAlt = SortDirection.Ascending;
                }

                this.SortExpressionAlt = e.SortExpression;
            }

            base.OnSorting(e);
        }


        protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            if (this.EnableNextPrevNumericPager)
            {
                base.PagerTemplate = new NextPrevNumericPagerTemplate(this.PageIndex, this.PageCount);
            }
            base.InitializePager(row, columnSpan, pagedDataSource);
        }

        /// <summary>
        /// Adds custom effects to the GridView at runtime.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRowCreated(GridViewRowEventArgs e)
        {
            base.OnRowCreated(e);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //If row selection is enabled then add mouse over scripts to enable on client.
                if (EnableSelection)
                {
                    EnableEnhancedSelectForRow(e);
                }
            }
            else if (e.Row.RowType == DataControlRowType.Header && ShowSortDirection)
            {
                //this.SortDirection
                foreach (TableCell headerCell in e.Row.Cells)
                {
                    if (headerCell.HasControls())
                    {
                        AddSortImageToHeaderCell(headerCell);
                    }
                }
            }
        }

        private void AddSortImageToHeaderCell(TableCell headerCell)
        {
            // search for the header link
            LinkButton lnk = (LinkButton)headerCell.Controls[0];
            if (lnk != null)
            {
                // inizialize a new image
                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                // setting the dynamically URL of the image
                img.ImageUrl = (this.SortDirectionAlt == SortDirection.Ascending ? this.SortAscImageUrl : this.SortDescImageUrl);
                // checking if the header link is the user's choice
                if (this.SortExpressionAlt == lnk.CommandArgument)
                {
                    // adding a space and the image to the header link
                    headerCell.Controls.Add(new LiteralControl(" "));
                    headerCell.Controls.Add(img);
                }
            }
        }

        private void EnableEnhancedSelectForRow(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", RowOnMouseOverScript());
            e.Row.Attributes.Add("onmouseout", RowOnMouseOutScript());

            foreach (TableCell cell in e.Row.Cells)
            {
                // if no link are presen the cell,
                // we add the functionnality to select the row on the cell with a click
                if (!Recurser.ContainsLink(cell))
                {
                    AddPostBackEventToCell(e, cell);
                }
            }
        }

        private void AddPostBackEventToCell(GridViewRowEventArgs e, TableCell cell)
        {
            // here we add the command to postback when the user click somewhere in the cell
            cell.Attributes.Add("onclick",
                Page.ClientScript.GetPostBackEventReference(this,
                "Select$" + e.Row.RowIndex.ToString()));
            cell.Style.Add(HtmlTextWriterStyle.Cursor, "pointer");
            cell.Attributes.Add("title", "Select");
        }

        /// <summary>
        /// Get or Set Image location to be used to display Ascending Sort order.
        /// </summary>
        [
        Description("Image to display for Ascending Sort"),
        Category("Misc"),
        Editor("System.Web.UI.Design.UrlEditor", typeof(System.Drawing.Design.UITypeEditor)),
        DefaultValue(""),
        ]
        public string SortAscImageUrl
        {
            get
            {
                object o = ViewState["SortImageAsc"];
                return (o != null ? o.ToString() : "");
            }
            set
            {
                ViewState["SortImageAsc"] = value;
            }
        }


        /// <summary>
        /// Get or Set Image location to be used to display Ascending Sort order.
        /// </summary>
        [
        Description("Sets whether or not we show the sort arrows in the GridView."),
        Category("Misc"),
        Editor("System.Web.UI.Design.UrlEditor", typeof(System.Drawing.Design.UITypeEditor)),
        DefaultValue("false"),
        ]
        public bool ShowSortDirection
        {
            get
            {
                object o = ViewState["ShowSortDirection"];
                return (o != null ? Convert.ToBoolean(o) : false);
            }
            set
            {
                ViewState["ShowSortDirection"] = value;
            }
        }

        /// <summary>
        /// Gets or Sets whether we show the sort arrow in the GridView after the header text or before.
        /// </summary>
        [
        Description("Sets whether we show the sort arrow in the GridView after the header text or before."),
        Category("Misc"),
        Editor("System.Web.UI.Design.UrlEditor", typeof(System.Drawing.Design.UITypeEditor)),
        DefaultValue("false"),
        ]
        public bool ShowSortImageBeforeHeaderText
        {
            get
            {
                object o = ViewState["ShowSortImageBeforeHeaderText"];
                return (o != null ? Convert.ToBoolean(o) : false);
            }
            set
            {
                ViewState["ShowSortImageBeforeHeaderText"] = value;
            }
        }

        /// <summary>
        /// Get or Set Image location to be used to display Ascending Sort order.
        /// </summary>
        [
        Description("Image to display for Descending Sort"),
        Category("Misc"),
        Editor("System.Web.UI.Design.UrlEditor", typeof(System.Drawing.Design.UITypeEditor)),
        DefaultValue(""),
        ]
        public string SortDescImageUrl
        {
            get
            {
                object o = ViewState["SortImageDesc"];
                return (o != null ? o.ToString() : "");
            }
            set
            {
                ViewState["SortImageDesc"] = value;
            }
        }

        /// <summary>
        /// Highlights the background of the row that the mouse is currently hovering over.
        /// </summary>
        /// <returns></returns>
        protected string RowOnMouseOverScript()
        {
            return "this.style.backgroundColor = '" + HighlightColor + "';";
        }

        /// <summary>
        /// Removes highlighting created by RowOnMouseOverScript.
        /// </summary>
        /// <returns></returns>
        protected string RowOnMouseOutScript()
        {
            return "this.style.backgroundColor = '';";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class Recurser
    {
        /// <summary>
        /// this method check if a control or one of its children
        /// has the type of the types given by recursivity
        /// </summary>
        /// <param name="control">control to check</param>
        /// <param name="types">type to find</param>
        /// <returns>the first occurence of control which has one of the given types</returns>
        public static Control ContainsControlType(Control control, params Type[] types)
        {
            // may be we could loop throug the controls first and then the types
            // to gain somme speed of process
            // but I wanted to ensure the same process for any control,
            // for the first one like its children (cause the first one could have a given type)
            foreach (Type type in types)
            {
                if (control.GetType().Equals(type))
                    return control;
                else
                    // begin recursivity
                    foreach (Control ctrl in control.Controls)
                    {
                        Control tmpCtrl = ContainsControlType(ctrl, type);
                        if (tmpCtrl != null)
                            return tmpCtrl;
                    }
            }
            // if no controls had the given type in the current control we return false
            return null;
        }



        /// <summary>
        /// Check if there is more thant 0 links controls in a control or if this control is a link
        /// </summary>
        /// <param name="control">control to check in</param>
        /// <returns>true if there is any links</returns>
        public static bool ContainsLink(Control control)
        {
            bool ret = false;
            // search a link in the cell
            Control ctrl = ContainsControlType(control, typeof(HyperLink), typeof(LinkButton), typeof(DataBoundLiteralControl), typeof(TextBox), typeof(DropDownList));
            // if a control is returned, we have to check the case of the literal which could contain no links
            if (ctrl != null)
            {
                if (ctrl.GetType().Equals(typeof(DataBoundLiteralControl)))
                {
                    DataBoundLiteralControl dblc = (DataBoundLiteralControl)ctrl;
                    // here I check if the text contains a href or onclick attribute
                    // I assume that there this text should not be used to be displayed
                    if (dblc.Text.Contains("href") || dblc.Text.Contains("onclick"))
                        ret = true;
                }
                else ret = true;
            }
            return ret;
        }
    }

    /// <summary>
    /// Pager Template that conforms to JustinsWeb's user experience standards for functionality.
    /// </summary>
    public class NextPrevNumericPagerTemplate : ITemplate
    {
        int _pageIndex;

        int _pageNumber
        {
            get
            {
                return _pageIndex + 1;
            }
            set
            {
                _pageIndex = value - 1;
            }
        }

        int _pageCount;

        /// <summary>
        /// Constructor for template. 
        /// </summary>
        /// <param name="pageIndex">Current page index.</param>
        /// <param name="pageCount">Total count of all pages.</param>
        public NextPrevNumericPagerTemplate(int pageIndex, int pageCount)
        {
            _pageIndex = pageIndex;
            _pageCount = pageCount;
        }

        /// <summary>
        /// Called when pager is instantiated in the provided control.
        /// </summary>
        /// <param name="container"></param>
        public void InstantiateIn(Control container)
        {
            int pagerStartIndex = startPageIndex(_pageIndex, _pageCount);
            int pagerEndIndex = endPageIndex(_pageIndex, _pageCount);

            createResultsSummary(container);
            createFirstButton(container);
            createPrevButton(container);
            createSpacer(container);

            createPrevEllipsisIfNeeded(container, pagerStartIndex);
            createCorrectPageButtons(container, pagerStartIndex, pagerEndIndex);
            createNextEllipsisIfNeeded(container, pagerEndIndex);

            createNextButton(container);
            createLastButton(container);
        }

        /// <summary>
        /// Creates the ... that allows you to jump forward to more pages in the pager.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="pagerEndIndex"></param>
        private void createNextEllipsisIfNeeded(Control container, int pagerEndIndex)
        {
            if (pageNumber(pagerEndIndex) < _pageCount)
            {
                createEllipsisButton(container, pagerEndIndex + 1);
            }
        }

        private void createPrevEllipsisIfNeeded(Control container, int pagerStartIndex)
        {
            if (pageNumber(pagerStartIndex) > 1)
            {
                createEllipsisButton(container, pagerStartIndex - 1);
            }
        }

        private void createCorrectPageButtons(Control container, int pagerStartIndex, int pagerEndIndex)
        {
            for (int i = pagerStartIndex; i <= pagerEndIndex; i++)
            {
                createCorrectPageButton(container, i);
            }
        }

        private static void createNextButton(Control container)
        {
            ImageButton nextButton = new ImageButton();
            nextButton.CommandName = "Page";
            nextButton.CommandArgument = "Next";
            nextButton.ImageUrl = "../images/next.png";
            container.Controls.Add(nextButton);
        }

        private static void createPrevButton(Control container)
        {
            ImageButton prevButton = new ImageButton();
            prevButton.CommandName = "Page";
            prevButton.CommandArgument = "Prev";
            prevButton.ImageUrl = "../images/prev.png";
            container.Controls.Add(prevButton);
        }

        private static void createLastButton(Control container)
        {
            ImageButton prevButton = new ImageButton();
            prevButton.CommandName = "Page";
            prevButton.CommandArgument = "Last";
            prevButton.ImageUrl = "../images/bottom.png";
            container.Controls.Add(prevButton);
        }
        private static void createFirstButton(Control container)
        {
            ImageButton prevButton = new ImageButton();
            prevButton.CommandName = "Page";
            prevButton.CommandArgument = "First";
            prevButton.ImageUrl = "../images/top.png";
            container.Controls.Add(prevButton);
        }


        private void createResultsSummary(Control container)
        {
            Label resultsSummary = new Label();
            resultsSummary.CssClass = "PagerResultsSummary";
            resultsSummary.Text = "Page " + _pageNumber + " of " + _pageCount;
            container.Controls.Add(resultsSummary);
        }

        private void createCorrectPageButton(Control container, int pageIndexOnButton)
        {
            if (_pageIndex == pageIndexOnButton)
            {
                createNumericPageLabel(container, pageIndexOnButton);
            }
            else
            {
                createNumericPageButton(container, pageIndexOnButton);
            }

            createSpacer(container);
        }

        private void createNumericPageButton(Control container, int pageIndex)
        {
            LinkButton pageButton;
            pageButton = new LinkButton();
            pageButton.Text = pageNumber(pageIndex).ToString();
            pageButton.CommandName = "Page";
            pageButton.CommandArgument = pageNumber(pageIndex).ToString();
            container.Controls.Add(pageButton);
        }

        private void createNumericPageLabel(Control container, int pageIndex)
        {
            Label currentPageLabel;
            currentPageLabel = new Label();
            currentPageLabel.CssClass = "SelectedPageButton";
            currentPageLabel.Text = pageNumber(pageIndex).ToString();
            container.Controls.Add(currentPageLabel);
        }


        private void createEllipsisButton(Control container, int goToIndex)
        {
            LinkButton pageButton;
            pageButton = new LinkButton();
            pageButton.Text = "...";
            pageButton.CommandName = "Page";
            pageButton.CommandArgument = pageNumber(goToIndex).ToString();
            container.Controls.Add(pageButton);

            createSpacer(container);
        }

        private static void createSpacer(Control container)
        {
            Literal spacer = new Literal();
            spacer = new Literal();
            spacer.Text = "&nbsp;";

            container.Controls.Add(spacer);
        }

        /// <summary>
        /// Finds the starting page index to display on the pager. (Will need conversion to page number)
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="totalPageCount"></param>
        /// <returns></returns>
        private int startPageIndex(int currentPageIndex, int totalPageCount)
        {
            int startingPageToDisplay = 0;
            startingPageToDisplay = currentPageIndex - 4;

            if ((pageIndex(totalPageCount) - currentPageIndex) < 5)
            {
                startingPageToDisplay = pageIndex(totalPageCount) - 9;
            }
            if (startingPageToDisplay < 0)
            {
                startingPageToDisplay = 0;
            }
            return startingPageToDisplay;
        }

        /// <summary>
        /// Finds the ending page index to display on the pager. (Will need conversion to page number)
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="totalPageCount"></param>
        /// <returns></returns>
        private int endPageIndex(int currentPageIndex, int totalPageCount)
        {
            int endingPageToDisplay = currentPageIndex + 5;
            int maxEndingPageIndex = (9 > pageIndex(totalPageCount)) ? pageIndex(totalPageCount) : 9;

            if (endingPageToDisplay > totalPageCount - 1)
            {
                endingPageToDisplay = totalPageCount - 1;
            }
            else if (currentPageIndex < 5)
            {
                endingPageToDisplay = maxEndingPageIndex;
            }
            return endingPageToDisplay;
        }

        /// <summary>
        /// Converts a given page index to a page number.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        private int pageNumber(int pageIndex)
        {
            return pageIndex + 1;
        }

        /// <summary>
        /// Converts a given page number to a page index.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        private int pageIndex(int pageNumber)
        {
            return pageNumber - 1;
        }

    }


}
