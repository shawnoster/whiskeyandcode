### Overview & Notes

Redis is a key/value store. If a relational database is an ini-file then key/value stores are system pipes and file sockets.

### Install

1. Install Redis

    ```bash
    $ sudo apt install redis-server -y
    $ redis-cli -v # simple sanity check to make sure it installed
    redis-cli 4.0.9
    ```

1. Restart the Redis server to make sure it's running

   ```
   $ sudo service redis-server restart
   ```

1. Verify your Redis server is running and available

   ```bash
   $ redis-cli 
   127.0.0.1:6379> set user:1 "Jane"
   127.0.0.1:6379> get user:1
   "Jane"
   ```

### Notes
- Cribbed from [Running Redis on Windows 10 – Part I of III](https://redislabs.com/blog/redis-on-windows-10/)