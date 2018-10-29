using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDataBase;

namespace CaquiTimer.Layers.Repository
{
    class CaquiTimerRep
    {

        #region Declarations
        private IDataBase objDataBase;


        #endregion

        #region Constructor
        public CaquiTimerRep(string p_strPath)
        {
            objDataBase = DataBase.fnOpenConnection(p_strPath, "caqui.db", "", "", BDataBase.DataBase.enmDataBaseType.SqLite);
        }
        #endregion

        #region Functions
        public void InitializeDataBase()
        {

            string strCommand;

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
                objDataBase.sbExecute(strCommand);

                strCommand = "CREATE TABLE  TABLE IF NOT EXISTS `Task` (" + (char)13;
                strCommand = strCommand + " `Id` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `WorkId` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `Name` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `Description` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `Start` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `Finish` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `State` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " PRIMARY KEY(`Id`,`WorkId`)" + (char)13;
                strCommand = strCommand + " )" + (char)13;
                objDataBase.sbExecute(strCommand);

                strCommand = "CREATE TABLE  TABLE IF NOT EXISTS `TimeEvent` (" + (char)13;
                strCommand = strCommand + " `TaskId` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `WorkId` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `Id` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `RelatedId` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `Type` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `Time` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `Name` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `Observation` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " PRIMARY KEY(`TaskId`,`Id`,`WorkId`)" + (char)13;
                strCommand = strCommand + " )" + (char)13;
                objDataBase.sbExecute(strCommand);

                strCommand = "CREATE TABLE  TABLE IF NOT EXISTS `EventType` (" + (char)13;
                strCommand = strCommand + " `Id` INTEGER NOT NULL," + (char)13;
                strCommand = strCommand + " `Name` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " `Type` TEXT NOT NULL," + (char)13;
                strCommand = strCommand + " PRIMARY KEY(`Id`)" + (char)13;
                strCommand = strCommand + " )" + (char)13;
                objDataBase.sbExecute(strCommand);

                strCommand = "insert or replace into EventType(Id, Name, type) values (1, 'Task begin', 'BEGIN')";
                objDataBase.sbExecute(strCommand);
                strCommand = "insert or replace into EventType(Id, Name, type) values (2, 'Pomodoro small pause begin', 'BEGIN')";
                objDataBase.sbExecute(strCommand);
                strCommand = "insert or replace into EventType(Id, Name, type) values (3, 'Pomodoro small Pause end', 'END')";
                objDataBase.sbExecute(strCommand);
                strCommand = "insert or replace into EventType(Id, Name, type) values (4, 'Pomodoro big pause begin', 'BEGIN')";
                objDataBase.sbExecute(strCommand);
                strCommand = "insert or replace into EventType(Id, Name, type) values (5, 'Pomodoro big Pause end', 'END')";
                objDataBase.sbExecute(strCommand);
                strCommand = "insert or replace into EventType(Id, Name, type) values (6, 'Task Stop', 'BEGIN')";
                objDataBase.sbExecute(strCommand);
                strCommand = "insert or replace into EventType(Id, Name, type) values (7, 'Task Restart', 'END')";
                objDataBase.sbExecute(strCommand);
                strCommand = "insert or replace into EventType(Id, Name, type) values (8, 'Task Canceled', 'END')";
                objDataBase.sbExecute(strCommand);
                strCommand = "insert or replace into EventType(Id, Name, type) values (9, 'Task end', 'END')";
                objDataBase.sbExecute(strCommand);


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
