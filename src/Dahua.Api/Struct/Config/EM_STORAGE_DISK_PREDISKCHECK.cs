namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// Hard disk pre -inspection status (field, combined with disk pre -inspection function)
    /// </summary>
    internal enum EM_STORAGE_DISK_PREDISKCHECK
    {
        /// <summary>
        /// Unknown status
        /// </summary>
        UNKNOWN,
        /// <summary>
        /// The hard disk read speed to more than 120, there are a small amount of errors in the smart information, and there are no other errors.
        /// </summary>
        GOOD,
        /// <summary>
        /// There are a small amount of error records in cmd information, and the information information has an error record
        /// </summary>
        WARN,
        /// <summary>
        /// CMD information has an error record, and the information information is recorded by error. There are bad sectors recorded in bad sectors
        /// </summary>
        ERROR,
        /// <summary>
        /// The hard disk speed is relatively low 64m. CMD information has an error record. Smart information is recorded by an error. There are bad sectors recorded in the bad sector
        /// </summary>
        WILLFAIL,
        /// <summary>
        /// Hard disk return error
        /// </summary>
        FAIL,
        /// <summary>
        ///  Unknown state
        /// </summary>
        NONE,
        /// <summary>
        /// State in the query
        /// </summary>
        BECHECK,
        /// <summary>
        /// Inquiry failure state
        /// </summary>
        CHECKFAIL,
    }
}