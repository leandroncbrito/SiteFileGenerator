using FluentValidation;
using System.Collections.Generic;

namespace #namespace#.Business
{
    public class #pagename#Business : I#pagename#Business
    {
        public IQuery#pagename# Queries { get; private set; }
        private ICommand#pagename# Command { get; set; }
        private readonly IValidator<#pagename#> validator;

        public #pagename#Business(I#pagename#Repository #pagenamelowercase#Repository, IValidator<#pagename#> validator)
        {
            Queries = programRepository;
            Command = programRepository;
            this.validator = validator;
        }

        public #pagename# Save(#pagename# #pagenamelowercase#)
        {
            var validationResult = validator.Validate(#pagenamelowercase#, ruleSet: "CreateOrUpdate");

            if (!validationResult.IsValid)
                throw new ValidationException("Erro ao salvar #pagenameptbr#.", validationResult.Errors);

            if (#pagenamelowercase#.Id > 0)
            {                
                Command.Update(#pagenamelowercase#);
            }
            else
            {
                Command.Save(#pagenamelowercase#);
            }

            return #pagenamelowercase#;

        }

        public void Delete(long id)
        {
            var #pagenamelowercase# = Queries.Get(id);

            if (#pagenamelowercase#.Id > 0)
            {
                var validationResult = validator.Validate(#pagenamelowercase#, ruleSet: "Delete#pagename#");

                if (!validationResult.IsValid)
                    throw new ValidationException("Erro ao excluir #pagenameptbr#.", validationResult.Errors);

                #pagenamelowercase#.State = (byte)State.Deleted;
                
                Command.Update(program);
                
            }
        }
    }
}
