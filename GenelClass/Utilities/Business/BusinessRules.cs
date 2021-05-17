using GeneralClass.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralClass.Utilities.Business
{
    public class BusinessRules
    {
        //params verdiğimiz zaman RUN içerisinde istediğimiz kadar IResult verebiliriz parametre olarak.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
