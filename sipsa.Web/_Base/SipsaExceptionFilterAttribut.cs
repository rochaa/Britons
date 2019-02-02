using System.Collections.Generic;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using sipsa.Dominio._Base;

namespace sipsa.Web._Base
{
    public class SipsaExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            IList<ValidationFailure> erros;
            var result = new ViewResult();

            if (exception is DominioException)
            {
                var exDominio = exception as DominioException;            
                erros = exDominio.Erros;
            }
            else
            {
                erros = new List<ValidationFailure>();
                erros.Add(new ValidationFailure("", exception.Message));
                result.ViewName = "Error";
            }
            
            var modelState = new ModelStateDictionary();
            foreach (var erro in erros)
            {
                modelState.AddModelError(erro.PropertyName, erro.ErrorMessage);
            }
            
            result.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), modelState);
            context.Result = result;
        }
    }
}