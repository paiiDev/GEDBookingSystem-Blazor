using Blazored.LocalStorage;
using GedBooking.Client;
using GedBooking.Client.Handlers;
using GedBooking.Client.Providers;
using GedBooking.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddBlazoredLocalStorage();

// ၁။ Authorization စနစ်ကို ဖွင့်ခြင်း
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
// ၂။ Interceptor Handler ကို မှတ်ပုံတင်ခြင်း
builder.Services.AddTransient<JwtAuthorizationHandler>();

// ၃။ HttpClient တွင် Handler ကို ကြားခံအဖြစ် ဖြတ်ခိုင်းခြင်း
builder.Services.AddHttpClient("GedBookingApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7023/");
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("GedBookingApi"));

await builder.Build().RunAsync();
