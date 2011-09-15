using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace EventsSandbox
{
    public class Event
    {
        /// <summary>
        /// Checks if an event is full.
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <returns>true if event is full; false otherwise.
        /// </returns>
        /// <exception cref="SqlException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public static bool IsFull(int eventId)
        {
            int maxRegCount = GetMaxRegs(eventId);
            if (maxRegCount == -1)
                throw new ApplicationException(
                    "Event does not exist");
            if (maxRegCount == -2)
                return false;

            return GetRegCount(eventId) >= maxRegCount;
        }

        /// <summary>
        /// Gets the maximum number of registrations for an event.
        /// </summary>
        /// <param name="eventId">The id of the event</param>
        /// <returns>-1 if event is not found; -2 if maxreg is null;
        /// maxRegs otherwise</returns>
        /// <exception cref="SqlException"></exception>
        public static int GetMaxRegs(int eventId)
        {
            if (!Exists(eventId))
                return -1;

            string queryStr = "SELECT maxReg FROM [Events] WHERE id=@id";
            using(SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("id", eventId));
                con.Open();
                object obj = command.ExecuteScalar();
                if (obj == null || obj == DBNull.Value)
                    return -2;
                return (int)obj;
            }
        }

        /// <summary>
        /// Gets the number of registered participants of this event.
        /// </summary>
        /// <param name="eventId">The event ID</param>
        /// <returns>The number of participants</returns>
        /// <remarks>This method does not check if the event exist in
        /// the database.</remarks>
        public static int GetRegCount(int eventId)
        {
            //TODO: What if event does not exist

            string queryStr = "SELECT COUNT(*) FROM EventRegs " +
                "WHERE eventId=@id";
            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("id", eventId));
                con.Open();
                object obj = command.ExecuteScalar();
                if (obj == null)
                    return -1;
                return (int)obj;
            }
        }

        public static bool Exists(int eventId)
        {
            string queryStr = "SELECT COUNT(*) FROM [Events] " +
                "WHERE id=@id";
            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("id", eventId));
                con.Open();
                object obj = command.ExecuteScalar();
                return ((int)obj > 0);
            }
        }
    }
}