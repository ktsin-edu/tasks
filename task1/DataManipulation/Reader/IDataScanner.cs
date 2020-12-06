using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    /// <summary>
    /// Interface for accessing to the saved data
    /// </summary>
    public interface IDataScanner
    {
        /// <summary>
        /// Prepairing before accesing to the source
        /// </summary>
        /// <param name="path">object that describes how ta acces to data source</param>
        /// <returns></returns>
        public bool Open(object path);

        /// <summary>
        /// Read from source to the collector
        /// </summary>
        /// <param name="collector">object that holds  elements that were read</param>
        /// <returns></returns>
        public bool Read(IDataCollector collector);
    }
}
