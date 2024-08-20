using FluentValidation;
using Module34.WebApi1.Contracts.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module34.WebApi1.Contracts.Validators
{
    /// <summary>
    /// Класс-валидатор запросов на добавление новой комнаты
    /// </summary>
    public class AddRoomRequestValidator : AbstractValidator<AddRoomRequest>
    {
        public AddRoomRequestValidator()
        {
            RuleFor(x => x.Area).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Voltage).NotEmpty();
            RuleFor(x => x.GasConnected).NotEmpty();
        }
    }
}
