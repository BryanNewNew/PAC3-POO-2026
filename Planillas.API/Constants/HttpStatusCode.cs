namespace Planillas.API.Constants
{
    /// <summary>
    /// Contiene los codigos de estado Http utilizados en las respuestas del API
    /// </summary>
    public static class HttpStatusCode
    {
        //TODO se puede colocar documentacion para el codigo 
       #region 2xx - Éxito


        /// <summary>
        /// 200 OK: La solicitud ha tenido éxito.
        /// </summary>
        public const int Ok = 200;

        /// <summary>
        /// 201 Created: La solicitud se ha completado y se ha creado un nuevo recurso.
        /// </summary>
        public const int Created = 201;

        /// <summary>
        /// 204 No Content: La solicitud se completó con éxito, pero no hay contenido que devolver en el cuerpo.
        /// </summary>
        public const int NoContent = 204;

        #endregion

        #region 3xx - Redirección 
        /// <summary>
        /// 302 Found: Se ha encontrado la petición o la información requerida
        /// </summary>
        
        public const int Found = 302;


        #endregion

        #region 4xx - Errores del cliente

        /// <summary>
        /// 400 Bad Request: La solicitud contiene datos inválidos, mal formados o no cumple con las validaciones.
        /// </summary>
        public const int BadRequest = 400;

        /// <summary>
        /// 401 Unauthorized: Se requiere autenticación o las credenciales son inválidas.
        /// </summary>
        public const int Unauthorized = 401;

        /// <summary>
        /// 403 Forbidden: El usuario está autenticado, pero no tiene permisos para acceder al recurso.
        /// </summary>
        public const int Forbidden = 403;

        /// <summary>
        /// 404 Not Found: El recurso solicitado no existe o no fue encontrado.
        /// </summary>
        public const int NotFound = 404;

        /// <summary>
        /// 409 Conflict: La solicitud entra en conflicto con el estado actual del recurso (por ejemplo, registro duplicado).
        /// </summary>
        public const int Conflict = 409;

        /// <summary>
        /// 422 Unprocessable Entity: El formato es comprensible, pero las reglas de negocio o validación fallaron.
        /// </summary>
        public const int UnprocessableEntity = 422;

        #endregion

        #region 5xx - Errores del servidor

        /// <summary>
        /// 500 Internal Server Error: Ocurrió un error inesperado en el servidor al procesar la solicitud.
        /// </summary>
        public const int InternalServerError = 500;

        /// <summary>
        /// 503 Service Unavailable: El servidor o un servicio dependiente no está disponible temporalmente.
        /// </summary>
        public const int ServiceUnavailable = 503;

        #endregion
    }
}