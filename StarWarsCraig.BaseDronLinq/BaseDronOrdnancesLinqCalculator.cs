using StarWarsCraig.BaseDron;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsCraig.BaseDronLinq
{
    public class BaseDronOrdnancesLinqCalculator : BaseDronOrdnancesCalculator
    {
        public BaseDronOrdnancesLinqCalculator() : base() { }
        public BaseDronOrdnancesLinqCalculator(BaseDronEntity baseDron) : base(baseDron) { }

        /// <summary>
        /// Executes algorithm.
        /// </summary>
        /// <returns>The result of execution.</returns>
        protected override int Execute()
        {
            var tops = GetTops();
            var orderedDistances = GetOrderedDistances(tops);
            var result = CalculateMaxOrdnances(tops.Count(), orderedDistances.ToArray());

            return result;
        }

        /// <summary>
        /// Gets the tops of points array.
        /// </summary>
        /// <returns>The tops.</returns>
        private IEnumerable<int> GetTops()
        {
            var topsList = new List<int>();

            var i = 0;
            while (i < base._baseDron.Points.Length)
            {
                if (i == 0 || i == _baseDron.Points.Length - 1)
                {
                    i++;
                }
                else
                {
                    var isTop = (_baseDron.Points[i] > _baseDron.Points[i - 1] && _baseDron.Points[i] > _baseDron.Points[i + 1]);
                    
                    if (isTop) { 
                        topsList.Add(i);
                        i += 2; 
                    }
                    else { i++; }
                }
            }

            return topsList;
        }

        /// <summary>
        /// Gets ordered distances into array.
        /// </summary>
        /// <param name="tops">The tops of points.</param>
        /// <returns>The ordered distances.</returns>
        private IEnumerable<int> GetOrderedDistances(IEnumerable<int> tops)
        {
            var distancesList = new List<int>();

            foreach (var top in tops.OrderBy(x=>x))
            {
                if (tops.Any(x => x < top)) { distancesList.Add(Math.Abs(top - tops.Where(x => x < top).OrderByDescending(x => x).First())); }
            }

            return distancesList.OrderByDescending(x => x);
        }

    }
}
