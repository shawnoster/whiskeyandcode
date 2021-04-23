### Notes

- Don't bother trying to run PostgreSQL 10.x, it's incompatible w/ Ruby 2.3.1 but you won't figure that out until you go to seed your database.
- In Windows 10 there are socket issues with running PostgreSQL inside Ubuntu so PostgreSQL is installed from Windows, not Ubuntu.
- Due to the interop nature of WSL Ruby has no issues reading the PostgreSQL database server running inside Windows. Magic!

### Install

1. From Windows download the latest stable 9.x version of [PostgreSQL for Windows](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads) from the official site.

Also available from https://www.openscg.com/bigsql/postgresql/installers.jsp/.

    Depending on what else is installed on your system you may get "An error occurred..." error

    * Create a shortcut to the EXE
    * Via properties append ` --install_runtimes 0` to the shortcut target
    * run from the shortcut

    During install accept the defaults until the password page, then...

    * Make the superuser password `foobar`
    * Uncheck "Launch Stack Builder at exit?" (unless you know what you want)

1. From Ubuntu

    ```bash
    $ sudo apt install postgresql-client libpq-dev postgresql-contrib # postgres SQL support
    ```

1. Test that it's running

    ```bash
    $ psql -p 5432 -h localhost -U postgres
    ```

    Assuming it works type `\q` to exit