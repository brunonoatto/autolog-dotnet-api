using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class CreateBudgetUseCase(AppDbContext Repository) : IUseCase<CreateBudgetUseCaseInput>
    {
        public async Task<IResult> Execute(CreateBudgetUseCaseInput input)
        {
            //TODO: regra negócio: Já existe um orçamento em andamento para esse veículo na sua oficina.
            var garageId = input.User.GetGarageId();
            var bodyData = input.Body;

            var clientId = bodyData.ClientId;

            if (clientId is null)
            {
                if (bodyData.NewClient is null)
                {
                    return Results.BadRequest("Dados do Cliente não foram enviados.");
                }

                var newUser = new User
                {
                    Email = "*",
                    Password = "*",
                    CpfCnpj = bodyData.NewClient.CpfCnpj,
                    Name = bodyData.NewClient.Name,
                    Phone = bodyData.NewClient.Phone,
                    Type = UserTypeEnum.Client
                };

                Repository.Users.Add(newUser);

                clientId = newUser.Id;
            }

            var carId = bodyData.CarId;

            if (carId is null)
            {
                if (bodyData.Car is null)
                {
                    return Results.BadRequest("Dados do Veículo não foram enviados.");
                }

                var isLicenseExist = await Repository.Cars.AnyAsync(c =>
                    c.License == bodyData.Car.License
                );
                if (isLicenseExist)
                {
                    return Results.BadRequest("Placa já cadastrada.");
                }

                var newCar = new Car
                {
                    License = bodyData.Car.License,
                    ClientId = (Guid)clientId,
                    Model = bodyData.Car.Model,
                    Brand = bodyData.Car.Brand,
                    Year = bodyData.Car.Year,
                };

                Repository.Cars.Add(newCar);

                carId = newCar.Id;
            }

            var newBudget = new Budget
            {
                GarageId = garageId,
                UserId = (Guid)clientId,
                CarId = (Guid)carId,
                Status = BudgetStatusEnum.MakingBudget,
                Observation = bodyData.Observation,
            };

            await Repository.Budgets.AddAsync(newBudget);
            await Repository.SaveChangesAsync();

            return Results.Ok(newBudget);
        }
    }
}
