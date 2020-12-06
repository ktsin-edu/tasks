using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
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
        public void Push(GenericProduct product);
        /// <summary>
        /// getting the source array
        /// </summary>
        /// <returns> source array </returns>
        public GenericProduct[] GetSource();
    }
}
