using System.Collections.Generic;

namespace #namespace#.IRepository
{
    public interface IQuery#pagename#
    {
        #pagename# Get(long id);        
    }

    public interface ICommand#pagename#
    {
        void Save(#pagename# #pagenamelowercase#);
        void Update(#pagename# #pagenamelowercase#);
    }

    public interface I#pagename#Repository : IQuery#pagename#, ICommand#pagename#
    {
    }
}
