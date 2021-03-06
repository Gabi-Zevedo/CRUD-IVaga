// <auto-generated />
using IVaga.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IVaga.Migrations
{
    [DbContext(typeof(IVagaContext))]
    partial class IVagaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("IVaga.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .HasColumnType("text");

                    b.Property<string>("Marca")
                        .HasColumnType("text");

                    b.Property<string>("Modelo")
                        .HasColumnType("text");

                    b.Property<string>("Placa")
                        .HasColumnType("text");

                    b.Property<int>("TipoVeiculo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Veiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
