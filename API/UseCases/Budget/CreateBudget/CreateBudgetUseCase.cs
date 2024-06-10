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

            var clientId = input.ClientId;

            if (clientId is null)
            {
                if (input.NewClient is null)
                {
                    return Results.BadRequest("Dados do Cliente não foram enviados.");
                }

                var newUser = new User
                {
                    Email = "*",
                    Password = "*",
                    CpfCnpj = input.NewClient.CpfCnpj,
                    Name = input.NewClient.Name,
                    Phone = input.NewClient.Phone,
                    Type = UserTypeEnum.Client
                };

                Repository.Users.Add(newUser);

                clientId = newUser.Id;
            }

            var carId = input.CarId;

            if (carId is null)
            {
                if (input.Car is null)
                {
                    return Results.BadRequest("Dados do Veículo não foram enviados.");
                }

                var isLicenseExist = await Repository.Cars.AnyAsync(c =>
                    c.License == input.Car.License
                );
                if (isLicenseExist)
                {
                    return Results.BadRequest("Placa já cadastrada.");
                }

                var newCar = new Car
                {
                    License = input.Car.License,
                    ClientId = (Guid)clientId,
                    Model = input.Car.Model,
                    Brand = input.Car.Brand,
                    Year = input.Car.Year,
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
                Observation = input.Observation,
            };

            await Repository.Budgets.AddAsync(newBudget);
            await Repository.SaveChangesAsync();

            return Results.Ok(newBudget);
        }
    }
}
