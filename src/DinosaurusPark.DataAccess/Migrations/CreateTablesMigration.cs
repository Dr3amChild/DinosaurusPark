using FluentMigrator;
using Microsoft.EntityFrameworkCore;

namespace DinosaurusPark.DataAccess.Migrations
{
    [Migration(1)]
    public class CreateTablesMigration : Migration
    {
        private const string SpeciesTable = "Species";
        private const string DinosaurusTable = "Dinosaurs";

        public override void Up()
        {
            const string idColumn = "Id";
            Create.Table(SpeciesTable)
                .WithColumn(idColumn).AsInt32().PrimaryKey("PK_Species").NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("FoodType").AsInt32().NotNullable();

            Create.Table(DinosaurusTable)
                .WithColumn(idColumn).AsInt32().PrimaryKey("PK_Dinosaurs").NotNullable()
                .WithColumn("SpeciesId").AsInt32().ForeignKey("FK_SpeciesId", SpeciesTable, idColumn).NotNullable()
                .WithColumn("Name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table(DinosaurusTable);
            Delete.Table(SpeciesTable);
        }
    }
}