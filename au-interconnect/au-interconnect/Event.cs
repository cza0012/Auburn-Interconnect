﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AUInterconnect
{
    public class Event
    {
        public const int EventCapacityUnlimited = -2;

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
            int maxRegCount = GetGuestLimit(eventId);
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
        /// <returns>
        /// -1 if event is not found;
        /// -2 if maxreg is null (EventCapacityUnlimited);
        /// event capacity otherwise</returns>
        /// <exception cref="SqlException"></exception>
        public static int GetGuestLimit(int eventId)
        {
            if (!Exists(eventId))
                return -1;

            string queryStr = "SELECT guestLimit FROM [Events] WHERE eventId=@eventId";
            using(SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("eventId", eventId));
                con.Open();
                object obj = command.ExecuteScalar();
                if (obj == null || obj == DBNull.Value)
                    return EventCapacityUnlimited;
                return (int)obj;
            }
        }

        /// <summary>
        /// Gets the number of registered of this event.
        /// </summary>
        /// <param name="eventId">The event ID</param>
        /// <returns>The number of registrations</returns>
        /// <remarks>The number of registration is not the number of
        /// participants of this event since each registration could have
        /// multiple participants.
        /// 
        /// This method does not check if the event exist in
        /// the database.</remarks>
        public static int GetRegCount(int eventId)
        {
            //TODO: What if event does not exist

            string queryStr = "SELECT COUNT(*) FROM EventRegs " +
                "WHERE eventId=@eventId";
            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("eventId", eventId));
                con.Open();
                object obj = command.ExecuteScalar();
                if (obj == null)
                    return -1;
                return (int)obj;
            }
        }


        public static int GetHeadCount(int eventId)
        {
            //TODO: consider moving this method to a new Registration class.
            //TODO: what if event does not exist?

            string queryStr = "SELECT SUM(headCount) FROM EventRegs " +
                "WHERE eventId=@eventId";
            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("eventId", eventId));
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
                "WHERE eventId=@eventId";
            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("eventId", eventId));
                con.Open();
                object obj = command.ExecuteScalar();
                return ((int)obj > 0);
            }
        }

        /// <summary>
        /// Check if a user has created an event. This is a rough check of
        /// if the user is a host.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>
        /// true if user created an event; false otherwise.
        /// </returns>
        public static bool UserProposedEvent(int userId)
        {
            string queryStr = "SELECT COUNT(*) FROM [Events] " +
                "WHERE creatorId=@userId";
            using (SqlConnection con = new SqlConnection(Config.SqlConStr))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                command.Parameters.Add(new SqlParameter("userId", userId));
                con.Open();
                object obj = command.ExecuteScalar();
                return ((int)obj >= 1);
            }
        }
    }
}