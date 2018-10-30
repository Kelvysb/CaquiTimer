using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDataBase;

namespace CaquiTimer.Layers.Repository
{
    class CaquiTimerRep : IDisposable
    {

        #region Declarations
        private IDataBase objDataBase;
        private string strCommand;
        #endregion

        #region Constructor
        public CaquiTimerRep(string p_strPath)
        {

            string strCompletePath;

            try
            {

                strCompletePath = p_strPath;
                if (!strCompletePath.EndsWith("\\"))
                {
                    strCompletePath = strCompletePath + "\\";
                }

                if (!Directory.Exists(strCompletePath))
                {
                    Directory.CreateDirectory(strCompletePath);
                }

                strCompletePath = strCompletePath + "caqui.db";

                if (!File.Exists(strCompletePath))
                {
                    SQLiteConnection.CreateFile(strCompletePath);
                }

                objDataBase = DataBase.fnOpenConnection(strCompletePath, "caqui.db", "", "", BDataBase.DataBase.enmDataBaseType.SqLite);

                InitializeDataBase();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }       
        #endregion

        #region Functions
        private void InitializeDataBase()
        {
           
            try
            {

                strCommand = "CREATE TABLE IF NOT EXISTS `Work` (" + (char)13;
                strCommand = strCommand + " `Id` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `Name` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `Description` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `Start` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `Finish` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `State` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " PRIMARY KEY(`Id`)" + (char)13;
                strCommand = strCommand + " )" + (char)13;
                try{ objDataBase.sbExecute(strCommand); }catch (Exception){ }

                strCommand = "CREATE TABLE IF NOT EXISTS `Task` (" + (char)13;
                strCommand = strCommand + " `Id` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `WorkId` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `Name` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `Description` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `Start` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `Finish` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `State` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " PRIMARY KEY(`Id`,`WorkId`)" + (char)13;
                strCommand = strCommand + " )" + (char)13;
                try { objDataBase.sbExecute(strCommand); } catch (Exception) { }

                strCommand = "CREATE TABLE IF NOT EXISTS `TimeEvent` (" + (char)13;
                strCommand = strCommand + " `Id` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `TaskId` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `WorkId` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `RelatedId` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `Type` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `Time` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `Name` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `Observation` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " PRIMARY KEY(`TaskId`,`Id`,`WorkId`)" + (char)13;
                strCommand = strCommand + " )" + (char)13;
                try { objDataBase.sbExecute(strCommand); } catch (Exception) { }

                strCommand = "CREATE TABLE IF NOT EXISTS `EventType` (" + (char)13;
                strCommand = strCommand + " `Id` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `Name` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `Type` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " PRIMARY KEY(`Id`)" + (char)13;
                strCommand = strCommand + " )" + (char)13;
                try { objDataBase.sbExecute(strCommand); } catch (Exception) { }

                strCommand = "insert or replace into EventType(Id, Name, type) values (1, 'Task begin', 'BEGIN')";
                try { objDataBase.sbExecute(strCommand); } catch (Exception) { }
                strCommand = "insert or replace into EventType(Id, Name, type) values (2, 'Pomodoro small pause begin', 'BEGIN')";
                try { objDataBase.sbExecute(strCommand); } catch (Exception) { }
                strCommand = "insert or replace into EventType(Id, Name, type) values (3, 'Pomodoro small Pause end', 'END')";
                try { objDataBase.sbExecute(strCommand); } catch (Exception) { }
                strCommand = "insert or replace into EventType(Id, Name, type) values (4, 'Pomodoro big pause begin', 'BEGIN')";
                try { objDataBase.sbExecute(strCommand); } catch (Exception) { }
                strCommand = "insert or replace into EventType(Id, Name, type) values (5, 'Pomodoro big Pause end', 'END')";
                try { objDataBase.sbExecute(strCommand); } catch (Exception) { }
                strCommand = "insert or replace into EventType(Id, Name, type) values (6, 'Task Stop', 'BEGIN')";
                try { objDataBase.sbExecute(strCommand); } catch (Exception) { }
                strCommand = "insert or replace into EventType(Id, Name, type) values (7, 'Task Restart', 'END')";
                try { objDataBase.sbExecute(strCommand); } catch (Exception) { }
                strCommand = "insert or replace into EventType(Id, Name, type) values (8, 'Task Canceled', 'END')";
                try { objDataBase.sbExecute(strCommand); } catch (Exception) { }
                strCommand = "insert or replace into EventType(Id, Name, type) values (9, 'Task end', 'END')";
                try { objDataBase.sbExecute(strCommand); } catch (Exception) { }


            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                if (objDataBase != null)
                {
                    objDataBase.sbClose();
                    objDataBase = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Properties

        #endregion
    }
}
