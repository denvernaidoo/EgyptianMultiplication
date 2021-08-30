using System;
using System.Collections.Generic;
using System.Linq;

namespace EgyptianMultiplication.Core.Models
{
    /// <summary>
    /// Allows you to multiply numbers using the ancient Egyptian method of multiplication.
    /// </summary>
    public class EgyptianMultiplier
    {
        /// <summary>
        /// Multiplies two positive factors.
        /// </summary>
        /// <param name="factorA">First factor</param>
        /// <param name="factorB">Second factor</param>
        /// <returns>The product of factorA and factorB</returns>
        public long Multiply(int factorA, int factorB)
        {
            if (factorA < 0 || factorB < 0)
            {
                throw new ArgumentOutOfRangeException("Only positive factors are allowed.");
            }

            var allRows = decomposeIntoRows(factorA, factorB);
            var selectedRows = selectRows(allRows, factorA);
            var sum = selectedRows.Sum(r => r.PowerOfTwoProduct);

            return sum;
        }

        private IEnumerable<Row> selectRows(IEnumerable<Row> allRows, int factorA)
        {
            var factorARemainder = factorA;
            var selectedRows = new List<Row>();

            foreach (var row in allRows.Reverse())
            {
                if(row.PowerOfTwo <= factorARemainder)
                {
                    factorARemainder -= row.PowerOfTwo;
                    selectedRows.Add(row);
                }
            }

            return selectedRows;
        }

        private IEnumerable<Row> decomposeIntoRows(int factorA, int factorB)
        {
            var rows = new List<Row>();

            var powerOfTwo = 1;
            var powerOfTwoProduct = factorB;

            while (powerOfTwo <= factorA)
            {
                var row = new Row()
                {
                    PowerOfTwo = powerOfTwo,
                    PowerOfTwoProduct = powerOfTwoProduct
                };

                rows.Add(row);

                powerOfTwo *= 2;
                powerOfTwoProduct *= 2;
            }

            return rows;
        }
    }
}
