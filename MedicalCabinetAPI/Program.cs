using MedicalCabinetAPI.Application.Interfaces;
using MedicalCabinetAPI.Application.Mapper;
using MedicalCabinetAPI.Application.Services;
using MedicalCabinetAPI.Infrastructure.Interfaces;
using MedicalCabinetAPI.Infrastructure.Repository;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMedicalStaffRepository, MedicalStaffRepository>();
builder.Services.AddScoped<IMedicalStaffService, MedicalStaffService>();

builder.Services.AddScoped<IMedicationService, MedicationService>();

builder.Services.AddScoped<IPatientService, PatientService>();


builder.Services.AddScoped<IConsultationService, ConsultationService>();


builder.Services.AddAutoMapper(typeof(MapperConfig));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
