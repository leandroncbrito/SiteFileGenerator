using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace #namespace#.Repository.EntityFramework
{
    public class #pagename#Repository : I#pagename#Repository
    {
        
        public #pagename# Get(long id)
        {
            using (#namespace#Context context = new #namespace#Context())
            {
                return context.#pagename#s.Find(id);
            }
        }
   
        public void Save(#pagename# #pagenamelowercase#)
        {
            using (#namespace#Context context = new #namespace#Context())
            {
                context.#pagename#s.Add(#pagenamelowercase#);
                context.SaveChanges();
            }
        }

        public void Update(#pagename# #pagenamelowercase##)
        {
            using (#namespace#Context context = new #namespace#Context())
            {				
				context.#pagename#s.Attach(#pagenamelowercase#);
                context.Entry(#pagename#).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        
    }
}
