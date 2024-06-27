using AutologApi.API.Domain.Models;
using AutologApi.API.Exceptions.UseCases.Budget;
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
                    throw new NotFoundClientException();
                }

                var newUser = new User
                {
                    Email = User.WITHOUT_LOGIN_TEXT,
                    Password = User.WITHOUT_LOGIN_TEXT,
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
                    throw new NotFoundCarException();
                }

                var existCar = await Repository.Cars.FirstOrDefaultAsync(c =>
                    c.License == bodyData.Car.License
                );

                if (existCar is not null && existCar.ClientId != clientId)
                {
                    throw new LicenseAlreadyRegistredOtherClientException();
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
