namespace Dahua.Api.Struct.Config
{
    // 硬盘电源状态
    public enum EM_STORAGE_DISK_POWERMODE
    {
        UNKNOWN,                                  // UNKnown状态（不是以下状态中的值）
        NONE,                                     // 未知状态
        ACTIVE,                                   // 活动状态
        STANDBY,                                  // 休眠状态
        IDLE,                                     // 空闲状态
    }
}