/* #########################################################################*/
/* #                                                                       #*/
/* #  This file is part of ConfigurationManager project, which is written  #*/
/* #  as a Script N'Go plug-in to help configuration management of         #*/
/* #  Cisco devices.                                                       #*/
/* #                                                                       #*/
/* #  You may not use this file except in compliance with the license.     #*/
/* #                                                                       #*/
/* #  Copyright Laszlo Frank (c) 2014-2020                                 #*/
/* #                                                                       #*/
/* #########################################################################*/

using Scriptngo.Common;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Scriptngo.ConfigurationManager
{
  /// <summary>
  /// This static class is used for creating new database and metadata for new installations
  /// </summary>
  static class DatabaseManager
  {
    /// <summary>
    /// Checks database and creates it if missing and also creates required DB objects
    /// </summary>
    /// <param name="ServerName">The SQL Server name to connect to</param>
    /// <param name="DatabaseName">The name of the database to check or create</param>
    /// <param name="intSecurity">If integrated security to be used for connection</param>
    /// <param name="sqlUserName">SQL Username for connection</param>
    /// <param name="sqlPassword">SQL Password for connection</param>
    /// <param name="animation">A Backgoundworker to stop before displaying any dialog boxes. Optional</param>
    /// <returns></returns>
    public static bool RegisterDatabase(string ServerName, string DatabaseName, bool intSecurity, string sqlUserName, string sqlPassword, WorkInProgress animation = null)
    {
      bool runResult = true;
      bool DBExists = false;
      bool DBCreated = false;
      bool DBObjectsCreated = false;
      try
      {
        #region Create Database if not exists
        string MasterConnectionString = intSecurity ? string.Format("Data Source={0};Initial Catalog=master;Integrated Security=True", ServerName) :
          string.Format("Data Source={0};Initial Catalog=master;Persist Security Info=True;User ID={1};Password={2}", ServerName, sqlUserName, sqlPassword);
        DebugEx.WriteLine(string.Format("Connecting to master db using : {0}", MasterConnectionString), DebugLevel.Informational);
        using (SqlConnection conn = new SqlConnection(MasterConnectionString))
        {
          try
          {
            conn.Open();
            #region Test database existence
            try
            {
              DebugEx.WriteLine(string.Format("Checking database : {0}", DatabaseName), DebugLevel.Informational);
              SqlCommand scmd = conn.CreateCommand();
              scmd.CommandText = string.Format("SELECT name FROM master.sys.databases WHERE name = N'{0}'", DatabaseName);
              object o = new object();
              o = scmd.ExecuteScalar();
              DBExists = o != null;
              if (!DBExists)
              {
                DebugEx.WriteLine("database doesn't exist", DebugLevel.Informational);
                animation?.Cancel();
                runResult = MessageBox.Show(string.Format("Database {0} does not exists. Do you want to create it now?", DatabaseName), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
                if (runResult) animation?.Run();
              }
              else DebugEx.WriteLine("database exists", DebugLevel.Informational);
            }
            catch (SqlException Ex)
            {
              DebugEx.WriteLine("Unexpected error 1");
              animation?.Cancel();
              MessageBox.Show(string.Format("Unexpected error while checking database {0} : {1} ", DatabaseName, Ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              runResult = false;
            }
            #endregion
            if (runResult & !DBExists)
            {
              #region Create database
              try
              {
                DebugEx.WriteLine(string.Format("Creating database : {0}", DatabaseName), DebugLevel.Informational);
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandText = "CREATE DATABASE " + DatabaseName;
                scmd.ExecuteNonQuery();
                scmd.CommandText = string.Format("ALTER DATABASE {0} SET AUTO_SHRINK ON", DatabaseName);
                scmd.ExecuteNonQuery();
                DBCreated = true;
                DebugEx.WriteLine("database created successfully", DebugLevel.Informational);
              }
              catch (SqlException Ex)
              {
                if (((SqlException)Ex).Number == 1801)
                {
                  DebugEx.WriteLine("database already exists", DebugLevel.Informational);
                }
                else
                {
                  DebugEx.WriteLine("Unexpected error 2");
                  animation?.Cancel();
                  MessageBox.Show(string.Format("Unexpected error while creating database {0} : {1} ", DatabaseName, Ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  runResult = false;
                }
              }
              #endregion
            }
          }
          catch (SqlException Ex)
          {
            DebugEx.WriteLine("Unexpected error 3");
            animation?.Cancel();
            MessageBox.Show(string.Format("Unexpected error while opening connection : {0} ", Ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            runResult = false;
          }
        }
        #endregion

        if (runResult)
        {
          #region Connect to database and create database objects if missing

          string InstallerConnectionString = intSecurity ? string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", ServerName, DatabaseName) :
            string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={1};Password={2}", ServerName, DatabaseName, sqlUserName, sqlPassword);
          DebugEx.WriteLine(string.Format("Connecting using : {0}", InstallerConnectionString), DebugLevel.Informational);
          using (SqlConnection conn = new SqlConnection(InstallerConnectionString))
          {
            conn.Open();
            SqlCommand scmd;
            try
            {
              try
              {
                #region Check if require objects exist
                DebugEx.WriteLine("Checking database objects", DebugLevel.Informational);
                bool RequiredObjectsExist = false;
                // This is to try whether required database objects exist or not
                scmd = new SqlCommand("SELECT COUNT (*) FROM CONFIGTARGETS", conn);
                try
                {
                  object o = new object();
                  o = scmd.ExecuteScalar();
                  RequiredObjectsExist = true;
                }
                catch (SqlException Ex)
                {
                  // Error number 208 is normal, meaning that there is no Params table yet
                  if (((SqlException)Ex).Number == 208)
                  {
                    DebugEx.WriteLine("Error 208 : there is no CONFIGTARGETS table yet");
                  }
                  else
                  {
                    // other exceptions are unexpected and unhandled errors
                    animation?.Cancel();
                    MessageBox.Show(string.Format("Unexpected error while creating database {0} : {1} ", DatabaseName, Ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    runResult = false;
                    throw Ex;
                  }
                }
                #endregion

                #region Run DDL script if required objects do not exist
                if (!RequiredObjectsExist)
                {
                  // this is a new empty database
                  DebugEx.WriteLine("this is a new empty database, running DDL script", DebugLevel.Informational);
                  try
                  {
                    string SqlScript = Resource1.CreateConfigManagerObjects_20151007_v1;
                    SqlScript = SqlScript.Replace("GO", "^");
                    string[] SqlCommands = SqlScript.Split("^".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string command in SqlCommands)
                    {
                      DebugEx.WriteLine(scmd.CommandText);
                      scmd = new SqlCommand(command, conn);
                      scmd.ExecuteNonQuery();
                    }
                    DBObjectsCreated = true;
                    DebugEx.WriteLine("DB objects created sucessfully", DebugLevel.Informational);
                  }
                  catch (Exception Ex)
                  {
                    animation?.Cancel();
                    MessageBox.Show(string.Format("Unexpected error while creating database objects : {0} ", Ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    runResult = false;
                  }
                }
                #endregion
              }
              finally
              {
                conn.Close();
              }
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message, "Sorry, I am unable to register database. Please view debug logs for more details.", MessageBoxButtons.OK, MessageBoxIcon.Error);
              runResult = false;
            }
          }
          #endregion
        }
      }
      catch (Exception ex)
      {
				animation?.Cancel();
        MessageBox.Show("Sorry, I am unable to register database. Please view debug logs for more details. Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        runResult = false;
      }
      if (DBCreated | DBObjectsCreated)
      {
        animation?.Cancel();
        string s = DBCreated ? "Database created sucessfully." : "";
        if (DBObjectsCreated) s += " Required database objects created sucessfully.";
        MessageBox.Show(s, "SQL Operation success", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      return runResult;
    }
  }
}
