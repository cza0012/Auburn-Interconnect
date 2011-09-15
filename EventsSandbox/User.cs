using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EventsSandbox
{
    public class User
    {
        private int uid;
        private bool isAuStud;
        private string fname;
        private string lname;

        public User(int uid)
            : this(uid, false) { }

        public User(int uid, bool auStud)
        {
            this.uid = uid;
            this.isAuStud = auStud;
        }

        public int Uid
        { 
            get { return uid; }
        }

        public bool IsAuStudent
        {
            get { return isAuStud; }
            set { isAuStud = value; }
        }

        public static bool IsAdmin(int userId)
        {
            string queryStr = "SELECT isAdmin FROM Users " +
                "WHERE uid=@id";
            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("id", userId));
                con.Open();
                object obj = command.ExecuteScalar();
                return ((int)obj > 0);
            }
        }

        public string FirstName
        {
            get
            {
                if (fname == null)
                    fname = GetFirstName(uid);
                return fname;
            }
        }

        public string LastName
        {
            get
            {
                if (lname == null)
                    lname = GetLastName(uid);
                return lname;
            }
        }

        /// <summary>
        /// Gets the first name of a user from the database.
        /// </summary>
        /// <param name="userId">The user id of the user</param>
        /// <returns>null if user is not found.</returns>
        /// <exception cref="SqlException"></exception>
        private string GetLastName(int userId)
        {
            string queryStr = "SELECT lname FROM Users " +
                "WHERE uid=@id";

            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("id", userId));
                con.Open();
                object obj = command.ExecuteScalar();
                if (obj == null || obj == DBNull.Value)
                    return null;
                return (string)obj;
            }
        }

        /// <summary>
        /// Gets the first name of a user from the database.
        /// </summary>
        /// <param name="userId">The user id of the user</param>
        /// <returns>null if user is not found.</returns>
        /// <exception cref="SqlException"></exception>
        public static string GetFirstName(int userId)
        {
            string queryStr = "SELECT fname FROM Users " +
                "WHERE uid=@id";

            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("id", userId));
                con.Open();
                object obj = command.ExecuteScalar();
                if (obj == null || obj == DBNull.Value)
                    return null;
                return (string)obj;
            }
        }

    }
}