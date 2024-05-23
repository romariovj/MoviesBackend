
# Movies API

API Rest desarrollado en framework dotnet v8.0 y lenguaje de programación c#.
Esta permite consultar datos de peliculas, la información de las pelicúlas se obtiene de una API de tercero.
## Authors

- [@romariovj](https://github.com/romariovj)


## Deployment

Ejecutar los siguientes comandos para ejecutar el proyecto

```bash
  dotnet clean
  dotnet build
  dotnet run
```


## API Reference

#### Get all trending movies

```http
  GET /api/movies/trending
```

#### Get all popular movies

```http
  GET /api/movies/popular
```


#### Search movies by title

| Parameter | Type     | Description                  |
| :-------- | :------- | :--------------------------- |
| `title  ` | `string` | **Required**. Title of movie |


#### Get random list of movies

```http
  GET /api/movies/home
```
