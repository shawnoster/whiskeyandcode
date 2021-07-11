+++
title = "Migrations In SubSonic"
date = "2008-04-13T10:13:00Z"
categories = ["Code"]
tags = ["C#", "SubSonic", "Open Source"]
draft = false
+++


A few weeks ago [Rob Conery](http://blog.wekeroad.com/) foolishly tapped me to help get migrations in SubSonic up to snuff and I've been working on them ever since trying to sneak them into the latest [SubSonic beta](http://blog.wekeroad.com/blog/subsonic-2-1-beta-3-is-ready/). I've changed the way they're implemented slightly from when Rob first talked about them so here's a quick re-introduction to migrations.

Migrations are a way to create and version your database schema using code rather than having to rely on SQL scripts or compare and sync tools. They allow you to quickly rollback schema changes as well migrate schema changes from your development database to staging and then on to production. In a nutshell they rock when it comes to database maintenance, versioning and deployment.

## Migration Breakdown

A migration is a class that descends from SubSonic.Migration and overrides both the Up() and Down() methods. Up() is used when going up a version and Down() is used to restore the database schema to the pre-Up() state. Anything you do in the Up() should be undone in your Down().

By convention they are put in a Migrations folder off the root of your project folder. While the actual name of the class isn't important the name of the file is critical because this is how SubSonic determines which version the migration represents. The naming convention is `000_MigrationName.cs` (or .vb) with the version number represented by leading three numerics, starting at '001' and working your way up. Currently it's pretty particular about that naming convention so make sure it's exactly three numerics, padded with zeros if needed. It's convention to name your migration file something descriptive and to also not repeat names, such as:

```bash
001_AddExerciseTable.cs
```

## An Example

Let's start with a simple example and break it down:

```csharp
using System;
using System.Collections.Generic;
using System.Text;
using SubSonic;

namespace SubSonic {
  public class Migration001:Migration {

    public override void Up() {
      TableSchema.Table t = CreateTable("Flights");
      t.AddColumn("Name", System.Data.DbType.String);
      t.AddColumn("FlightNumber", System.Data.DbType.String, 100);
      t.AddColumn("DateTraveling", System.Data.DbType.DateTime, 0, false, "getdate()");
      AddSubSonicStateColumns(t);
    }

    public override void Down() {
      DropTable("Flights");
    }
  }
}
```

In the example the 'Flights' table is created, then three columns are added to it, followed by the standard SubSonic state columns. If you don't specify a primary key one will be created for you with the pattern of 'TableNameID', so that's one less thing to worry about. The Down() method undoes everything we did in the Up() by dropping the 'Flights' table.

## Available Methods

Currently the methods available from inside your migration are:

* `CreateTable(string tableName)` - This creates and returns a table schema to which you can add your columns, as seen in the example.
* `DropTable(string tableName)` - Does exactly what it says. If your Up() has a CreateTable() you'll need a corresponding DropTable().
* `AddColumn(string tableName, string columnName, ...)` - Used to add a new column to an existing table. It has all the same overloads as TableSchema.Table.AddColumn() except the first parameter is the name of the table you'll be adding columns to.
* `RemoveColumn(string tableName, string columnName)` - You only get one guess that this does :)
* `AlterColumn(string tableName, string columnName, ...)` - Used to alter an existing column, again, the same overloads as AddColumn.
* `AddSubSonicStateColumns(TableSchema.Table table)` - Adds the conventional SubSonic state columns to your table. I'll be adding another overload that just takes a tableName if you want to add those columns to an existing table.

## Running your Migrations

To run your migrations you'll use SubCommander, the same tool used to generate your models but with the 'migrate' command. The simplest usage is:

```powershell
sonic migrate
```

That's it. It'll use your default provider, look for your migrations in Migrations and run every migration Up() starting at your database's current migration up the last one found in the Migrations folder. You can also specify the provider, migration directory and version at the command line like this:

```powershell
sonic migrate /provider "Northwind" /migrationDirectory "D:TestingMigrations" /version 4
```

A few things to remember:

* Migrations by convention are looked for in a Migrations folder off the root of your project, though this can be changed via the command line. (/migrationDirectory "D:Migrations")
* You run a migration against a single provider at a time, there is no support for specifying the provider inside the migration. The main reason is portability, often you'll be running this migrations against different databases and hardcoding the provider name in the migration destroys their usefulness.
* Migrations will run against the default provider unless otherwise specified via the command line (/provider "Northwind")
* By default migrations will try to go up to the latest version found in the migrations folder.  To go up or down to a specific version use /version X to indicate which version.
* To enable migration support a new table 'SubSonicSchemaInfo' will be created in your database, so don't delete it and tell your DBA that it's OK :)

### TODO

These are things you *should* see before the next beta drop, but don't hold me to it :)

* Ability to generate your migration code skeleton using sonic.exe.
* Add RenameTable()
* Add RenameColumn()
* Add ability to execute ad-hoc sql, for creating stored procs, views, creating roles, users, etc.
* Add constraints
* Add foreign keys