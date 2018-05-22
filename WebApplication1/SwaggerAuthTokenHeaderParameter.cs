using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication1
{
    public class SwaggerAuthTokenHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            var authorizeAttributes = apiDescription
                .ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>();

            if (authorizeAttributes.ToList().Any(attr => attr.GetType() == typeof(AllowAnonymousAttribute)) == false)
            {                
                operation.parameters.Add(new Parameter()
                {
                    name = "SessionID",
                    @in = "header",
                    type = "string",
                    description = "Session Id",
                    @default = LoginHelper.DoLoginStepOne(), // set session id from a call to a login helper class
                    required = true
                });

                operation.parameters.Add(new Parameter()
                {
                    name = "Authorization",
                    @in = "header",
                    type = "string",
                    description = "Authorization Token",
                    @default = LoginHelper.DoLoginStepTwo(), // set token value from a call to a login helper class
                    required = true
                });
            }
        }
    }


    static class LoginHelper {

        public static string DoLoginStepOne() {
            return "abc";
        }

        public static string DoLoginStepTwo() {
            string token = "Bearer xyz"; 
            Logout();

            return token;           
        }

        static void Logout() {

        }
    }
}