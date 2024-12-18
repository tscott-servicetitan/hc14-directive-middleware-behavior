### HotChocolate Directive Middleware

This project is an example in the difference of behavior using
when defining a directive middleware through an expression vs a class.

This could be at fault of my own by a misconfiguration of my middleware class.

### Faux Feature Provider

The feature provider is a stub with the following values:

* `Foo` => true
* `Bar` => false

View the [schema.graphql](./schema.graphql) to know which fields are
accessible and which are not.

* The `Query.user` should be accessible because it is guarded with `Foo`
* The `User.name` should not be accessible because it is guarded with `Bar`

### Step 1 - Observe Expression Behavior

Go to the [FeatureDirectiveType](./Directives/Feature/FeatureDirectiveType.cs) and
uncomment the code which defines `descriptor.Use` with an expression. 

Run the server

#### Run the following queries:

```graphql
query {
    me {
      id
    }
}
```

as expected this works.

---

```graphql
query {
    me {
      id
      name
    }
}
```

as expected the response returns:
```json
{
  "errors": [
    {
      "message": "The feature 'Bar', is required for use of this field or operation",
      "locations": [
        {
          "line": 4,
          "column": 7
        }
      ],
      "path": [
        "me",
        "name"
      ]
    }
  ],
  "data": null
}
```

### Step 2 - Observe Class Behavior

Go to the [FeatureDirectiveType](./Directives/Feature/FeatureDirectiveType.cs) and
uncomment the code which defines `descriptor.Use<FeatureDirectiveMiddleware>` and re-comment 
the code which defines the middleware as an expression. 

Run the server

#### Run the following queries:

```graphql
query {
    me {
      id
    }
}
```

as expected this works.

---

```graphql
query {
    me {
      id
      name
    }
}
```

Unexpectedly, no error is returned.
```json
{
  "data": {
    "me": {
      "id": "1",
      "name": "John Doe"
    }
  }
}
```
Through debugging, I've discovered the middleware class is called twice with `Foo`
zero times with `Bar`.
