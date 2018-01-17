using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TaskSystem.DL.Migrations
{
    public partial class Invoice_RemoveTaskId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Invoices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
