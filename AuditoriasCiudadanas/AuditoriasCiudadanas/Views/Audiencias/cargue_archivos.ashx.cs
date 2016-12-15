using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.SessionState;
using System.Web.Script;


namespace AuditoriasCiudadanas.Views.Audiencias
{
    /// <summary>
    /// Descripción breve de cargue_archivos
    /// </summary>
    public class cargue_archivos : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {

                switch (context.Request.HttpMethod)
                {
                    case "HEAD":
                        break;
                    case "GET":
                        if (GivenFilename(context))
                        {
                            DeliverFile(context);
                        }
                        break;
                    case "POST":
                        // ajax calls POST, but it can be a "DELETE" if there is a QueryString on the context
                        if (GivenFilename(context))
                        {
                            DeleteFile(context);
                        }
                        else
                        {
                            Uploadfile(context);
                        }

                        return;
                    case "PUT":
                        break;
                    case "DELETE":

                        DeleteFile(context);

                        return;
                    case "OPTIONS":
                        break;
                    default:
                        context.Response.ClearHeaders();
                        context.Response.StatusCode = 405;

                        return;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Uploadfile(HttpContext context)
        {
            int i = 0;
            LinkedList<ViewDataUploadFilesResult> r = new LinkedList<ViewDataUploadFilesResult>();
            string[] files = null;
            string savedFileName = string.Empty;
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();

            try
            {

                if (context.Request.Files.Count >= 1)
                {

                    int maximumFileSize = Convert.ToInt16(ConfigurationManager.AppSettings["UploadFilesMaximumFileSize"]);

                    context.Response.ContentType = "text/plain";
                    for (i = 0; i <= context.Request.Files.Count - 1; i++)
                    {
                        HttpPostedFile hpf = default(HttpPostedFile);
                        string FileName = null;
                        hpf = context.Request.Files[i];

                        if (HttpContext.Current.Request.Browser.Browser.ToUpper().Equals("IE"))
                        {
                            files = hpf.FileName.Split(Convert.ToChar("\\\\"));
                            FileName = files[files.Length - 1];
                        }
                        else
                        {
                            FileName = hpf.FileName;
                        }


                        if (hpf.ContentLength >= 0 & (hpf.ContentLength <= maximumFileSize * 1000 | maximumFileSize == 0))
                        {

                            savedFileName = StorageRoot(context);

                            savedFileName = savedFileName + FileName;

                            hpf.SaveAs(savedFileName);

                            r.AddLast(new ViewDataUploadFilesResult(FileName, hpf.ContentLength, hpf.ContentType, savedFileName));

                            dynamic uploadedFiles = r.Last;
                            dynamic jsonObj = js.Serialize(uploadedFiles);
                            context.Response.Write(jsonObj.ToString);

                        }
                        else
                        {

                            // File to Big (using IE without ActiveXObject enabled
                            if (hpf.ContentLength > maximumFileSize * 1000)
                            {
                                r.AddLast(new ViewDataUploadFilesResult(FileName, hpf.ContentLength, hpf.ContentType, string.Empty, "maxFileSize"));

                            }

                            dynamic uploadedFiles = r.Last;
                            dynamic jsonObj = js.Serialize(uploadedFiles);
                            context.Response.Write(jsonObj.ToString);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void DeleteFile(HttpContext context)
        {
            try
            {
                dynamic path = StorageRoot(context);
                dynamic file = context.Request["f"];
                path += file;

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        #region "Generic helpers"

        private string StorageRoot(HttpContext context)
        {
            try
            {
                string uploadFilesTempBasePath = ConfigurationManager.AppSettings["UploadFilesTempBasePath"];
                string uploadFilesTempPath = ConfigurationManager.AppSettings["UploadFilesTempPath"];
                string initPath = uploadFilesTempBasePath + uploadFilesTempPath;

                // Add the Session Unique Folder Name
                if (context.Session["UserFolder"] != null)
                {
                    if ((initPath.LastIndexOf("\\") != initPath.Length - 1))
                    {
                        initPath += "\\";
                    }
                    initPath += context.Session["UserFolder"];
                }

                CheckPath(ref initPath);

                return initPath;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CheckPath(ref string serverPath)
        {
            string initPath = string.Empty;
            string tempPath = string.Empty;
            string[] folders = null;

            try
            {

                folders = serverPath.Split(Convert.ToChar("\\\\"));

                // Save file to a server
                if (serverPath.Contains("\\\\"))
                {
                    initPath = "\\\\";
                }
                else
                {
                    // Save file to a local folders
                }

                for (int i = 0; i <= folders.Length - 1; i++)
                {
                    if (string.IsNullOrEmpty(tempPath.Trim()) & (!String.IsNullOrEmpty(folders[i])))
                    {
                        tempPath = initPath + folders[i];
                    }
                    else if (!(string.IsNullOrEmpty(tempPath.Trim()) & !(string.IsNullOrEmpty(folders[i].Trim()))))
                    {
                        tempPath = tempPath + "\\" + folders[i];

                        // Doesn't check if it's a network connection
                        if (!tempPath.Contains("\\\\") & !folders[i].Contains("$"))
                        {

                            if (!System.IO.Directory.Exists(tempPath))
                            {
                                System.IO.Directory.CreateDirectory(tempPath);
                            }

                        }
                        else
                        {
                            if (!System.IO.Directory.Exists(tempPath))
                            {
                                System.IO.Directory.CreateDirectory(tempPath);
                            }

                        }

                    }

                }

                serverPath = tempPath + "\\";

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool GivenFilename(HttpContext context)
        {
            try
            {
                return !string.IsNullOrEmpty(context.Request["f"]);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void DeliverFile(HttpContext context)
        {
            try
            {
                dynamic file = context.Request["f"];
                dynamic filePath = StorageRoot(context) + file;

                if (System.IO.File.Exists(filePath))
                {
                    context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file);
                    context.Response.ContentType = "application/octet-stream";
                    context.Response.ClearContent();
                    context.Response.WriteFile(filePath);
                }
                else
                {
                    context.Response.StatusCode = 404;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

    }

    #region "local Class"

    public class ViewDataUploadFilesResult
    {
        public string _name;
        public int _length;
        public string _type;
        public string _url;
        public string delete_url;
        public string delete_type;

        public string _errorMSG;
        public ViewDataUploadFilesResult()
        {

            try
            {
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ViewDataUploadFilesResult(string Name, int Length, string Type, string URL)
        {
            try
            {
                _name = Name;
                _length = Length;
                _type = Type;
                _url = "cargue_archivos.ashx?f=" + Name;
                delete_url = "cargue_archivos.ashx?f=" + Name;
                delete_type = "POST";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ViewDataUploadFilesResult(string Name, int Length, string Type, string URL, string errorMSG)
        {
            try
            {
                _name = Name;
                _length = Length;
                _type = Type;
                _url = "cargue_archivos.ashx?f=" + Name;
                delete_url = "cargue_archivos.ashx?f=" + Name;
                delete_type = "POST";
                _errorMSG = errorMSG;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
    #endregion
}