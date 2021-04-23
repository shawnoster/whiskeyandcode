# Ruby Recipes

## Data Manipulation

### Arrays



## Files

### Dumping

Write an array to a file

```ruby
open('/tmp/missing_70025.txt', 'w') { |f|
    f << missing_source_urls.join("\n")
}
```

### CSV

Read a CSV into an array of hashes

```ruby
require 'csv'

# with headers
data = CSV.read('favorite_foods.csv', headers: true)
```