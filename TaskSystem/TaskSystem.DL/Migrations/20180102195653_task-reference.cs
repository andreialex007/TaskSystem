using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TaskSystem.DL.Migrations
{
    public partial class taskreference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTaskNotes_WorkTasks_WorkTaskId",
                table: "WorkTaskNotes");

            migrationBuilder.AlterColumn<int>(
                name: "WorkTaskId",
                table: "WorkTaskNotes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTaskNotes_WorkTasks_WorkTaskId",
                table: "WorkTaskNotes",
                column: "WorkTaskId",
                principalTable: "WorkTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTaskNotes_WorkTasks_WorkTaskId",
                table: "WorkTaskNotes");

            migrationBuilder.AlterColumn<int>(
                name: "WorkTaskId",
                table: "WorkTaskNotes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTaskNotes_WorkTasks_WorkTaskId",
                table: "WorkTaskNotes",
                column: "WorkTaskId",
                principalTable: "WorkTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
