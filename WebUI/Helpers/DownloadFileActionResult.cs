using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.Helpers
{
    public class DownloadFileActionResult : ActionResult
    {
        public GridView ExcelGridView { get; set; }
        public string FileName { get; set; }

        public DownloadFileActionResult(GridView gv, string pFileName)
        {
            ExcelGridView = gv;
            FileName = pFileName;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var curContext = HttpContext.Current;
            curContext.Response.Clear();
            curContext.Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            curContext.Response.Charset = "";
            curContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            curContext.Response.ContentType = "application/vnd.ms-excel";
            var sw = new StringWriter();
            var htw = new HtmlTextWriter(sw);
            ExcelGridView.RenderControl(htw);
            var byteArray = Encoding.ASCII.GetBytes(sw.ToString());
            var s = new MemoryStream(byteArray);
            var sr = new StreamReader(s, Encoding.ASCII);
            curContext.Response.Write(sr.ReadToEnd());
            curContext.Response.End();
        }

    }
}