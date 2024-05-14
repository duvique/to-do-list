CREATE DATABASE [todolist];
GO

USE [todolist];
GO

CREATE TABLE [__EFMigrationsHistory] (
    [MigrationId] nvarchar(150) NOT NULL,
    [ProductVersion] nvarchar(32) NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
);
GO
      
CREATE TABLE [Tasks] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Visibility] nvarchar(max) NOT NULL,
    [DueDate] datetime2 NULL,
    [IsFinished] bit NOT NULL,
    [FinishedDate] datetime2 NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Tasks] PRIMARY KEY ([Id])
);