using System;

namespace Dahua.Api.Struct.Config
{
    // 硬盘预检状态(字段,配合磁盘预检功能使用)
    public enum EM_STORAGE_DISK_PREDISKCHECK
    {
        UNKNOWN,                               // UnKnown状态
        GOOD,                                  // 硬盘读速度到120以上,smart信息里有少量的错误,其他无任何错误.
        WARN,                                  // cmd信息里有少量错误记录,smart信息有错误记录
        ERROR,                                 // cmd信息有错误记录,smart信息由错误记录.坏扇区有坏扇区记录
        WILLFAIL,                              // 硬盘速度比较低64M以下.cmd信息有错误记录,smart信息由错误记录.坏扇区有坏扇区记录
        FAIL,                                  // 硬盘返回错误
        NONE,                                  // 未知状态
        BECHECK,                               // 正在查询中状态
        CHECKFAIL,                             // 查询失败状态
    }
}