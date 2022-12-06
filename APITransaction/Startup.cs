using APITransaction.AccountProcess;
using APITransaction.Helpers;
using APITransaction.PayeeProcess;
using APITransaction.TransactionProcess;
using APITransaction.UserProcess;
using EFCore_Transaction.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Service_Transaction.Contracts;
using Service_Transaction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITransaction
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region Context
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                      Configuration.GetConnectionString("TransactionModelDB"),
                      b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            #endregion

            // helper
            services.AddTransient<CreateObjectHelper>();

            // user
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserWorker, UserWorker>();
            services.AddTransient<UserWorkerService>();

            // account
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountWorker, AccountWorker>();
            services.AddTransient<AccountWorkerService>();

            // payee
            services.AddTransient<IPayeeRepository, PayeeRepository>();
            services.AddTransient<IPayeeWorker, PayeeWorker>();
            services.AddTransient<PayeeWorkerService>();

            // transaction
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<ITransactionWorker, TransactionWorker>();
            services.AddTransient<TransactionWorkerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
