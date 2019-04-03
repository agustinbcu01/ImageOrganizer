using System;

namespace DBAbstractionLayer
{
    public enum DataAccessProviderTypes
    {
        SqlServer,
        SqLite,
        MySql,
        PostgreSql,

#if NETFULL
    OleDb,
    SqlServerCompact
#endif
    }
}
