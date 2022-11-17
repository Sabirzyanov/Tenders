using ImagesViewerProject.Services;
using ImagesViewerProject.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Tenders.Core.Entities;
using Tenders.Core.Entities.Document;
using Tenders.Core.Entities.Project;
using Tenders.Data;
using Tenders.Data.DbModels;
using Tenders.Data.Resources;
using Tenders.Web.Data;
using Tenders.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<AuthorizationService>();
builder.Services.AddScoped<UserResourceService>();
builder.Services.AddScoped<ProjectResourceService>();
builder.Services.AddScoped<DocumentResourceService>();

builder.Services.AddScoped<MongoConnection<UserDbModel>>();
builder.Services.AddScoped<MongoConnection<ProjectDbModel>>();
builder.Services.AddScoped<MongoConnection<DocumentDbModel>>();

builder.Services.AddScoped<IRepository<BaseUser>, UserRepository>();
builder.Services.AddScoped<IRepository<Project>, ProjectRepository>();
builder.Services.AddScoped<IRepository<BaseDocument>, DocumentRepository>();

builder.Services.AddScoped<MongoProvider<BaseUser>>();
builder.Services.AddScoped<MongoProvider<Project>>();
builder.Services.AddScoped<MongoProvider<BaseDocument>>();



builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();