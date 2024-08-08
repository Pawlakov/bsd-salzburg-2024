// <copyright file="20240808203404_DonorHonorObsolete.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

#nullable disable

namespace BSDSalzburg2024.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class DonorHonorObsolete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EhrungLetzte",
                table: "tblSpender");

            migrationBuilder.DropColumn(
                name: "EhrungsID",
                table: "tblSpender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EhrungLetzte",
                table: "tblSpender",
                type: "smalldatetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EhrungsID",
                table: "tblSpender",
                type: "varchar(8)",
                unicode: false,
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }
    }
}
