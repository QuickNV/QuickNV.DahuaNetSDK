namespace Dahua.Api.Abstractions
{
    /// <summary>
    ///  Picture Service
    /// </summary>
    public interface IPictureService
    {
        /// <summary>
        /// Manuals the snap.
        /// </summary>
        /// <param name="channelId">The channel identifier.</param>
        /// <returns></returns>
        byte[] ManualSnap(int channelId);
        /// <summary>
        /// Snaps the picture to file.
        /// </summary>
        /// <param name="channelId">The channel identifier.</param>
        /// <param name="fileName">Name of the file.</param>
        void SnapPictureToFile(int channelId, string fileName);
        /// <summary>
        /// Snaps the picture to file.
        /// </summary>
        /// <param name="channelId">The channel identifier.</param>
        void SnapPictureToFile(int channelId);
    }
}
