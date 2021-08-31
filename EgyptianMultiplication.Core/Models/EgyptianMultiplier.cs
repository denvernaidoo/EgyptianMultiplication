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
        /// <param name="A">First factor</param>
        /// <param name="B">Second factor</param>
        /// <returns>The product of factorA and factorB</returns>
        public long Multiply(int A, int B)
        {
            bool isPositive = isProductPostive(A, B);
            int factorA = Math.Abs(A);
            int factorB = Math.Abs(B);

            var allRows = decomposeIntoRows(factorA, factorB);
            var selectedRows = selectRows(allRows, factorA);
            var sum = selectedRows.Sum(r => r.PowerOfTwoProduct) * (isPositive ? 1 : -1);

            return sum;
        }

        private bool isProductPostive(int A, int B) => ((A >= 0 && B >= 0) || (A < 0 && B < 0));

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
