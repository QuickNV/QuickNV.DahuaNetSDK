using System;
using System.Runtime.InteropServices;

namespace Dahua.Api.Struct
{

    /// <summary>
    /// НшВзК±јд
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NET_TIME
    {
        /// <summary>
        /// Дк
        /// </summary>
        public int dwYear;
        /// <summary>
        /// ФВ
        /// </summary>
        public int dwMonth;
        /// <summary>
        /// ИХ
        /// </summary>
        public int dwDay;
        /// <summary>
        /// К±
        /// </summary>
        public int dwHour;
        /// <summary>
        /// ·Ц
        /// </summary>
        public int dwMinute;
        /// <summary>
        /// Гл
        /// </summary>
        public int dwSecond;

        /// <summary>
        /// Ѕ«ИХЖЪ°ґёсКЅЧЄ»»
        /// </summary>
        /// <param name="FormatStyle">ИХЖЪёсКЅЧЦ·ыґ®:yyyyОЄДкµДЦµёсКЅ[№М¶ЁЛДО»]Ј»mmОЄФВµДЦµёсКЅ[№М¶ЁБЅО»]Ј»ddОЄИХµДЦµёсКЅ[№М¶ЁБЅО»]Ј»dОЄИХµДЦµёсКЅ[І»ПЮ¶ЁО»Кэ]Ј»mОЄФВµДёсКЅ[І»ПЮ¶ЁО»Кэ]Ј»yyОЄДкµДёсКЅ[№М¶ЁБЅО»]Ј»yОЄДкµДёсКЅ[І»ПЮ¶ЁО»Кэ]Ј»hhОЄК±µДЦµёсКЅ[№М¶ЁБЅО»]Ј»hОЄК±µДЦµёсКЅ[І»ПЮ¶ЁО»Кэ]Ј»MMОЄ·ЦµДЦµёсКЅ[№М¶ЁБЅО»]Ј»MОЄ·ЦµДЦµёсКЅ[І»ПЮ¶ЁО»Кэ]Ј»ssОЄГлµДЦµёсКЅ[№М¶ЁБЅО»]Ј»sОЄГлµДЦµёсКЅ[І»ПЮ¶ЁО»Кэ]Ј»</param>
        /// <returns></returns>
        public string ToString(string FormatStyle)
        {
            string returnValue = FormatStyle;
            //ДкµДёсКЅґ¦Ан
            string strY = "";
            if (returnValue.IndexOf("yyyy") != -1)
            {
                strY = "0000".Remove(4 - dwYear.ToString().Length) + dwYear.ToString();
                returnValue = returnValue.Replace("yyyy", strY);
            }
            else if (returnValue.IndexOf("yy") != -1)
            {
                if (dwYear.ToString().Length > 2)
                {
                    strY = dwYear.ToString().Substring(dwYear.ToString().Length - 2);
                    returnValue = returnValue.Replace("yy", strY);
                }
                else
                {
                    strY = "00".Remove(2 - dwYear.ToString().Length) + dwYear.ToString();
                    returnValue = returnValue.Replace("yy", strY);
                }
            }
            else if (returnValue.IndexOf("y") != -1)
            {
                strY = dwYear.ToString();
                returnValue = returnValue.Replace("y", strY);
            }
            //ФВµДёсКЅґ¦Ан
            string strM = "";
            if (returnValue.IndexOf("mm") != -1)
            {
                strM = "00".Remove(2 - dwMonth.ToString().Length) + dwMonth.ToString();
                returnValue = returnValue.Replace("mm", strM);
            }
            else if (returnValue.IndexOf("m") != -1)
            {
                strM = dwMonth.ToString();
                returnValue = returnValue.Replace("m", strM);
            }
            //ИХµДёсКЅґ¦Ан
            string strD = "";
            if (returnValue.IndexOf("dd") != -1)
            {
                strD = "00".Remove(2 - dwDay.ToString().Length) + dwDay.ToString();
                returnValue = returnValue.Replace("dd", strD);
            }
            else if (returnValue.IndexOf("d") != -1)
            {
                strD = dwDay.ToString();
                returnValue = returnValue.Replace("d", strD);
            }
            //К±µДёсКЅґ¦Ан
            string strH = "";
            if (returnValue.IndexOf("hh") != -1)
            {
                strH = "00".Remove(2 - dwHour.ToString().Length) + dwHour.ToString();
                returnValue = returnValue.Replace("hh", strH);
            }
            else if (returnValue.IndexOf("h") != -1)
            {
                strH = dwHour.ToString();
                returnValue = returnValue.Replace("h", strH);
            }
            //·ЦµДёсКЅґ¦Ан
            string strMM = "";
            if (returnValue.IndexOf("MM") != -1)
            {
                strMM = "00".Remove(2 - dwMinute.ToString().Length) + dwMinute.ToString();
                returnValue = returnValue.Replace("MM", strMM);
            }
            else if (returnValue.IndexOf("M") != -1)
            {
                strMM = dwMinute.ToString();
                returnValue = returnValue.Replace("M", strMM);
            }
            //ГлµДёсКЅґ¦Ан
            string strS = "";
            if (returnValue.IndexOf("ss") != -1)
            {
                strS = "00".Remove(2 - dwSecond.ToString().Length) + dwSecond.ToString();
                returnValue = returnValue.Replace("ss", strS);
            }
            else if (returnValue.IndexOf("s") != -1)
            {
                strS = dwSecond.ToString();
                returnValue = returnValue.Replace("s", strS);
            }
            return returnValue;
        }

        /// <summary>
        /// ЧЄОЄ±кЧј±ёµДПµНіК±јдёсКЅ
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime()
        {
            try
            {
                return new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public static NET_TIME FromDateTime(DateTime dateTime)
        {
            try
            {
                NET_TIME net_time = new NET_TIME
                {
                    dwYear = dateTime.Year,
                    dwMonth = dateTime.Month,
                    dwDay = dateTime.Day,
                    dwHour = dateTime.Hour,
                    dwMinute = dateTime.Minute,
                    dwSecond = dateTime.Second
                };
                return net_time;
            }
            catch
            {
                return new NET_TIME();
            }
        }
    }
}
