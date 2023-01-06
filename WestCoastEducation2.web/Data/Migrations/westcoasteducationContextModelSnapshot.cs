﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WestCoastEducation2.web.Data;


#nullable disable

namespace WestCoastEducation2.web.Data.Migrations
{
    [DbContext(typeof(westcoasteducationContext))]
    partial class westcoasteducationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");
            modelBuilder.Entity("WestCoastEducation2.web.Models.Courses", b => 
{
    b.Property<string>("name")
        .IsRequired()
        .HasColumnType("TEXT");
    b.Property<string>("courseNumber")
        .IsRequired()
        .HasColumnType("TEXT");
        b.Property<string>("teacher")
        .IsRequired()
        .HasColumnType("TEXT");
        b.Property<string>("placeStudy")
        .IsRequired()
        .HasColumnType("TEXT");
        b.Property<string>("startDate")
        .IsRequired()
        .HasColumnType("Text");
        b.Property<string>("endDate")
        .IsRequired()
        .HasColumnType("Text");
        b.ToTable("Courses1");
        
});
#pragma warning restore 612, 618
        }
    }
}
