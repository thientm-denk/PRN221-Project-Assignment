using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OderDetailDAO
    {
        private static OderDetailDAO instance = null;
        private static object instanceLook = new object();

        public static OderDetailDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new OderDetailDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
