using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.Writer
{
    /// <summary>
    /// Basic interface for saving state of IDataCollector
    /// </summary>
    public interface IDataWriter
    {
        /// <summary>
        /// Preparing before writing
        /// </summary>
        /// <param name="path">an object that describes where to save data</param>
        /// <returns></returns>
        public bool Open(object path);

        /// <summary>
        /// Method for saving state of IDataCollector
        /// </summary>
        /// <param name="collector">class that implements IDataCollector interface</param>
        /// <returns></returns>
        public bool Write(Reader.IDataCollector collector);
    }
}
