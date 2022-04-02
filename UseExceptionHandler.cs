app.UseExceptionHandler(appBuilder =>
        {
            appBuilder.Run(async context =>
            {
                var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;
                if (error?.Error != null)
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    Console.WriteLine($"--> {contextFeature.Error.GetType()}");

                    if (contextFeature.Error.GetType() == typeof(ArgumentException))
                    {
                        Console.WriteLine("--> this is an Argument Exp");
                        var errorResponse = new
                        {
                            message = contextFeature.Error.Message,
                            errors = contextFeature.Error.Message,
                            traceCode = Guid.NewGuid().ToString(),
                            dateTime = DateTime.Now
                        };
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                        return;
                    }

                    if (contextFeature.Error.GetType() == typeof(ValidationException))
                    {
                        Console.WriteLine("--> this is an Validation Exp");
                        var errorResponse = new
                        {
                            message = contextFeature.Error.Message,
                            errors = contextFeature.Error.Message,
                            traceCode = Guid.NewGuid().ToString(),
                            dateTime = DateTime.Now
                        };
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                        return;
                    }

                    if (contextFeature.Error.GetType() == typeof(Exception))
                    {
                        Console.WriteLine("--> this is an Exp");
                        var errorResponse = new
                        {
                            message = contextFeature.Error.Message,
                            errors = contextFeature.Error.Message,
                            traceCode = Guid.NewGuid().ToString(),
                            dateTime = DateTime.Now
                        };
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                    }
                    else
                    {
                        var errorResponse = new
                        {
                            message = contextFeature.Error.Message,
                            errors = contextFeature.Error.Message,
                            traceCode = Guid.NewGuid().ToString(),
                            dateTime = DateTime.Now
                        };
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                    }
                }
            });
        });
