using Asp.Versioning;
using BookManagerApi.Validators;
using FluentValidation;
using Repository.Authors.Implementations;
using Repository.Authors.Interfaces;
using Repository.BookList.Implementations;
using Repository.BookList.Interfaces;
using Repository.Books.Implementations;
using Repository.Books.Interfaces;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddApiVersioning(options => {
                                      options.AssumeDefaultVersionWhenUnspecified = Convert.ToBoolean(builder.Configuration["AssumeDefaultVersionWhenUnspecified"]);
                                      options.DefaultApiVersion = new ApiVersion(Convert.ToDouble(builder.Configuration["ApiVersion"]));
                                      options.ReportApiVersions = Convert.ToBoolean(builder.Configuration["ReportApiVersions"]);
                                  });
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddValidatorsFromAssemblyContaining<AuthorValidator>();

builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookMutationRepository, BookRepository>();
builder.Services.AddTransient<IBookQueryRepository, BookRepository>();

builder.Services.AddTransient<IBookListRepository, BookListRepository>();
builder.Services.AddTransient<IBookListMutationRepository, BookListRepository>();
builder.Services.AddTransient<IBookListQueryRepository, BookListRepository>();

builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<IAuthorMutationRepository, AuthorRepository>();
builder.Services.AddTransient<IAuthorQueryRepository, AuthorRepository>();

builder.Services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(builder.Configuration["RedisConnection"]!));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.MapControllers();

app.Run();
