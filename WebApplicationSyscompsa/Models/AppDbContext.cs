using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApplicationSyscompsa.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
        public DbSet<WebUser> WebUser { get; set; }
        public DbSet<Chanels> chanels { get; set; }
        //public DbSet<apcias> apcias { get; set; }
        //public DbSet<mensajeMod> mensajeMod { get; set; }
        //public DbSet<t_invcabg> t_invcabg { get; set; }
        //public DbSet<t_invdetg> t_invdetg { get; set; }
        //public DbSet<Img_lote> img_lote { get; set; }
        //public DbSet<Traspase_product> traspase_product { get; set; }

        //public DbSet<t_invcabG_t> t_invcabG { get; set; }
        //public DbSet<Maworkers> maworkers { get; set; }
        public DbSet<Webappusers> webappuser { get; set; }
        public DbSet<Mensajeria> mensajeria { get; set; }


        //asignamos el valor de los decimales que estan truncandose mediante c#
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mensajeria>().HasKey(pM => pM.usuario).HasName("usuario");
            modelBuilder.Entity<Chanels>().HasKey(pk => pk.usuario).HasName("usuario");
            modelBuilder.Entity<Chanels>().HasKey(tK => tK.token_canal).HasName("token_canal");
            // CAMBIAMOS EL PRIMARY KEY QUE VIEN POR DEFECTO EN ID Y ESCIFICAMOS EL QUE QUEREMOS USAR
            #region
            //t_invcabg
            //modelBuilder.Entity<apcias>().HasKey(pk => pk.email_despacho_web).HasName("email_despacho_web");
            //modelBuilder.Entity<Maworkers>().HasKey(pk => pk.user_email).HasName("user_email");
            //modelBuilder.Entity<Maworkers>().HasKey(pk => pk.codec_worker).HasName("codec_worker");
            //modelBuilder.Entity<mtrabajos>().HasKey(pk => pk.user_email).HasName("user_email");
            //modelBuilder.Entity<t_invcabg>().HasKey(pk => pk.tempo).HasName("tempo");
            //modelBuilder.Entity<Img_lote>().HasKey(pk => pk.no_parte_i).HasName("no_parte_i");
            #endregion
            //EVITAMOS EL CRASHED(COFLICTO) DE DATOS
            #region
            //t_invdetg

            //modelBuilder.Entity<t_invdetg>().HasKey(pk => pk.T_llave).HasName("T_llave");
            //modelBuilder.Entity<t_invdetg>().HasKey(pk => pk.tempo).HasName("tempo");
            //modelBuilder.Entity<t_invdetg>().HasKey(pk => pk.linea).HasName("linea");
            //modelBuilder.Entity<t_invdetg>().Property(a => a.cantidad).HasColumnType("decimal(10,2)");

            //modelBuilder.Entity<Traspase_product>().Property(a => a.cantidad).HasColumnType("decimal(10,2)");
            //modelBuilder.Entity<Maworkers>().Property(a => a.user_email).HasColumnType("decimal(10,2)");
            //modelBuilder.Entity<Mtrabajos>().Property(a => a.estado_proyecto).HasColumnType("decimal(10,2)");
            //modelBuilder.Entity<Traspase_product>().Property(a => a.stock).HasColumnType("decimal(10,2)");

            #endregion
        }

    }
}
