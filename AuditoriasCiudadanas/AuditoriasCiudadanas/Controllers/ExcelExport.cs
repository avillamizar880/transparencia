using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Controllers
{
    public class ExcelExport
    {


        private HSSFWorkbook hssfworkbook;
        private ICellStyle ContenStyle;
        private string p_Company = "Transparencia";

        private string p_DescriptionReport = "Reporte Generado";
        public ExcelExport()
        {
            hssfworkbook = new HSSFWorkbook();
        }

        public ExcelExport(string Compannia, string Descripcion)
        {
            p_Company = Compannia;
            p_DescriptionReport = Descripcion;
            hssfworkbook = new HSSFWorkbook();
        }

        public string NameCompany
        {
            set { p_Company = value; }
        }

        public string DescriptionReport
        {
            set { p_DescriptionReport = value; }
        }

        private ICellStyle StyleRow1(HorizontalAlignment aligment)
        {

            ContenStyle.FillForegroundColor = HSSFColor.White.Index;
            //ContenStyle.FillPattern = FillPatternType.SOLID_FOREGROUND
            ContenStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            ContenStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            ContenStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            ContenStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            ContenStyle.Alignment = aligment;
            return ContenStyle;

        }


        private ICellStyle StyleRow2(HorizontalAlignment aligment)
        {

            ContenStyle.FillForegroundColor = HSSFColor.White.Index;
            //ContenStyle.FillPattern = FillPatternType.SOLID_FOREGROUND
            ContenStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            ContenStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            ContenStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            ContenStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            ContenStyle.Alignment = aligment;
            return ContenStyle;

        }

        /// <summary>
        /// Funcion encargada de Insertar la información de las propiedades al documento Excel que se genere
        /// </summary>
        /// <remarks></remarks>
        private void InfoExcel()
        {
            DocumentSummaryInformation DocInfo = default(DocumentSummaryInformation);
            SummaryInformation SummaryInfo = default(SummaryInformation);

            DocInfo = PropertySetFactory.CreateDocumentSummaryInformation();
            DocInfo.Company = p_Company;
            hssfworkbook.DocumentSummaryInformation = DocInfo;

            SummaryInfo = PropertySetFactory.CreateSummaryInformation();
            SummaryInfo.Subject = p_DescriptionReport;
            hssfworkbook.SummaryInformation = SummaryInfo;
        }

        private MemoryStream WriteToStream()
        {
            //Write the stream data of workbook to the root directory
            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            return file;
        }

        private void InitializeWorkbook(string path)
        {
            //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
            //book1.xls is an Excel-2007-generated file, so some new unknown BIFF records are added. 
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
        }

        /// <summary>
        /// Rutina encargada de introducir el DataTable en una Hoja de Calculo
        /// </summary>
        /// <param name="Titulo"></param>
        /// <param name="dt"></param>
        /// <param name="countSheet"></param>
        /// <param name="IgnoreColumns"></param>
        /// <remarks></remarks>
        private void CreateSheetFromDataTable(string Titulo, DataTable dt, string countSheet, List<int> IgnoreColumns = null)
        {
            ISheet DataSheet = default(ISheet);
            IRow CurrRow = default(IRow);
            ICell CurrCell = default(ICell);
            int CellIndex = 0;
            int column = 0;
            int color = 0;

            if (IgnoreColumns == null)
            {
                IgnoreColumns = new List<int>();
            }

            DataSheet = hssfworkbook.CreateSheet("Hoja " + countSheet);

            CurrRow = DataSheet.CreateRow(column);
            CellIndex = 0;

            if (!string.IsNullOrEmpty(Titulo))
            {
                CurrCell = CurrRow.CreateCell(0);
                if (Titulo.Contains('\n'))
                {
                    CurrRow.HeightInPoints = Titulo.Split('\n').Count() * DataSheet.DefaultRowHeightInPoints;
                }
                CurrCell.SetCellValue(Titulo);
                column += 1;
                CurrRow = DataSheet.CreateRow(column);
            }
            if (dt != null)
            {
                //Creamos el header de la hoja de cálculo.
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    if (!IgnoreColumns.Contains(i))
                    {
                        CurrCell = CurrRow.CreateCell(CellIndex);
                        CurrCell.SetCellValue(dt.Columns[i].ColumnName.Trim());
                        CellIndex += 1;
                    }
                }
                //Creamos los estilos para el contenido de la tabla
                List<ICellStyle> lstStyleContentRowCellOne = new List<ICellStyle>();
                List<ICellStyle> lstStyleContentRowCellTwo = new List<ICellStyle>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Columns.Count - 1; i++)
                    {
                        if (!IgnoreColumns.Contains(i))
                        {
                            if (IsNumeric(dt.Rows[0][i].ToString()))
                            {
                                lstStyleContentRowCellOne.Add(StyleContentCell(HorizontalAlignment.Right, 0));
                                lstStyleContentRowCellTwo.Add(StyleContentCell(HorizontalAlignment.Right, 1));
                            }
                            else
                            {
                                lstStyleContentRowCellOne.Add(StyleContentCell(HorizontalAlignment.Left, 0));
                                lstStyleContentRowCellTwo.Add(StyleContentCell(HorizontalAlignment.Left, 1));
                            }
                        }
                    }
                    //Iterar a través de filas de datos y agregar a la hoja de cálculo.
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        CellIndex = 0;
                        CurrRow = DataSheet.CreateRow(i + 1 + column);
                        color = i % 2;
                        for (int j = 0; j <= dt.Columns.Count - 1; j++)
                        {
                            if (!IgnoreColumns.Contains(j))
                            {
                                CurrCell = CurrRow.CreateCell(CellIndex);
                                Type ty = dt.Columns[j].DataType;
                                if (ty.Equals(typeof(System.Decimal)) | ty.Equals(typeof(System.Int16)) | ty.Equals(typeof(System.Int32)) | ty.Equals(typeof(System.Int64)) | ty.Equals(typeof(System.Double)) | ty.Equals(typeof(System.Single)))
                                {
                                    CurrCell.SetCellType(CellType.Numeric);
                                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                                    {
                                        CurrCell.SetCellValue(Convert.ToDouble(dt.Rows[i][j].ToString()));
                                    }
                                }
                                else
                                {
                                    CurrCell.SetCellType(CellType.String);
                                    CurrCell.SetCellValue(dt.Rows[i][j].ToString());
                                }
                                if (color == 1)
                                {
                                    CurrCell.CellStyle = lstStyleContentRowCellOne[CellIndex];
                                }
                                else
                                {
                                    CurrCell.CellStyle = lstStyleContentRowCellTwo[CellIndex];
                                }
                                CellIndex += 1;
                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(Titulo))
            {
                DataSheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, CurrRow.LastCellNum - 1));
                CurrRow = DataSheet.GetRow(0);
                CurrRow.GetCell(0).CellStyle = StyleTitle();
            }

            CurrRow = DataSheet.GetRow(column);

            //Damos formatos a las columnas de la hoja de cálculo.
            for (int i = 0; i <= DataSheet.GetRow(column).LastCellNum - 1; i++)
            {
                DataSheet.AutoSizeColumn(i);
            }

            for (int j = 0; j <= CurrRow.LastCellNum - 1; j++)
            {
                CurrRow.GetCell(j).CellStyle = StyleHeader();
            }
        }

        /// <summary>
        /// Estilo del Header de la tabla.
        /// </summary>
        /// <param name="aligment">Alineación</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private ICellStyle StyleHeader(HorizontalAlignment aligment = HorizontalAlignment.Left)
        {
            IFont HeaderFont = default(IFont);
            ICellStyle HeaderStyle = default(ICellStyle);

            HeaderFont = hssfworkbook.CreateFont();
            HeaderFont.Color = HSSFColor.Black.Index;
            HeaderFont.Boldweight = (short)FontBoldWeight.Bold;

            HeaderStyle = hssfworkbook.CreateCellStyle();
            HeaderStyle.SetFont(HeaderFont);
            //HeaderStyle.FillForegroundColor = HSSFColor.SKY_BLUE.Index
            //HeaderStyle.FillPattern = FillPatternType.SOLID_FOREGROUND
            HeaderStyle.Alignment = aligment;

            HeaderStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            HeaderStyle.BottomBorderColor = HSSFColor.Black.Index;
            HeaderStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            HeaderStyle.LeftBorderColor = HSSFColor.Black.Index;
            HeaderStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            HeaderStyle.RightBorderColor = HSSFColor.Black.Index;
            HeaderStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            HeaderStyle.TopBorderColor = HSSFColor.Black.Index;

            return HeaderStyle;
        }

        /// <summary>
        /// Estilo del Titulo del Reporte.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private ICellStyle StyleTitle()
        {
            IFont HeaderFont = default(IFont);
            ICellStyle HeaderStyleTitle = default(ICellStyle);

            HeaderFont = hssfworkbook.CreateFont();
            HeaderFont.Color = HSSFColor.Black.Index;
            HeaderFont.Boldweight = (short)FontBoldWeight.Bold;

            HeaderStyleTitle = hssfworkbook.CreateCellStyle();
            HeaderStyleTitle.SetFont(HeaderFont);
            HeaderStyleTitle.WrapText = true;

            return HeaderStyleTitle;
        }

        /// <summary>
        /// Estilo del contenido de las celdas de la tabla que contiene los datos.
        /// </summary>
        /// <param name="aligment"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private ICellStyle StyleContentCell(HorizontalAlignment aligment, int type)
        {
            ICellStyle functionReturnValue = default(ICellStyle);
            ContenStyle = hssfworkbook.CreateCellStyle();
            if (type == 1)
            {
                functionReturnValue = StyleRow1(aligment);
            }
            else
            {
                functionReturnValue = StyleRow2(aligment);
            }
            return functionReturnValue;
        }

        /// <summary>
        /// Generar Reporte en Excel a partir de un GridView
        /// </summary>
        /// <param name="Titulo">Titulo del reporte, Visible sobre la tabla de datos generados en el documento Excel</param>
        /// <param name="GridData">GridView que conteina la Data a Exportar</param>
        /// <param name="IgnoreColumns">Columnas a Ingnorar en el GridView</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public MemoryStream ExportExcelFromGridView(string Titulo, GridView GridData, List<int> IgnoreColumns = null)
        {
            ISheet DataSheet = default(ISheet);
            IRow CurrRow = default(IRow);
            ICell CurrCell = default(ICell);

            LinkButton HeaderLink = default(LinkButton);
            int CellIndex = 0;
            int column = 0;
            int color = 0;

            if (IgnoreColumns == null)
            {
                IgnoreColumns = new List<int>();
            }

            InfoExcel();
            DataSheet = hssfworkbook.CreateSheet("Hoja 1");

            CurrRow = DataSheet.CreateRow(column);
            CellIndex = 0;

            if (!string.IsNullOrEmpty(Titulo))
            {
                CurrCell = CurrRow.CreateCell(0);
                if (Titulo.Contains('\n'))
                {
                    CurrRow.HeightInPoints = Titulo.Split('\n').Count() * DataSheet.DefaultRowHeightInPoints;
                }
                CurrCell.SetCellValue(Titulo);
                column += 1;
                CurrRow = DataSheet.CreateRow(column);
            }
            //Creamos el header de la hoja de cálculo.
            for (int i = 0; i <= GridData.HeaderRow.Cells.Count - 1; i++)
            {
                if (!IgnoreColumns.Contains(i))
                {
                    // Si la columna en cuestión tiene como columna ordenable, la cabecera
                    // contendrá un control en lugar de texto.
                    if (!string.IsNullOrEmpty(GridData.HeaderRow.Cells[i].Text))
                    {
                        CurrCell = CurrRow.CreateCell(CellIndex);
                        CurrCell.SetCellValue(HttpUtility.HtmlDecode(GridData.HeaderRow.Cells[i].Text).Trim());
                        CurrCell.CellStyle = StyleHeader((HorizontalAlignment)GridData.Columns[i].ItemStyle.HorizontalAlign);
                    }
                    else
                    {
                        HeaderLink = (LinkButton)GridData.HeaderRow.Cells[i].Controls[0];
                        CurrCell = CurrRow.CreateCell(CellIndex);
                        CurrCell.SetCellValue(HeaderLink.Text);
                    }
                    CellIndex += 1;
                }
            }
            //Creamos los estilos para el contenido de la tabla
            List<ICellStyle> lstStyleContentRowCellOne = new List<ICellStyle>();
            List<ICellStyle> lstStyleContentRowCellTwo = new List<ICellStyle>();
            if (GridData.Rows.Count > 0)
            {
                for (int i = 0; i <= GridData.Rows[0].Cells.Count - 1; i++)
                {
                    if (!IgnoreColumns.Contains(i))
                    {
                        lstStyleContentRowCellOne.Add(StyleContentCell((HorizontalAlignment)GridData.Columns[i].ItemStyle.HorizontalAlign, 0));
                        lstStyleContentRowCellTwo.Add(StyleContentCell((HorizontalAlignment)GridData.Columns[i].ItemStyle.HorizontalAlign, 1));
                    }
                }
                //Iterar a través de filas de datos y agregar a la hoja de cálculo.
                for (int i = 0; i <= GridData.Rows.Count - 1; i++)
                {
                    CellIndex = 0;
                    color = i % 2;
                    CurrRow = DataSheet.CreateRow(i + 1 + column);
                    for (int j = 0; j <= GridData.Rows[i].Cells.Count - 1; j++)
                    {
                        if (!IgnoreColumns.Contains(j))
                        {
                            CurrCell = CurrRow.CreateCell(CellIndex);
                            CurrCell.SetCellValue(System.Web.HttpUtility.HtmlDecode(GridData.Rows[i].Cells[j].Text).Trim());
                            if (color == 1)
                            {
                                CurrCell.CellStyle = lstStyleContentRowCellOne[CellIndex];
                            }
                            else
                            {
                                CurrCell.CellStyle = lstStyleContentRowCellTwo[CellIndex];
                            }
                            if (GridData.Rows[i].Cells[j].ColumnSpan > 1)
                            {
                                DataSheet.AddMergedRegion(new CellRangeAddress(i + column + 1, i + column + 1, j, j + GridData.Rows[i].Cells[j].ColumnSpan - 1));
                            }
                            CellIndex += 1;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(Titulo))
            {
                DataSheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, CurrRow.LastCellNum - 1));
                CurrRow = DataSheet.GetRow(0);
                CurrRow.GetCell(0).CellStyle = StyleTitle();
            }

            CurrRow = DataSheet.GetRow(column);

            //Damos formatos a las columnas de la hoja de cálculo.
            for (int i = 0; i <= DataSheet.GetRow(column).LastCellNum - 1; i++)
            {
                if (!IgnoreColumns.Contains(i))
                {
                    DataSheet.AutoSizeColumn(i);
                }
            }

            return WriteToStream();
        }


        /// <summary>
        /// Generar Reporte en Excel a partir de un DataTable
        /// </summary>
        /// <param name="Titulo">Titulo del reporte, Visible sobre la tabla de datos generados en el documento Excel</param>
        /// <param name="Dt">DataTable que conteina la Data a Exportar</param>
        /// <param name="IgnoreColumns">Columnas a Ingnorar en el DataTable</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public MemoryStream ExportExcelFromDataTable(string Titulo, DataTable Dt, List<int> IgnoreColumns = null)
        {
            InfoExcel();

            CreateSheetFromDataTable(Titulo, Dt, "1", IgnoreColumns);

            return WriteToStream();
        }

        /// <summary>
        /// Generar Reporte en Excel a partir de una Lista de DataTable
        /// </summary>
        /// <param name="lstDt">Lista de DataTable</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public MemoryStream ExportExcelFromLstDataTable(List<DataTable> lstDt)
        {
            InfoExcel();
            for (int canDt = 0; canDt <= lstDt.Count - 1; canDt++)
            {
                CreateSheetFromDataTable("", lstDt[canDt], Convert.ToString(canDt + 1), new List<int>());
            }

            return WriteToStream();
        }

        /// <summary>
        /// Funcion encargada de retornar un DataTable a partir de los datos contenidos en un Excel
        /// </summary>
        /// <param name="path">Path fisico donde se encuentra el archivo en el servidor</param>
        /// <param name="rowRead">A partir de que columna se quiere empezar a leer el documento</param>
        /// <returns>DataTable</returns>
        /// <remarks></remarks>
        public DataTable ConvertToDataTable(string path, int rowRead = 0)
        {
            InitializeWorkbook(path);

            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            DataTable dtDatosExcel = new DataTable();
            //Obtenemos el numero maximo de columnas a leer
            for (int j = 0; j <= (sheet.GetRow(rowRead).LastCellNum - 1); j++)
            {
                dtDatosExcel.Columns.Add(Convert.ToChar((System.Convert.ToInt32('A').ToString()) + j).ToString());
            }

            int count = 0;
            while (rows.MoveNext())
            {
                if (count >= rowRead)
                {
                    IRow row = (HSSFRow)rows.Current;
                    DataRow dr = dtDatosExcel.NewRow();

                    for (int i = 0; i <= row.LastCellNum - 1; i++)
                    {
                        ICell cell = row.GetCell(i);

                        if (cell == null)
                        {
                            dr[i] = null;
                        }
                        else
                        {
                            dr[i] = cell.ToString();
                        }
                    }
                    dtDatosExcel.Rows.Add(dr);
                }
                count += 1;
            }

            return dtDatosExcel;
        }

        // Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Free other state (managed objects].
            }
            // Free your own state (unmanaged objects].
            // Set large fields to null.
        }

        //protected override void Finalize()
        //{
        //    // Simply call Dispose(False].
        //    Dispose(false);
        //}

        ~ExcelExport() { Dispose(false); }


        public static bool IsNumeric(object value)
        {
            try
            {
                int i = Convert.ToInt32(value.ToString());
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}