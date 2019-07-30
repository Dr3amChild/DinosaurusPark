using System;
using FluentMigrator;

namespace DinosaurusPark.DataAccess.Migrations
{
    [Migration(1)]
    public class CreateTablesMigration : Migration
    {
        public override void Up()
        {
            const string speciesTable = "Species";
            const string idColumn = "Id";

            Create.Table(speciesTable)
                .WithColumn(idColumn).AsInt32().PrimaryKey("PK_Species").NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("FoodType").AsInt32().NotNullable();

            Create.Table("Dinosaurs")
                .WithColumn(idColumn).AsInt32().PrimaryKey("PK_Species").NotNullable()
                .WithColumn("SpeciesId").AsInt32().ForeignKey("FK_SpeciesId", speciesTable, idColumn).NotNullable()
                .WithColumn("Name").AsString().NotNullable();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}