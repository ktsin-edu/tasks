using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.DataClasses;

namespace task1.Reader
{
    /// <summary>
    /// Interface for collectors of BasicProducts
    /// </summary>
    public interface IDataCollector
    {
        /// <summary>
        /// Adds instance of BasicProduct to current collector
        /// </summary>
        /// <param name="product">instance of BasicProduct</param>
        public void Push(BasicProduct product);
        /// <summary>
        /// getting the source array
        /// </summary>
        /// <returns> source array </returns>
        public BasicProduct[] GetSource();
    }
}
