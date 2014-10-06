using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;

namespace WebUI.Controllers
{
    public class ExcelResult:ActionResult
    {
        private readonly XLWorkbook _workBook;
        private readonly  string _fileName ;

        public ExcelResult(XLWorkbook workBook,string fileName)
        {
            _workBook= workBook;
            _fileName = fileName;

        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.Clear();
            response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            response.AddHeader("content-disposition","attachment;fileName="+_fileName+".xlsx");
            using (var memoryStream = new MemoryStream())
            {

                _workBook.SaveAs(memoryStream);
                memoryStream.WriteTo(response.OutputStream);
            }
            response.End();
        }
    }
}