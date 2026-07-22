using System.Globalization;

namespace MeetupsServerApp.Shared
{
    public static class PersianFormat
    {
        public static string En2Fa(string sNum)
        {
            if (sNum == null)
                return "";

            var sFrNum = "";
            const string vInt = "1234567890";

            sNum = sNum.Trim();

            var mystring = sNum.ToCharArray(0, sNum.Length);

            for (var i = 0; i <= (mystring.Length - 1); i++)
                if (vInt.IndexOf(mystring[i]) == -1)
                    sFrNum += mystring[i];
                else
                    sFrNum += ((char)((int)mystring[i] + 1728));

            return sFrNum;
        }

        public static string Fa2En(string PersianInput)
        {
            if (PersianInput == null)
                return "";

            string persianNumbers = "۰۱۲۳۴۵۶۷۸۹";
            string englishNumbers = "0123456789";

            for (int i = 0; i < persianNumbers.Length; i++)
            {
                PersianInput = PersianInput.Replace(persianNumbers[i], englishNumbers[i]);
            }
            return PersianInput;
        }

        public static string NumberGroupping(string sNum)
        {
            if (string.IsNullOrEmpty(sNum)) return null;

            var result = string.Empty;
            var words = sNum.Split(' ');

            foreach (var word in words)
            {
                double num;
                result += " " + (double.TryParse(word, out num) ? num.ToString("0,0.##", CultureInfo.InvariantCulture) : word);
            }

            return result.Substring(1);
        }
    }
}
