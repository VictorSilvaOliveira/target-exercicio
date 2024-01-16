using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Target.App.Features;
using Target.App.Features.AlterarLancamento;
using Target.App.Features.CancelarLancamento;
using Target.App.Features.DetalheLancamento;
using Target.App.Features.IncluirLancamento;
using Target.App.Features.IncluirLancamentoAvulso;
using Target.App.Features.RecuperaLancamento;
using Target.App.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton((options) =>
{
    var contextOptions = new DbContextOptionsBuilder();
    contextOptions.UseInMemoryDatabase("LancamentoDb");
    return contextOptions.Options;
});

builder.Services.AddScoped<LancamentoDbContext>();

builder.Services.AddScoped<IFeature<RecuperaLancamentoRequisicao, RecuperaLancamentoResposta>, RecuperaLancamento>();
builder.Services.AddScoped<IFeature<DetalheLancamentoRequisicao, DetalheLancamentoResposta>, DetalheLancamento>();
builder.Services.AddScoped<IFeature<AlterarLancamentoRequisicao, AlterarLancamentoResposta>, AlterarLancamento>();
builder.Services.AddScoped<IFeature<IncluirLancamentoRequisicao, IncluirLancamentoResposta>, IncluirLancamento>();
builder.Services.AddScoped<IFeature<IncluirLancamentoAvulsoRequisicao, IncluirLancamentoAvulsoResposta>, IncluirLancamentoAvulso>();
builder.Services.AddScoped<IFeature<CancelarLancamentoRequisicao, CancelarLancamentoResposta>, CancelarLancamento>();

builder.Services.AddSingleton<IMapper>((options) =>
{
    var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly())));
    return mapper;
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
