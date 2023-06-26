using Application.Account;
using Application.ChatRoom;
using Application.Interfaces.Contexts;
using Application.Message;
using Application.Sms;
using Hubs;
using Infrastructure.IdentityConfigs;
using Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR(options =>
{
    options.ClientTimeoutInterval = TimeSpan.FromHours(2); // زمان انتظار 60 ثانیه
});



builder.Services.AddIdentitySerivce(builder.Configuration);
builder.Services.AddScoped<IChatRoomService, ChatRoomService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IDataBaseContext, AppDbContext>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ISmsService, SmsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
name: "areas",
pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<SiteChatHub>("/chathub");
app.MapHub<SupportHub>("/supporthub");



app.Run();
