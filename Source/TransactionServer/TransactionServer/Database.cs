using System;
using System.Data;
using System.Data.SqlClient;

namespace TransactionServer {
    public class Database {
        protected string database = "LibraryTransactions";
        protected String username = "ForeRunner";
        protected String password = "mywins13";

        public SqlDataReader reader = null;

        private SqlConnection con = null;
        public Database() {
            con=new SqlConnection("server=localhost;database="+database+";User Id="+username+";Password="+password);
        }
        public Boolean establishConnection() {//Establish the SQL Connection
            con.Open();
            if(con.State != ConnectionState.Open) {
                con.Close();
                con.Open();
                return true;
            }
            return false;
        }
        public void closeConnection() {//Close Opened Connection
            con.Close();
        }

        public int numberOfRows(String table, String where) {//Count the Number of rows
            int count = 0;
            establishConnection();

            reader = Select("*", table, where).ExecuteReader();
            while(reader.Read()) {
                count++;
            }
            closeConnection();
            return count;
        }

        public int getMaxID(String column, String table) {//Get Maximum Auto Generate Id
            establishConnection();
            reader = Select("MAX(" + column + ")", table).ExecuteReader();//Get Maxiumum Id Number
            reader.Read();

            int count = 1;
            object a = reader.GetValue(0);
            if(a != DBNull.Value)
                count = Convert.ToInt16(a) + 1;
            closeConnection();

            return count;
        }

        public int Insert(String columns, String values, String table) {//Insert statement with columns specified
            establishConnection();
            SqlCommand query = new SqlCommand("INSERT INTO " + table + " (" + columns + ") VALUES(" + values + ")", con);
            return query.ExecuteNonQuery();
        }
        public int Insert(String values, String table) {//Insert Statement with no Columns specified
            establishConnection();
            SqlCommand query = new SqlCommand("INSERT INTO " + table + " VALUES(" + values + ")", con);
            return query.ExecuteNonQuery();
        }

        public int Update(String column, String value, String Condition, String table) {//Update data of a table, Columns[0] = Column to set value, Columns[1] = Condition column
            establishConnection();
            SqlCommand query = new SqlCommand("UPDATE " + table + " SET " + column + " = " + value + " WHERE " + Condition, con);
            return query.ExecuteNonQuery();
        }
        public int Update(String columnV, String Condition, String table) {//Update data of a table multiple columns
            establishConnection();
            SqlCommand query = new SqlCommand("UPDATE " + table + " SET " + columnV + " WHERE " + Condition, con);
            return query.ExecuteNonQuery();
        }

        public int Delete(String table, String condition) {//Delete record(s) from database
            establishConnection();
            SqlCommand query = new SqlCommand("DELETE FROM " + table + " WHERE " + condition, con);
            return query.ExecuteNonQuery();
        }


        public SqlCommand Select(String columns, String table) {//Select Statement with no Where Clause
            return new SqlCommand("SELECT " + columns + " FROM " + table, con);
        }
        public SqlCommand Select(String columns, String table, String where) {//Select Statement with Where Clause
            return new SqlCommand("SELECT " + columns + " FROM " + table + " WHERE " + where, con);
        }
    }
}