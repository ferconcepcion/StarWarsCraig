using StarWarsCraig.Extension;
using StarWarsCraig.ValidationPattern;
using System;
using System.Collections.Generic;

namespace StarWarsCraig.BaseDron
{
    public class BaseDronOrdnancesCalculator : Executable<int>, IBaseDronOrdnancesCalculator
    {
        protected readonly BaseDronEntity _baseDron;

        public BaseDronOrdnancesCalculator() { _baseDron = new BaseDronEntity(); }

        public BaseDronOrdnancesCalculator(BaseDronEntity baseDron) 
        {
            _baseDron = baseDron;
        }

        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <param name="errors">If it´s not valid, the errors.</param>
        /// <returns>The result of validation.</returns>
        public override bool Validate(out IEnumerable<string> errors)
        {
            return _baseDron.Validate(out errors);
        }

        /// <summary>
        /// Executes algorithm.
        /// </summary>
        /// <returns>The result of execution.</returns>
        protected override int Execute()
        {
            var tops = GetTops();
            var orderedDistances = GetOrderedDistances(tops);
            var result = CalculateMaxOrdnances(CountTops(tops), orderedDistances);

            return result;
        }

        /// <summary>
        /// Gets top array with True/false values (is o isn´t top).
        /// </summary>
        /// <returns>Top array with True/false values (is o isn´t top).</returns>
        private bool[] GetTops()
        {
            bool[] tops = new bool[_baseDron.Points.Length];

            /*
             * Cumbres son elementos del array que no son extremos y que son más altos que el anterior y sucesivo. 
             */

            var i = 0;
            while (i < _baseDron.Points.Length)
            {
                if (i == 0 || i == _baseDron.Points.Length - 1) 
                { 
                    tops[i] = false;
                    i++;
                }
                else
                {
                    var isTop = (_baseDron.Points[i] > _baseDron.Points[i - 1] && _baseDron.Points[i] > _baseDron.Points[i + 1]);
                    tops[i] = isTop;
                    
                    if (isTop) // Si es una cumbre, el siguiente elemento no puede serlo, puedo avanzar una casilla extra...
                    { 
                        tops[i + 1] = false;
                        i += 2; 
                    } 
                    else { i++; }
                }
            }

            return tops;
        }

        /// <summary>
        /// Gets ordered distances into array.
        /// </summary>
        /// <param name="tops">True/false tops array.</param>
        /// <returns>The ordered distances.</returns>
        private int[] GetOrderedDistances(bool[] tops)
        {
            var lastTop = -1;
            int[] distances = new int[_baseDron.Points.Length];

            for (var i = 0; i < _baseDron.Points.Length; i++)
            {
                if (i == 0 || i == _baseDron.Points.Length - 1) { distances[i] = 0; }
                else if (tops[i])
                {
                    if (lastTop == -1)
                    { 
                        distances[i] = 0;
                    }
                    else
                    {
                        distances[i] = Math.Abs(lastTop - i);
                    }
                    lastTop = i;
                }
                else distances[i] = 0;
            }

            distances = distances.Order();

            return distances;
        }

        /// <summary>
        /// Gets the number of tops.
        /// </summary>
        /// <param name="tops">True/false tops array.</param>
        /// <returns>The number of tops.</returns>
        private int CountTops(bool[] tops)
        {
            var totalTops = 0;
            var i = 0;
            while (i < tops.Length)
            {
                if (i != 0 && i != tops.Length - 1)
                {
                    if (tops[i]) { totalTops++; i += 2; } else { i++; }
                }
                else { i++; }
            }

            return totalTops;
        }

        /// <summary>
        /// Gets the maximun number of ordnances.
        /// </summary>
        /// <param name="totalTops">The number of tops.</param>
        /// <param name="orderedDistances">The ordered distances between tops.</param>
        /// <returns>The maximun number of ordnances.</returns>
        protected int CalculateMaxOrdnances(int totalTops, int[] orderedDistances)
        {
            var maxFound = 0;

            if (totalTops <= 1) { return totalTops; } // Si no hay cumbres, no hay cañones que colocar, en caso de haber una podemos colocarla allí.

            // Empezamos intentando colocar tantos cañones como cumbres hay, si es posible, vamos comprobando distancias.
            // Si no es posible, intentamos colocar un cañón menos.

            for (var i = totalTops; i > 0; i--)
            {
                var available = 1; // Nº de cumbres disponibles para colocar cañones, inicialmente 1.
                var acumulatedDistance = 0; // Distancia acumulada hasta el cálculo de la siguiente cumbre.

                // Si para un nº de cañones mayor, tenemos los mismos cañones que intentamos colocar ahora, no hace falta volverlo a calcular
                if (i == maxFound) { return maxFound; } 
                
                for (var j = 0; j < i; j++)
                {
                    if (j >= orderedDistances.Length || orderedDistances[j] == 0) //Si no hay más distancias, ya no se pueden poner más cañones...
                    {
                        maxFound = available;
                        break;
                    }

                    if (orderedDistances[j] + acumulatedDistance >= i) // Si la distancia acumulada es mayor que el nº de cumbres, se puede colocar cañón.
                    {
                        available++;
                        acumulatedDistance = 0; // Reseteamos la distancia al acumular.

                        if (available == i) return i; // Si hemos llegado al tope de cumbres, ya habríamos terminado.
                    }
                    else
                    {
                        acumulatedDistance += orderedDistances[j]; // Si la distancia acumulada es insuficiente, acumulamos dicha distancia.
                    }
                }
            }

            return 0;
        }
    }
}
