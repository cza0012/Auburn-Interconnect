using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

namespace AUInterconnect
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

        public bool IsAdministrator
        {
            get { return IsAdmin(this.uid); }
        }

        public static bool IsAdmin(int userId)
        {
            return (bool)GetScalarValueForUser("isAdmin", userId);
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
            return (string)GetScalarValueForUser("lname", userId);
        }

        /// <summary>
        /// Gets the first name of a user from the database.
        /// </summary>
        /// <param name="userId">The user id of the user</param>
        /// <returns>null if user is not found.</returns>
        /// <exception cref="SqlException"></exception>
        public static string GetFirstName(int userId)
        {
            return (string)GetScalarValueForUser("fname", userId);
        }

        private static object GetScalarValueForUser(String fieldName, int userId)
        {
            using (DbConnection con = DataUtil.GetDbConnection())
            {
                con.Open();
                using (DbCommand command = con.CreateCommand())
                {
                    command.CommandText = "SELECT @param FROM Users WHERE uid=@id";
                    command.CommandType = CommandType.Text;

                    DbParameter param = command.CreateParameter();
                    param.ParameterName = "param";
                    param.Value = fieldName;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "id";
                    param.Value = userId;
                    command.Parameters.Add(param);

                    object obj = command.ExecuteScalar();
                    if (obj == null || obj == DBNull.Value)
                        return null;
                    return obj;
                }
            }
        }

    }
}