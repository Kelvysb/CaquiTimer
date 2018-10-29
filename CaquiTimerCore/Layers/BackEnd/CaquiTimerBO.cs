using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaquiTimer
{
    public class CaquiTimerBO
    {

        #region Declarations
        private static CaquiTimerBO instance;
        private string strWorkDirectory;
        #endregion

        #region Constructor
        public CaquiTimerBO()
        {
            try
            {
                strWorkDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CaquiTimer\\";
                if (Directory.Exists(strWorkDirectory) == false)
                {
                    Directory.CreateDirectory(strWorkDirectory);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Events

        #endregion

        #region Functions
        private static CaquiTimerBO getInstance()
        {
            try
            {
                if (instance == null)
                {
                    instance = new CaquiTimerBO();
                }

                return instance;
            }
            catch (Exception)
            {
                throw;
            }
        }



        #endregion

        #region Properties
        public static CaquiTimerBO Instance { get => getInstance(); }
        public string WorkDirectory { get => strWorkDirectory; }
        #endregion

    }
}
