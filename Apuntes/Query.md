Un query (en español, consulta) es una petición de información o de acción que haces a un sistema de datos —como una base de datos, un buscador o una colección en código— para leer, filtrar, ordenar, insertar, actualizar o borrar datos.

En términos sencillos: es la "pregunta" o instrucción estructurada que envías para decir "dame estos datos específicos bajo estas condiciones".

¿Dónde se usa un query?
En bases de datos (SQL):
Es la sentencia que escribes para hablar con tablas (por ejemplo en DBeaver o SQL Server):

SQL
SELECT Nombre, Precio
FROM Productos
WHERE Stock <= 5;
Ahí le estás pidiendo solo el nombre y el precio de los productos que tengan 5 o menos unidades.

En URLs de APIs / Web (Query strings):
Cuando ves una dirección como:/api/productos?page=1&pageSize=10
La parte después del signo ? (page=1&pageSize=10) se conoce como query parameters (parámetros de consulta), porque le pasan filtros o datos extra a la petición.

Diferencia rápida: Query vs. Command
En desarrollo de software (y en APIs) suele distinguirse entre:

Query (consulta): Solo lee o busca información sin modificar el estado de los datos (por ejemplo, un GET).

Command (comando): Cambia algo en el sistema (crear, editar o eliminar un registro, como un POST, PUT o DELETE).

Por ejemplo IQueryable:

IQueryable<T> en C# representa una consulta (query) aún no ejecutada que se va armando paso a paso (con Where, OrderBy, Skip, Take, etc.) y que, cuando estás trabajando con una base de datos (como con Entity Framework), se traduce y ejecuta directamente en el motor de base de datos (por ejemplo, a SQL) en lugar de traer todos los registros a la memoria de tu aplicación primero.

¿Qué tiene de especial IQueryable<T>?
Ejecución diferida (Lazy evaluation):
Mientras vas encadenando filtros o paginación, la base de datos todavía no devuelve los datos. Solo se ejecuta cuando materializas la consulta (por ejemplo, con .ToList(), .FirstOrDefault(), .Count() o al recorrerla con foreach).