using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataDal
    {
        public static string SaveFileToDatabase(string filePath)
        {
         
             String strConnection = "Data Source=.\\SQLEXPRESS;AttachDbFilename='C:\\Program Files\\Microsoft SQL Server\\MSSQL13.SQLEXPRESS\\MSSQL\\DATA\\Standard.mdf';Integrated Security=True;User Instance=True";
            String excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", filePath);
            //Create Connection to Excel work book 
            using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
            {
                //Create OleDbCommand to fetch data from Excel 
                using (OleDbCommand cmd = new OleDbCommand("Select [StudentId],[StudentFirstName],[StudentLastName] ,[StudentTz],[Grade] ,[Class],[IsEngaged],[IsIncludingTeaching],  ,[IsActive],[GroupNumber],[StudentStandard] from [Sheet1$]", excelConnection))

                   
                {
                    excelConnection.Open();
                    using (OleDbDataReader dReader = cmd.ExecuteReader())
                    {
                        using (SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection))
                        {
                            //Give your Destination table name 
                            sqlBulk.DestinationTableName = "Excel_table";
                            sqlBulk.WriteToServer(dReader);
                        }
                    }
                }
                return " a";
            }
            
        }


        //private string GetLocalFilePath(string saveDirectory, FileUpload fileUploadControl)
        //{


        //    string filePath = System.IO.Path.Combine(saveDirectory, fileUploadControl.FileName);

        //    fileUploadControl.SaveAs(filePath);

        //    return filePath;

        //}
    }
}
