using System;
using System.Collections.Generic;
using System.Linq;

namespace #namespace#.IBusiness
{
    public interface I#pagename#Business
    {
        IQuery#pagename# Queries { get; }

        #pagename# Save(#pagename# #pagenamelowercase#);
        void Delete(long id);
    }
}
