using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace President.Data.DBInitialize
{
    public static partial class DBInitializer
    {
        public static void Initialize(PresidentContext context)
        {
            try
            {
                var presidents = context.PresidentInfo.ToList();
                presidents.Add(new Domain.PresidentInfo
                {
                    Birthday = new DateTime(1732, 2, 22),
                    Birthplace = "Westmoreland Co., Va.",
                    Deathday = new DateTime(1979, 12, 14),
                    Deathplace = "Mount Vernon, Va.",
                    PresidentName = "George Washington"
                });
                presidents.Add(new Domain.PresidentInfo
                {
                    Birthday = new DateTime(1735, 10, 30),
                    Birthplace = "Quincy, Mass.",
                    Deathday = new DateTime(1826, 7, 4),
                    Deathplace = "Quincy, Mass.",
                    PresidentName = "John Adams"
                });
                context.PresidentInfo.AddRange(presidents);
                context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
    }
}
