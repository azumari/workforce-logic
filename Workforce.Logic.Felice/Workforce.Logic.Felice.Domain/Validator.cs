using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Felice.Domain
{
   public class Validator
   {
      public bool ValidateString(string newString, int maxLength)
      {
         if (newString == string.Empty || newString.Length > maxLength)
         {
            return false;
         }
         else
         {
            return true;
         }
      }

      public bool ValidateInt(int newInt)
      {
         if (newInt < 0)
         {
            return false;
         }

         return true;
      }

      public bool ValidateNullableKey(Nullable<int> nullableInt)
      {
         if (nullableInt == null || nullableInt >= 0)
         {
            return true;
         }
         else
         {
            return false;
         }
      }

      public bool ValidateBool(bool? newBool)
      {
         if (newBool != true && newBool != false && newBool != null)
         {
            return false;
         }
         else
         {
            return true;
         }
      }
   }
}