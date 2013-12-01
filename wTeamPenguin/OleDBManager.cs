using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;

namespace wTeamPenguin
{
    /// <summary>
    /// This Class gives you an /*%%%---UNSAFE---%%%*/ easy, simple and fast way to run quries and manage your database.
    /// Created by Hagai Bloch Gadot /*%%%---EDITTED IMPROVED AND SECURED BY NOAM GAL---%%%*/
    /// Only for the Kfat HaYarok Students. /*%%%---WELL, NOT UNSAFE ANYMORE---%%%*/
    /// </summary>
    public class OleDBManager
    {
        #region Data
        /// <summary>
        /// Data properties
        /// </summary>
        private OleDbConnection link; // The link instance
        private OleDbCommand command; // The command object
        private OleDbDataReader dataReader; // The data reader object
        private OleDbDataAdapter dataAdapter; // the data adapter object
        private DataTable dataTable; // the data table object
        private string dbName; // the Database filename
        private int version; // the users office version
        private string connectionString; // the connection string for the database connection
        private string provider; // the matching driver string for the connection string
        private string path; // the path to the database file
        #endregion

        #region Ctor
        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="dbName">the database filename, e.g: "MyDatabase"(located on the App_Data folder)</param>
        /// <param name="path">the path for the database file location</param>
        /// <param name="version">office version(2003/2007/2010)</param>
        public OleDBManager(string dbName, string path, int version)
        {
            this.provider = this.GetProvider(version);
            this.dbName = dbName;
            // ----
            this.path = HttpContext.Current.Server.MapPath(path + "\\");
            this.connectionString = "Provider=" + this.provider + ";Data source=" + this.path + this.dbName;
            // ----
            this.link = new OleDbConnection(this.connectionString);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Unsafely executes a Query
        /// </summary>
        /// <param name="query">the query string</param>
        /// <returns>the number of rows that were affected</returns>
        public int ExecuteQuery(string query)
        {
            while (this.link.State.ToString().ToLower() != "closed") { }

            this.link.Open();
            int rowsAffected;
            // ---
            this.command = new OleDbCommand(query, this.link);
            try
            {
                rowsAffected = this.command.ExecuteNonQuery();
            }
            catch (InvalidOperationException e)
            {
                if (e.Data == null)
                    throw;
                else
                    rowsAffected = -1;
            }
            finally
            {
                this.command.Dispose();
                this.link.Close();
            }
            // ---
            return rowsAffected;
        }
        /// <summary>
        /// Executes a Query
        /// </summary>
        /// <param name="query">the query string. in-string variables must start with @</param>
        /// <param name="vars">names of the in-string variables in the order they appear in the query</param>
        /// <param name="reps">values of the in-string variables in the order they appear in the query</param>
        /// <returns>the number of rows that were affected</returns>
        public int ExecuteQuery(string query, string[] vars, string[] reps)
        {
            while (this.link.State.ToString().ToLower() != "closed") { }

            this.link.Open();
            int rowsAffected;
            // ---
            this.command = new OleDbCommand();
            this.command.CommandText = query;
            this.command.CommandType = System.Data.CommandType.Text;
            this.command.Connection = this.link;

            //Parameters in the order in which they appear in the query
            for (int i = 0; i < vars.Length; i++)
                this.command.Parameters.AddWithValue(vars[i], reps[i]);

            try
            {
                rowsAffected = this.command.ExecuteNonQuery();
            }
            catch (InvalidOperationException e)
            {
                if (e.Data == null)
                    throw;
                else
                    rowsAffected = -1;
            }
            finally
            {
                this.command.Dispose();
                this.link.Close();
            }
            // ---
            return rowsAffected;
        }


        /// <summary>
        /// Exeutes a SELECT query and returns the data.
        /// </summary>
        /// <param name="query">the query string. in-string variables must start with @</param>
        /// <returns>returns an DataTable instance with the recived data from the selection query.</returns>        
        public DataTable ExecuteRead(string query)
        {
            while (this.link.State.ToString().ToLower() != "closed") { }

            this.link.Open();
            // ---
            this.dataAdapter = new OleDbDataAdapter(query, this.link);
            // ---
            this.dataTable = new DataTable();
            this.dataAdapter.Fill(this.dataTable);
            // ---
            this.link.Close();
            // ---
            return this.dataTable;
        }
        /// <summary>
        /// Exeutes a SELECT query and returns the data.
        /// </summary>
        /// <param name="query">the query string. in-string variables must start with @</param>
        /// <param name="vars">names of the in-string variables in the order they appear in the query</param>
        /// <param name="reps">values of the in-string variables in the order they appear in the query</param>
        /// <returns>returns an DataTable instance with the recived data from the selection query.</returns>        
        public DataTable ExecuteRead(string query, string[] vars, string[] reps)
        {
            while (this.link.State.ToString().ToLower() != "closed") { }

            this.link.Open();
            // ---
            this.dataAdapter = new OleDbDataAdapter(query, this.link);
            this.dataAdapter.SelectCommand = new OleDbCommand(query, this.link);
            this.dataAdapter.SelectCommand.CommandType = CommandType.Text;

            for (int i = 0; i < vars.Length; i++)
                this.dataAdapter.SelectCommand.Parameters.AddWithValue(vars[i], reps[i]);

            // ---
            this.dataTable = new DataTable();
            this.dataAdapter.Fill(this.dataTable);
            // ---
            this.link.Close();
            this.dataAdapter.Dispose();
            // ---
            return this.dataTable;
        }

        /// <summary>
        /// Checking if there are any results for a specific SELECT query
        /// </summary>
        /// <param name="query">the query string. in-string variables must start with @</param>
        /// <returns>true if there are any results and false if not.</returns>
        public bool IsExist(string query)
        {
            while (this.link.State.ToString().ToLower() != "closed") { }

            this.link.Open();
            // ---
            this.command = new OleDbCommand(query, this.link);

            while (this.link.State.ToString().ToLower() != "open") { }

            this.dataReader = this.command.ExecuteReader();
            bool a = this.dataReader.Read();
            // ---
            this.command.Dispose();
            this.link.Close();
            // ---
            return a;
        }
        /// <summary>
        /// Checking if there are any results for a specific SELECT query
        /// </summary>
        /// <param name="query">the query string. in-string variables must start with @</param>
        /// <param name="vars">names of the in-string variables in the order they appear in the query</param>
        /// <param name="reps">values of the in-string variables in the order they appear in the query</param>
        /// <returns>true if there are any results and false if not.</returns>
        public bool IsExist(string query, string[] vars, string[] reps)
        {
            while (this.link.State.ToString().ToLower() != "closed") { }

            this.link.Open();
            // ---
            this.command = new OleDbCommand(query, this.link);

            for (int i = 0; i < vars.Length; i++)
                this.command.Parameters.AddWithValue(vars[i], reps[i]);

            while (this.link.State.ToString().ToLower() != "open") { }

            this.dataReader = this.command.ExecuteReader();
            bool a = this.dataReader.Read();
            // ---
            this.command.Dispose();
            this.link.Close();
            // ---
            return a;
        }


        /// <summary>
        /// Returns as a string the value of a cell in an Access table. Mainly good for selecting 1 cell from Database.
        /// </summary>
        /// <param name="query">SELECT query string. in-string variables must start with @</param>
        /// <returns>returns a string with the value that was returned from the SELECT query.</returns>
        public string ExecuteStringRead(string query)
        {
            string output = "";
            this.dataTable = this.ExecuteRead(query);

            foreach (DataRow row in this.dataTable.Rows)
            {
                foreach (object obj in row.ItemArray)
                {
                    output += obj.ToString();
                }
            }

            return output;
        }
        /// <summary>
        /// Returns as a string the value of a cell in an Access table. Mainly good for selecting 1 cell from Database.
        /// </summary>
        /// <param name="query">SELECT query string. in-string variables must start with @</param>
        /// <param name="vars">names of the in-string variables in the order they appear in the query</param>
        /// <param name="reps">values of the in-string variables in the order they appear in the query</param>
        /// <returns>returns a string with the value that was returned from the SELECT query.</returns>
        public string ExecuteStringRead(string query, string[] vars, string[] reps)
        {
            string output = "";
            this.dataTable = this.ExecuteRead(query, vars, reps);

            foreach (DataRow row in this.dataTable.Rows)
            {
                foreach (object obj in row.ItemArray)
                {
                    output += obj.ToString();
                }
            }

            return output;
        }
        /// <summary>
        /// Returns an HTML table code, with all the rows and the values of the results.
        /// </summary>
        /// <param name="query">SELECT query string. in-string variables must start with @</param>        
        /// <param name="vars">names of the in-string variables in the order they appear in the query</param>
        /// <param name="reps">values of the in-string variables in the order they appear in the query</param>
        /// <returns>returns an HTML code of a table with the data that was recieved from the Select query</returns>
        public string ExecuteTableStringRead(string query)
        {
            string output = "<table>";
            // ---
            this.dataTable = this.ExecuteRead(query);
            // ---
            foreach (DataRow row in this.dataTable.Rows)
            {
                output += "<tr>";
                // ---
                foreach (object obj in row.ItemArray)
                {
                    output += "<td>" + obj.ToString() + "</td>";
                }
                // ---
                output += "</tr>";
            }
            // ---
            output += "</table>";
            // ---
            return output;
        }
        /// <summary>
        /// Returns an HTML table code, with all the rows and the values of the results.
        /// </summary>
        /// <param name="query">SELECT query string. in-string variables must start with @</param>        
        /// <param name="vars">names of the in-string variables in the order they appear in the query</param>
        /// <param name="reps">values of the in-string variables in the order they appear in the query</param>
        /// <returns>returns an HTML code of a table with the data that was recieved from the Select query</returns>
        public string ExecuteTableStringRead(string query, string[] vars, string[] reps)
        {
            string output = "";
            int rowN = 0; int objecN = 0;

            output += "<table>";
            this.dataTable = this.ExecuteRead(query, vars, reps);
            foreach (DataRow row in this.dataTable.Rows)
            {
                rowN++; objecN = 0;
                output += "<tr>";
                foreach (object obj in row.ItemArray)
                {
                    objecN++;
                    output += "<td>" + obj.ToString() + "</td>";
                }
                output += "</tr>";
            }
            output += "</table>";

            return output;
        }

        public string ExecuteSpecialTableStringRead(string query)
        {
            string output = "";
            int rowN = 0; int objecN = 0;

            this.dataTable = this.ExecuteRead(query);
            foreach (DataRow row in this.dataTable.Rows)
            {
                rowN++; objecN = 0;
                output += "<tr>";
                foreach (object obj in row.ItemArray)
                {
                    objecN++;
                    if (objecN == row.ItemArray.Length)
                    {
                        if (!String.IsNullOrEmpty(obj.ToString()))
                        {
                            if (obj.ToString() == ".jpeg" || obj.ToString() == ".gif" || obj.ToString() == ".png" || obj.ToString() == ".bmp" || obj.ToString() == ".jpg")
                                output += "<td style='padding: 10px;'><img style='margin:auto;max-width:100px; max-height: 100px;' src='" + "Uploads/" + row.ItemArray[1] + obj.ToString() + "'/ ></td>";

                            else output += "<td style='padding: 10px;'></td>";
                        }
                        else output += "<td style='padding:10px;'></td>";
                    }
                    else output += "<td style='padding: 10px;'>" + obj.ToString() + "</td>";
                }
                output += "<td style='padding: 10px;'><button type='submit' name='Edit" + row.ItemArray[0] + "'>Edit</button></td>";
                output += "<td style='padding: 10px;'><button type='submit' name='Delete" + row.ItemArray[0] + "'>Delete</button></td>";
                output += "</tr>";
            }

            return output;
        }

        #endregion

        #region Private methods
        /// <summary>
        /// This Method will determine the Provider string of the connection string.
        /// </summary>
        /// <param name="version">an integer, enter your office year(2003/2007/2010)</param>
        /// <returns>the provider string</returns>
        private string GetProvider(int version)
        {
            switch (version)
            {
                case 2013:
                case 2010:
                case 2007:
                    return "Microsoft.ACE.OLEDB.12.0";
                case 2003:
                    return "Microsoft.Jet.OLEDB.4.0";
                default:
                    return "Microsoft.ACE.OLEDB.12.0";
            }
        }
        #endregion
    }
}