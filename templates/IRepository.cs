using System.Collections.Generic;

namespace #namespace#.IRepository
{
    public interface IQuery#pagename#
    {
        #pagename# Get(long id);        
    }

    public interface ICommand#pagename#
    {
        void Save(#pagename# #pagename#);
        void Update(#pagename# #pagename#);
    }

    public interface I#pagename#Repository : IQuery#pagename#, ICommand#pagename#
    {
    }
}
