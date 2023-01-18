# OPNewshoreFront
Se debe iniciar el proyecto, descargar las dependencias

## Logs
Los logs se registran cada vez que se genera una excepción, estos se encuentran en la carpeta bin/debug o bin/relase de la capa de presentación en el web api.

C:\Users\ander\OneDrive\Escritorio\Newshore\OP.Newshore.Api\OP.Newshore.WebAPI\bin\Debug\net6.0\logs

## Cambiar divisas
Se utliza api layer para la conversión de divisas, ya que es una prueba gratuita de este api, solo quedan 50 consumos maximos, despues de esto se debe cambiar el apikey que esta en el appsettings para que funcione.

## Development server

Al ejecutar la aplicación esta redigirada al swagger en la ruta: https://localhost:7259/api/swagger para su consumo en el front hecho en angular

## DbContext y base de datos
Se deja relacionado un dbcontext con las entidades: journey, flights y transport si se llega a necesitar ejecutar las migraciones y la creación de una base de datos se deben ejecutar los comandos parado en la capa de persistence
1. add-migration nombre-migracion -o Migrations
2. update-database