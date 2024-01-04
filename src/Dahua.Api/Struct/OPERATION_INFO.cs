namespace Dahua.Api.Struct
{
    /// <summary>
    /// ґнОуДЪИЭ
    /// </summary>
    public struct OPERATION_INFO
    {
        /// <summary>
        /// ґнОуґъВл
        /// </summary>
        public string errCode;
        /// <summary>
        /// ґнОуГиКц
        /// </summary>
        public string errMessage;
        /// <summary>
        /// °ґЧФ¶ЁТеёсКЅ·µ»ШґнОуДЪИЭЧЦ·ыґ®
        /// </summary>
        /// <param name="FormatStyle">ґнОуДЪИЭЧЦ·ыґ®ёсКЅЈєerrcodeґъМжґнОуґъВл;errmsgґъМжґнОуГиКц</param>
        /// <returns></returns>
        public string ToString(string FormatStyle)
        {
            string returnValue = FormatStyle;
            if (returnValue.Length == 0)
            {
                returnValue = "errcode:errmsg!";
            }
            returnValue = returnValue.ToUpper();
            returnValue = returnValue.Replace("ERRCODE", errCode).Replace("ERRMSG", errMessage);
            return returnValue;

        }
    }
}
