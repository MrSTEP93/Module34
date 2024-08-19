using FluentValidation;
using Module34.WebApi1.Contracts.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Module34.WebApi1.Contracts.Validators
{
    public class AddDeviceRequestValidator : AbstractValidator<AddDeviceRequest>
    {
        public AddDeviceRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Manufacturer).NotEmpty();
            RuleFor(x => x.Voltage)
                .NotEmpty()
                .Must(BeValidVoltage)
                .WithMessage("Поддерживаются устройства с напряжением от 180 до 220 вольт");
            RuleFor(x => x.Location).NotEmpty();

        }

        private bool BeValidVoltage(int voltage)
        {
            if (voltage < 180)
                return false;

            if (voltage > 220)
                return false;
            
            return true;
        }
    }
}
