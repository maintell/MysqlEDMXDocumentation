using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MySql.Data.MySqlClient;

namespace MysqlEDMXDocumentation
{
    public sealed partial class MySqlHelper
    {
        public static int BatchSize = 2000;
        public static int CommandTimeOut = 600;
        public MySqlHelper(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }
        #region ExecuteNonQuery
        public int ExecuteNonQuery(string commandText, params MySqlParameter[] parms)
        {
            return ExecuteNonQuery(ConnectionString, CommandType.Text, commandText, parms);
        }
        public int ExecuteNonQuery(CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteNonQuery(ConnectionString, commandType, commandText, parms);
        }
        #endregion ExecuteNonQuery
        #region ExecuteScalar
        public T ExecuteScalar<T>(string commandText, params MySqlParameter[] parms)
        {
            return ExecuteScalar<T>(ConnectionString, commandText, parms);
        }
        public object ExecuteScalar(string commandText, params MySqlParameter[] parms)
        {
            return ExecuteScalar(ConnectionString, CommandType.Text, commandText, parms);
        }
        public object ExecuteScalar(CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteScalar(ConnectionString, commandType, commandText, parms);
        }
        #endregion ExecuteScalar

        #region ExecuteDataReader
        private MySqlDataReader ExecuteDataReader(string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataReader(ConnectionString, CommandType.Text, commandText, parms);
        }
        private MySqlDataReader ExecuteDataReader(CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataReader(ConnectionString, commandType, commandText, parms);
        }
        #endregion
        #region ExecuteDataRow
        public DataRow ExecuteDataRow(string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataRow(ConnectionString, CommandType.Text, commandText, parms);
        }

        
        public DataRow ExecuteDataRow(CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataRow(ConnectionString, commandType, commandText, parms);
        }

        #endregion ExecuteDataRow
        #region ExecuteDataTable
        public DataTable ExecuteDataTable(string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataTable(ConnectionString, CommandType.Text, commandText, parms);
        }
        public DataTable ExecuteDataTable(CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataSet(ConnectionString, commandType, commandText, parms).Tables[0];
        }

        #endregion ExecuteDataTable

        #region ExecuteDataSet
        public DataSet ExecuteDataSet(string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataSet(ConnectionString, CommandType.Text, commandText, parms);
        }
        public DataSet ExecuteDataSet(CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataSet(ConnectionString, commandType, commandText, parms);
        }

        #endregion ExecuteDataSet
        public void BatchUpdate(DataTable table)
        {
            BatchUpdate(ConnectionString, table);
        }
        public int BulkInsert(DataTable table)
        {
            return BulkInsert(ConnectionString, table);
        }
        private static void PrepareCommand(MySqlCommand command, MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, MySqlParameter[] parms)
        {
            if (connection.State != ConnectionState.Open) connection.Open();

            command.Connection = connection;
            command.CommandTimeout = CommandTimeOut;
            command.CommandText = commandText;
            if (transaction != null)
            {
                command.Transaction = transaction;
            }
            command.CommandType = commandType;
            if (parms != null && parms.Length > 0)
            {
                foreach (MySqlParameter parameter in parms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                }
                command.Parameters.AddRange(parms);
            }
        }

        #region ExecuteNonQuery

       
        public static int ExecuteNonQuery(string connectionString, string commandText, params MySqlParameter[] parms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                return ExecuteNonQuery(connection, CommandType.Text, commandText, parms);
            }
        }

        
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                return ExecuteNonQuery(connection, commandType, commandText, parms);
            }
        }

      
        public static int ExecuteNonQuery(MySqlConnection connection, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteNonQuery(connection, null, commandType, commandText, parms);
        }

       
        public static int ExecuteNonQuery(MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteNonQuery(transaction.Connection, transaction, commandType, commandText, parms);
        }

       
        private static int ExecuteNonQuery(MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            MySqlCommand command = new MySqlCommand();
            PrepareCommand(command, connection, transaction, commandType, commandText, parms);
            int retval = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return retval;
        }

        #endregion ExecuteNonQuery

        #region ExecuteScalar

        
        public static T ExecuteScalar<T>(string connectionString, string commandText, params MySqlParameter[] parms)
        {
            object result = ExecuteScalar(connectionString, commandText, parms);
            if (result != null)
            {
                return (T)Convert.ChangeType(result, typeof(T)); ;
            }
            return default(T);
        }

       
        public static object ExecuteScalar(string connectionString, string commandText, params MySqlParameter[] parms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                return ExecuteScalar(connection, CommandType.Text, commandText, parms);
            }
        }

        
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                return ExecuteScalar(connection, commandType, commandText, parms);
            }
        }

       
        public static object ExecuteScalar(MySqlConnection connection, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteScalar(connection, null, commandType, commandText, parms);
        }

        
        public static object ExecuteScalar(MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteScalar(transaction.Connection, transaction, commandType, commandText, parms);
        }

       
        private static object ExecuteScalar(MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            MySqlCommand command = new MySqlCommand();
            PrepareCommand(command, connection, transaction, commandType, commandText, parms);
            object retval = command.ExecuteScalar();
            command.Parameters.Clear();
            return retval;
        }

        #endregion ExecuteScalar

        #region ExecuteDataReader

       
        private static MySqlDataReader ExecuteDataReader(string connectionString, string commandText, params MySqlParameter[] parms)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            return ExecuteDataReader(connection, null, CommandType.Text, commandText, parms);
        }

       
        private static MySqlDataReader ExecuteDataReader(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            return ExecuteDataReader(connection, null, commandType, commandText, parms);
        }

       
        private static MySqlDataReader ExecuteDataReader(MySqlConnection connection, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataReader(connection, null, commandType, commandText, parms);
        }

        
        private static MySqlDataReader ExecuteDataReader(MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataReader(transaction.Connection, transaction, commandType, commandText, parms);
        }

       
        private static MySqlDataReader ExecuteDataReader(MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            MySqlCommand command = new MySqlCommand();
            PrepareCommand(command, connection, transaction, commandType, commandText, parms);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        #endregion

        #region ExecuteDataRow

       
        public static DataRow ExecuteDataRow(string connectionString, string commandText, params MySqlParameter[] parms)
        {
            DataTable dt = ExecuteDataTable(connectionString, CommandType.Text, commandText, parms);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
        
        public static DataRow ExecuteDataRow(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            DataTable dt = ExecuteDataTable(connectionString, commandType, commandText, parms);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        
        public static DataRow ExecuteDataRow(MySqlConnection connection, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            DataTable dt = ExecuteDataTable(connection, commandType, commandText, parms);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        
        public static DataRow ExecuteDataRow(MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            DataTable dt = ExecuteDataTable(transaction, commandType, commandText, parms);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        #endregion ExecuteDataRow

        #region ExecuteDataTable

        
        public static DataTable ExecuteDataTable(string connectionString, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataSet(connectionString, CommandType.Text, commandText, parms).Tables[0];
        }

       
        public static DataTable ExecuteDataTable(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataSet(connectionString, commandType, commandText, parms).Tables[0];
        }

       
        public static DataTable ExecuteDataTable(MySqlConnection connection, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataSet(connection, commandType, commandText, parms).Tables[0];
        }

      
        public static DataTable ExecuteDataTable(MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataSet(transaction, commandType, commandText, parms).Tables[0];
        }

       
        public static DataTable ExecuteEmptyDataTable(string connectionString, string tableName)
        {
            return ExecuteDataSet(connectionString, CommandType.Text, string.Format("select * from {0} where 1=-1", tableName)).Tables[0];
        }

        #endregion ExecuteDataTable

        #region ExecuteDataSet

        
        public static DataSet ExecuteDataSet(string connectionString, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataSet(connectionString, CommandType.Text, commandText, parms);
        }

        
        public static DataSet ExecuteDataSet(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                return ExecuteDataSet(connection, commandType, commandText, parms);
            }
        }

        
        public static DataSet ExecuteDataSet(MySqlConnection connection, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataSet(connection, null, commandType, commandText, parms);
        }

       
        public static DataSet ExecuteDataSet(MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            return ExecuteDataSet(transaction.Connection, transaction, commandType, commandText, parms);
        }

       
        private static DataSet ExecuteDataSet(MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] parms)
        {
            MySqlCommand command = new MySqlCommand();

            PrepareCommand(command, connection, transaction, commandType, commandText, parms);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (commandText.IndexOf("@") > 0)
            {
                commandText = commandText.ToLower();
                int index = commandText.IndexOf("where ");
                if (index < 0)
                {
                    index = commandText.IndexOf("\nwhere");
                }
                if (index > 0)
                {
                    ds.ExtendedProperties.Add("SQL", commandText.Substring(0, index - 1));  
                }
                else
                {
                    ds.ExtendedProperties.Add("SQL", commandText); 
                }
            }
            else
            {
                ds.ExtendedProperties.Add("SQL", commandText);  
            }

            foreach (DataTable dt in ds.Tables)
            {
                dt.ExtendedProperties.Add("SQL", ds.ExtendedProperties["SQL"]);
            }

            command.Parameters.Clear();
            return ds;
        }

        #endregion ExecuteDataSet
        

       
        public static void BatchUpdate(string connectionString, DataTable table)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand command = connection.CreateCommand();
            command.CommandTimeout = CommandTimeOut;
            command.CommandType = CommandType.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            MySqlCommandBuilder commandBulider = new MySqlCommandBuilder(adapter);
            commandBulider.ConflictOption = ConflictOption.OverwriteChanges;

            MySqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                adapter.UpdateBatchSize = BatchSize;
                adapter.SelectCommand.Transaction = transaction;

                if (table.ExtendedProperties["SQL"] != null)
                {
                    adapter.SelectCommand.CommandText = table.ExtendedProperties["SQL"].ToString();
                }
                adapter.Update(table);
                transaction.Commit();
            }
            catch (MySqlException ex)
            {
                if (transaction != null) transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

       
        public static int BulkInsert(string connectionString, DataTable table)
        {
            if (string.IsNullOrEmpty(table.TableName)) throw new Exception("请给DataTable的TableName属性附上表名称");
            if (table.Rows.Count == 0) return 0;
            int insertCount = 0;
            string tmpPath = Path.GetTempFileName();
            string csv = DataTableToCsv(table);
            File.WriteAllText(tmpPath, csv);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlTransaction tran = null;
                try
                {
                    conn.Open();
                    tran = conn.BeginTransaction();
                    MySqlBulkLoader bulk = new MySqlBulkLoader(conn)
                    {
                        FieldTerminator = ",",
                        FieldQuotationCharacter = '"',
                        EscapeCharacter = '"',
                        LineTerminator = "\r\n",
                        FileName = tmpPath,
                        NumberOfLinesToSkip = 0,
                        TableName = table.TableName,
                    };
                    bulk.Columns.AddRange(table.Columns.Cast<DataColumn>().Select(colum => colum.ColumnName).ToList());
                    insertCount = bulk.Load();
                    tran.Commit();
                }
                catch (MySqlException ex)
                {
                    if (tran != null) tran.Rollback();
                    throw ex;
                }
            }
            File.Delete(tmpPath);
            return insertCount;
        }

       
        private static string DataTableToCsv(DataTable table)
        {
            StringBuilder sb = new StringBuilder();
            DataColumn colum;
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    colum = table.Columns[i];
                    if (i != 0) sb.Append(",");
                    if (colum.DataType == typeof(string) && row[colum].ToString().Contains(","))
                    {
                        sb.Append("\"" + row[colum].ToString().Replace("\"", "\"\"") + "\"");
                    }
                    else sb.Append(row[colum].ToString());
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

       

    }

}
