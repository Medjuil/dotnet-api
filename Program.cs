using ApiProgram.Context;
using ApiProgram.Helpers;
using ApiProgram.Interface;
using Microsoft.EntityFrameworkCore;

var AllowSISFlutterApplicationCORSPolicy = "_AllowSISFlutterApplicationCORSPolicy";

var builder = WebApplication.CreateBuilder(args);

// Adding CORS Policy to my SIS Flutter Application
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSISFlutterApplicationCORSPolicy,
                        policy => policy.WithOrigins("http://localhost:59722") // Add your Flutter application URL
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CreditPortalDbContext>( options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("CreditPortalDbConnection")
    ));
builder.Services.AddScoped<IStudentHelper, StudentHelper>(); // 
builder.Services.AddScoped<ITeacherHelper, TeacherHelper>();
builder.Services.AddScoped<ISubjectHelper, SubjectHelper>();
builder.Services.AddScoped<IClassHelper, ClassHelper>();
builder.Services.AddScoped<IClassStudentHelper, ClassStudentHelper>();
builder.Services.AddScoped<IClassStudentGradeHelper, ClassStudentGradeHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Adding CORS policy authorization
app.UseCors(AllowSISFlutterApplicationCORSPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
