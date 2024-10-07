using WKApp.Api.Commands;
using WKApp.Api.Interfaces;
using WKApp.Domain.Models.Employee;

namespace WKApp.Api.Endpoints;

public static class EmployeeApi
{
    public static RouteGroupBuilder MapEmployeeApi(this RouteGroupBuilder group)
    {
        group
            .MapPost("/", (CreateEmployeeCommand command, ICommandHandler<Employee, CreateEmployeeCommand> handler) =>
            {
                var employee = handler.Handle(command);

                return Results.Created($"/api/employees/{employee.Id}", employee);
            })
            .Produces<Employee>(StatusCodes.Status201Created);

        group
            .MapPut("/{id:guid}", (UpdateEmployeeCommand command, ICommandHandler<Employee, UpdateEmployeeCommand> handler) =>
            {
                var result = handler.Handle(command);

                return Results.Ok(result);
            })
            .Produces<Employee>(StatusCodes.Status200OK);

        return group.WithTags("employees");
    }


}
