#pragma warning disable SA1305
using FluentMigrator;

namespace DinosaursPark.DataAccess.Migrations
{
    [Migration(1)]
    public class CreateTablesMigration : Migration
    {
        private const string SpeciesTable = "Species";
        private const string DinosaursTable = "Dinosaurs";

        public override void Up()
        {
            const string idColumn = "Id";
            Create.Table(SpeciesTable)
                .WithColumn(idColumn).AsInt32().PrimaryKey("PK_Species").Identity().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("FoodType").AsInt32().NotNullable();

            Create.Table(DinosaursTable)
                .WithColumn(idColumn).AsInt32().PrimaryKey("PK_Dinosaurs").Identity().NotNullable()
                .WithColumn("SpeciesId").AsInt32().ForeignKey("FK_SpeciesId", SpeciesTable, idColumn).NotNullable()
                .WithColumn("Gender").AsInt32().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Age").AsInt32().NotNullable()
                .WithColumn("Height").AsInt32().NotNullable()
                .WithColumn("Weight").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table(DinosaursTable);
            Delete.Table(SpeciesTable);
        }
    }
}
#pragma warning restore SA1305