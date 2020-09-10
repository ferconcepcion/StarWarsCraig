using StarWarsCraig.ValidationPattern;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsCraig.BaseDron
{
    public class BaseDronEntity : Validable
    {
        public int[] Points { get; }

        public BaseDronEntity() { Points = new int[0]; }

        public BaseDronEntity(int[] points)
        {
            Points = points;
        }

        public override bool Validate(out IEnumerable<string> errors)
        {
            var listErrors = new List<string>();

            /* 
             * Array no nulo y > 0 elementos, menor que 400.000.
             * Cada elemento debe estar entre 0 y 1.000.000.000.
             */

            if (Points == null) { listErrors.Add("Array no debe ser nulo"); }
            else
            {
                if (Points.Length <= 0) { listErrors.Add("Array no debe ser vacío!"); }
                if (Points.Length > 400000) { listErrors.Add("Array no debe contener más de 400.000 elementos!"); }

                for (var i = 0; i < Points.Length; i++)
                {
                    if (Points[i] < 0) { listErrors.Add(string.Format("La altura del elemento {0} ha de ser mayor o igual que 0", i)); }
                    if (Points[i] > 1000000000) { listErrors.Add(string.Format("La altura del elemento {0} no debe superar los 1.000.000.000", i)); }
                }
            }

            errors = listErrors;

            return !listErrors.Any();
        }

    }
}
