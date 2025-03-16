using OnlineAppointment.Business.Abstract;
using OnlineAppointment.Business.Concrete;
using OnlineAppointment.DataAccess.Abstract;
using OnlineAppointment.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddRazorPages();
builder.Services.AddControllers(); //Controller kullanmak için.

builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IDoctorService,DoctorManager>();
builder.Services.AddSingleton<IAppointmentService, AppointmentManager>();

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IDoctorRepository, DoctorRepository>();
builder.Services.AddSingleton<IAppointmentRepository, AppointmentRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers(); //Controller dan yönlendirme saðlamak için.


app.Run();

