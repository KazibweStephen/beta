using System;
using System.Data;
using System.Data.SqlClient;

namespace SRN.DAL
{
    /// <summary>
    /// Summary description for DBBridge.
    /// </summary>
    [Serializable]
    public class DBBridge
    {

        private static  DBBridge dbBridge;

        public DBBridge()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DBBridge getSharedInstance() {
            if (dbBridge == null)
                dbBridge = new DBBridge();
            return dbBridge;
        }

        /// <summary>
        /// [METHOD] connect to the db
        /// </summary>
        /// <returns>TRUE, if it is saved</returns>
        public static string DBConnection()
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings["BetConnection"];

            }
            catch (Exception ce)
            {

               throw new ApplicationException("Unable to get DB Connection string from Config File. Contact Administrator" + ce);
            }
        }


        public int ExecuteNonQuery(string storedProcedure, SqlParameter[] param)
        {
            try
            {
                return SqlHelper.ExecuteNonQuery(DBConnection(), CommandType.StoredProcedure, storedProcedure, param);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }

        public int ExecuteNonQuerywithTrans(string storedProcedure, SqlParameter[] param)
        {
            SqlConnection conTrans = new SqlConnection(DBConnection());
            SqlTransaction sqlTrans;
            conTrans.Open();
            int returnResult = 0;
            using (sqlTrans = conTrans.BeginTransaction())
            {
                try
                {
                    returnResult = SqlHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure, param);
                    sqlTrans.Commit();
                    return returnResult;
                }
                catch (Exception sq)
                {
                    sqlTrans.Rollback();
                    throw sq;
                }
                finally
                {
                    conTrans.Close();
                }
            }
        }

        public int ExecuteNonQuery(string storedProcedure)
        {
            try
            {
                return SqlHelper.ExecuteNonQuery(DBConnection(), CommandType.StoredProcedure, storedProcedure);
            }
            catch (SqlException sq)
            {
               throw sq;
            }
        }

        public int ExecuteNonQuerySQL(string sqlquery)
        {
            try
            {
                return SqlHelper.ExecuteNonQuery(DBConnection(), CommandType.Text, sqlquery);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }

        public int ExecuteNonQuerywithTrans(string storedProcedure)
        {
            SqlConnection conTrans = new SqlConnection(DBConnection());
            SqlTransaction sqlTrans;
            conTrans.Open();
            int returnResult = 0;
            using (sqlTrans = conTrans.BeginTransaction())
            {
                try
                {
                    returnResult = SqlHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure);
                    sqlTrans.Commit();
                    return returnResult;
                }
                catch (Exception sq)
                {
                    sqlTrans.Rollback();
                    throw sq;
                }
                finally
                {
                    conTrans.Close();
                }
            }
        }

        public int ExecuteNonQuerywithTransfromFrontEnd(SqlTransaction sqlTrans, string storedProcedure, SqlParameter[] param)
        {
            try
            {
                int returnResult = SqlHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure, param);
                return returnResult;
            }
            catch (SqlException sq)
            {
               sqlTrans.Rollback();
               throw sq;
            }
        }

        public DataSet ExecuteDataset(string storedProcedure, SqlParameter[] param)
        {
            try
            {
                return SqlHelper.ExecuteDataset(DBConnection(), CommandType.StoredProcedure, storedProcedure, param);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }

        public DataSet ExecuteDatasetSQL(string storedProcedure)
        {
            try
            {
                return SqlHelper.ExecuteDataset(DBConnection(), CommandType.Text, storedProcedure);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }

        public DataSet ExecuteDataset(string storedProcedure)
        {
            try
            {
                return SqlHelper.ExecuteDataset(DBConnection(), CommandType.StoredProcedure, storedProcedure);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }

        public object ExecuteScalar(string storedProcedure, SqlParameter[] param)
        {
            try
            {
                return SqlHelper.ExecuteScalar(DBConnection(), CommandType.StoredProcedure, storedProcedure, param);
            }
            catch (SqlException sq)
            {
               throw sq;
            }
        }

        public object ExecuteScalar(SqlTransaction sqlTrans, string storedProcedure, SqlParameter[] param)
        {
            try
            {
                return SqlHelper.ExecuteScalar(sqlTrans, CommandType.StoredProcedure, storedProcedure, param);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }
        public SqlDataReader ExecuteReader(string storedProcedure, SqlParameter[] param)
        {
            SqlDataReader reader = null;
            try
            {
                reader = SqlHelper.ExecuteReader(DBConnection(), CommandType.StoredProcedure, storedProcedure, param);
                return reader;
            }
            catch (SqlException sq)
            {
               throw sq;
            }
        }

        public SqlDataReader ExecuteReader(string storedProcedure)
        {
            SqlDataReader reader = null;
            try
            {
                reader = SqlHelper.ExecuteReader(DBConnection(), CommandType.StoredProcedure, storedProcedure);
                return reader;
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }

        public SqlDataReader ExecuteReaderSQL(string sqlquery)
        {
            SqlDataReader reader = null;
            try
            {
                reader = SqlHelper.ExecuteReader(DBConnection(), CommandType.Text, sqlquery);
                return reader;
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }

        public int ExecuteNonQuerywithMultipleTrans(SqlTransaction sqlTrans, string storedProcedure)
        {
            int returnResult = 0;
            try
            {
                returnResult = SqlHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure);
                return returnResult;
            }
            catch (Exception sq)
            {
                throw sq;
            }
        }

        public int ExecuteNonQuerywithMultipleTrans(SqlTransaction sqlTrans, string storedProcedure, SqlParameter[] param)
        {
            int returnResult = 0;
            try
            {
                returnResult = SqlHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure, param);
                return returnResult;
            }
            catch (Exception sq)
            {
                throw sq;
            }
        }
    }
}

